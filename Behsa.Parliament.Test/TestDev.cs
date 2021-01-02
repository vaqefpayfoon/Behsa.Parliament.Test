using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Behsa.Parliament.Test
{
    public class TestDev
    {
        [Fact]
        public void CalcString()
        {
            int i = 0;
            string str = string.Empty;
            if (int.TryParse("0004", out i))
            {
                i++;
                str = (i.ToString().PadLeft(4, '0'));
            }
            Assert.NotNull(str);
        }
    }
}
