using Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.TestAdapter.XUnitLookAlike.Tests.Extensions;
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
    public class FactAttributeTests
    {
        [TestClass]
        public class DecoratedWithXUnitAttributes
        {
            [Fact, Ignore]
            public void Fact() { }
        }

        [TestMethod]
        public void FactIsDiscovered()
        {
            var testCases = typeof(DecoratedWithXUnitAttributes).Assembly.DiscoverTests();
            Xunit.Assert.Contains(
                $"{typeof(DecoratedWithXUnitAttributes).FullName}.{nameof(DecoratedWithXUnitAttributes.Fact)}",
                testCases.Select(tc => tc.FullyQualifiedName));
        }
    }
}
