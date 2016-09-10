using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunit
{
    /// <summary>
    /// Attribute that is applied to a method to indicate that it is a fact that should
    /// be run by the test runner. It can also be extended to support a customized definition
    /// of a test method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class FactAttribute : TestMethodAttribute
    {
    }
}
