using CalcTest.Views;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CalcTest.Steps
{
    [Binding]
    public class CalculatorTestsSteps
    {
        CalcView calc;
        string operandForMultiply;

        [Given(@"calculator app is initialized")]
        public void GivenCalculatorAppIsInitialized()
        {
            AppInit.StartApp();
            calc = new CalcView();
        }

        [When(@"The (.*) number typed at the calculator")]
        public void WhenTheNumberTypedAtTheCalculator(double operand)
        {
            TapNumber(operand.ToString());
        }

        [When(@"I tap on substract button")]
        public void WhenITapOnSubstractButton()
        {
            calc.TapOnMinus();
        }

        [Then(@"I see (.*) number and substract operand at the input field")]
        public void ThenISeeNumberAndSubstractOperandAtTheInputField(double operand)
        {
            Assert.AreEqual(operand + "-", calc.CalcViewText);
        }

        [Then(@"I see (.*) and (.*) numbers separated by substract operand")]
        public void ThenISeeAndNumbersSeparatedBySubstractOperand(double first, double second)
        {
            string expected = first + "-" + second;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        [When(@"I tap on equal button")]
        public void WhenITapOnEqualButton()
        {
            calc.TapOnEqual();
        }

        [Then(@"I see the (.*) of operation at the input field")]
        public void ThenISeeTheOfOperationAtTheInputField(double result)
        {
            Assert.AreEqual(result.ToString(), calc.CalcViewText);
        }

        // DIVISION
        [When(@"I tap on division button")]
        public void WhenITapOnDivisionButton()
        {
            calc.TapOnDivide();
        }

        [Then(@"I see (.*) and (.*) numbers separated by division operand")]
        public void ThenISeeAndNumbersSeparatedByDivisionOperand(double first, double second)
        {
            string expected = first + "/" + second;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        // DIvision on "0"
        [Then(@"I see informational error message")]
        public void ThenISeeInformationalErrorMessage()
        {
            Assert.AreEqual("Wrong input!", calc.CalcViewText);
        }

        //Tap Comma after initialising
        [When(@"I tap on '(.*)' button")]
        public void WhenITapOnButton(string operation)
        {
            calc.TapOnButton(operation);
        }

        [Then(@"I see (.*) and '(.*)' sign")]
        public void ThenISeeAndSign(int operand, string operation)
        {
            string expected = operand + operation;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        [Then(@"I see (.*) and (.*) numbers separated by '(.*)' sign")]
        public void ThenISeeAndNumbersSeparatedBySign(int first, int second, string operation)
        {
            string expected = first + operation + second;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        [When(@"I select a sign like plus")]
        public void WhenISelectASignLikePlus()
        {
            calc.TapOnPlus();
        }

        //multiply positive tests

        [When(@"I select a sign like multiply")]
        public void WhenISelectASignLikeMultiply()
        {
            calc.TapOnProduct();
        }

        // Two dot signs
        [Given(@"Fractional number typed into input field")]
        public void GivenFractionalNumberTypedIntoInputField()
        {
            TapNumber("123.45");
        }

        [When(@"I tap one more separator sign (.*)")]
        public void WhenITapOneMoreSeparatorSign(string p0)
        {
            calc.TapOnComma();
        }

        [Then(@"Sign is not tapped")]
        public void ThenSignIsNotTapped()
        {
            Assert.AreEqual("123.45", calc.CalcViewText);
        }

        [When(@"I add (.*) to the number")]
        public void WhenIAddToTheNumber(int p0)
        {
            calc.TapOnPlus().TapOnButton("1");
        }

        [Then(@"The result is more by one")]
        public void ThenTheResultIsMoreByOne()
        {
            Assert.AreEqual("124.45", calc.CalcViewText);
        }

        // Multiply operations
        [Given(@"Random number is typed to calculator")]
        public void GivenRandomNumberIsTypedToCalculator()
        {
            Random rdm = new Random();
            operandForMultiply = (rdm.Next(0, 21) + 1).ToString();
            TapNumber(operandForMultiply);
        }

        [Then(@"I see is more by one than random")]
        public void ThenISeeIsMoreByOneThanRandom()
        {
            int.TryParse(operandForMultiply, out int expected);
            expected += 1;
            Assert.AreEqual(expected.ToString(), calc.CalcViewText);
        }

        [Then(@"I see is more by one than previous number")]
        public void ThenISeeIsMoreByOneThanPreviousNumber()
        {
            int.TryParse(operandForMultiply, out int expected);
            expected += 2;
            Assert.AreEqual(expected.ToString(), calc.CalcViewText);
        }

        // operator + sign + =
        [Then(@"I see operand and '(.*)' number at input field")]
        public void ThenISeeOperandAndNumberAtInputField(string sign)
        {
            string expected = operandForMultiply + sign;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        // Tap on equel after start of project
        [Then(@"The (.*) number typed at the calculator input field")]
        public void ThenTheNumberTypedAtTheCalculatorInputField(int num)
        {
            Assert.AreEqual(num.ToString(), calc.CalcViewText);
        }

        // Unrelated multiply operations 
        [When(@"I tap on random number")]
        public void WhenITapOnRundomNumber()
        {
            Random rdm = new Random();
            operandForMultiply = rdm.Next(0, 21).ToString();
            TapNumber(operandForMultiply);
        }

        [Then(@"I see only random number at the calculator input")]
        public void ThenISeeOnlyRandomNumberAtTheCalculatorInput()
        {
            Assert.AreEqual(operandForMultiply, calc.CalcViewText);
        }

        // ZERO
        [When(@"I tap on dot button")]
        public void WhenITapOnDotButton()
        {
            calc.TapOnComma();
        }

        public void TapNumber(string operand)
        {
            char[] number = operand.ToCharArray();
            foreach (var item in number)
            {
                calc.TapOnButton(item.ToString());

            }
        }

        [BeforeScenario]
        public void BeforeEveryTestOpenApplication()
        {
            AppInit.StartApp();
        }
    }
}
