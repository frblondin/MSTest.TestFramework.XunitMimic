using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xunit
{
    /// <summary>
    /// Provides a data source for a data theory, with the data coming from inline values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InlineDataAttribute : DataRowAttribute
    {
        public InlineDataAttribute(object data1) : base(data1) { }
        public InlineDataAttribute(object data1, params object[] moreData) : base(data1, moreData) { }
    }
}
