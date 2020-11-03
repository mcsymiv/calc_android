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
        [TestCase("2")]
        public void CheckAddition(string expected)
        {
            calc.TapOnOne()
                .TapOnPlus()
                .TapOnOne()
                .TapOnEqual();
            string result = calc.GetResult();
            Assert.AreEqual(expected, result);
        }
    }
}
