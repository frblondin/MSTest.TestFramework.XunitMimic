using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSTest.TestAdapter.XUnitLookAlike.Tests.Extensions
{
    public static class TestCaseExtensions
    {
        public static ITestMethod ToTestMethod(this TestCase source)
        {
            var dotPos = source.FullyQualifiedName.LastIndexOf('.');
            var type = Type.GetType(source.FullyQualifiedName.Substring(0, dotPos));
            var method = type.GetMethod(source.FullyQualifiedName.Substring(dotPos + 1));
            return source.ToTestMethod(method);
        }

        public static ITestMethod ToTestMethod(this TestCase source, MethodInfo method)
        {
            var result = Substitute.For<ITestMethod>();
            result.GetAttributes<DataRowAttribute>(false).Returns(method.GetCustomAttributes<DataRowAttribute>(false));
            result.WhenForAnyArgs(tm => tm.Invoke(null))
                .Do(cb =>
                {
                    try
                    {
                        method.Invoke(Activator.CreateInstance(method.ReflectedType), cb.Arg<object[]>());
                    }
                    catch (TargetInvocationException e)
                    {
                        throw e.InnerException;
                    }
                });
            return result;
        }
    }
}
