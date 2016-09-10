using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunit
{
    /// <summary>
    /// Marks a test method as being a data theory. Data theories are tests which are
    /// fed various bits of data from a data source, mapping to parameters on the test
    /// method. If the data source contains multiple rows, then the test method is executed
    /// multiple times (once with each data row). Data is provided by attributes which
    /// derive from Xunit.Sdk.DataAttribute (notably, <see cref="Xunit.InlineDataAttribute"/>
    /// and <see cref="Xunit.MemberDataAttribute"/>).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TheoryAttribute : DataTestMethodAttribute
    {
    }
}
