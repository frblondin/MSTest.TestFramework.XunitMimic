using Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.TestAdapter.XUnitLookAlike.Tests.Extensions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MSTest.TestAdapter.XUnitLookAlike.Tests
{
    [TestClass]
    public class TheoryAttributeTests
    {
        public class DummyException : Exception { public DummyException(string message) : base(message) { } }

        [TestClass]
        public class DecoratedWithXUnitAttributes
        {
            [Theory, Ignore]
            [InlineData("foo")]
            public void TheoryUsingInlineData(string value)
            {
                throw new DummyException(value);
            }
        }

        [TestMethod]
        public void TheoryIsDiscovered()
        {
            var testCases = typeof(DecoratedWithXUnitAttributes).Assembly.DiscoverTests();
            Xunit.Assert.Contains(
                $"{typeof(DecoratedWithXUnitAttributes).FullName}.{nameof(DecoratedWithXUnitAttributes.TheoryUsingInlineData)}",
                testCases.Select(tc => tc.FullyQualifiedName));
        }

        [TestMethod]
        public void TheoryUsingInlineDataContainsData()
        {
            var testCase = typeof(DecoratedWithXUnitAttributes).Assembly.DiscoverTests(typeof(DecoratedWithXUnitAttributes), nameof(DecoratedWithXUnitAttributes.TheoryUsingInlineData));
            var method = typeof(DecoratedWithXUnitAttributes).GetMethod(nameof(DecoratedWithXUnitAttributes.TheoryUsingInlineData));
            var testMethod = testCase.ToTestMethod();
            var theoryAttribute = method.GetCustomAttribute<TheoryAttribute>();
            var exception = Xunit.Assert.Throws<DummyException>(() => theoryAttribute.Execute(testMethod));
            Xunit.Assert.Equal("foo", exception.Message);
        }
    }
}
