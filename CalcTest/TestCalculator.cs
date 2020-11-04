using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcTest.Views;
using NUnit.Framework;

namespace CalcTest
{
    public class TestCalculator
    {
        CalcView calc = new CalcView();
        [SetUp]
        public void BeforeEveryTestOpenApplication()
        {
            AppInit.StartApp();
        }
        [Test]
        public void Test()
        {
            CalcView.Repl();
        }
        [TestCase("2", "+", "3", "5", Description = "Check addition")]
        public void CheckAddition(string first, string oper, string second, string expected)
        {
            calc.TapOnButton(first);
            Assert.AreEqual(first, calc.CalcViewText);
            calc.TapOnButton(oper);
            Assert.AreEqual(first + oper, calc.CalcViewText);
            calc.TapOnButton(second);
            Assert.AreEqual(first + oper + second, calc.CalcViewText);
            calc.TapOnEqual();
            Assert.AreEqual(expected, calc.CalcViewText);
        }
    }
}
