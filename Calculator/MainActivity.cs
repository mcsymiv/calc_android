using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Android.Views;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@android:style/Theme.DeviceDefault.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private TextView _calcText;
        private string[] _numbers = new string[2];
        private string @operator;
        private bool _isResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _calcText = FindViewById<TextView>(Resource.Id.input);
            _numbers[0] = "0";
            _isResult = false;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Java.Interop.Export("ButtonClick")]
        public void ButtonClick(View view)
        {
            Button button = (Button)view;
            if ("0123456789.".Contains(button.Text))
            {
                AddButtonValues(button.Text);
                _isResult = false;
            }
            else if ("+-*/".Contains(button.Text))
            {
                AddOperator(button.Text);
                _isResult = false;
            }
            else if ("=" == button.Text) Calculate();
            else Clear();
        }

        private void AddButtonValues(string buttonText)
        {
            if (_calcText.Text == "Wrong input!" || _isResult)
            {
                Clear();
            }

            int index = @operator == null ? 0 : 1;
            if (buttonText == "." && _numbers[index].Contains(".")) return;
            _numbers[index] += buttonText;
            if ((_numbers[0].StartsWith("0")) && (_numbers[0].Length > 1)
                && (_numbers[0][1] != '.'))
                _numbers[0] = _numbers[0].Substring(1); // remove 0 from the start of number input
            UpdateCalculatorText();

        }
        private void AddOperator(string buttonText)
        {
            if (_numbers[1] != null)
            {
                Calculate(buttonText);
                return;
            }
            @operator = buttonText;
            UpdateCalculatorText();
        }
        private void Calculate(string newOperator = null)
        {
            bool isValid = true;
            double? result = null;
            double? first = _numbers[0] == null ? null : (double?)double.Parse(_numbers[0]);
            double? second = _numbers[1] == null ? null : (double?)double.Parse(_numbers[1]);
            switch (@operator)
            {
                case "+":
                    result = first + second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    if (second * 1 == 0) isValid = false;
                    else result = first / second;
                    break;
                case "-":
                    result = first - second;
                    break;
            }
            if (!isValid)
            {
                _numbers[0] = "Wrong input!";
                _numbers[1] = null;
            }
            else if (result != null)
            {
                _numbers[0] = result.ToString().Trim();
                _numbers[1] = null;
            }
            _isResult = true;
            @operator = newOperator;
            UpdateCalculatorText();
        }
        private void Clear()
        {
            _numbers[0] = "0";
            _numbers[1] = null;
            @operator = null;
            UpdateCalculatorText();
        }
        private void UpdateCalculatorText()
        {
            _calcText.Text = $"{_numbers[0]}{@operator}{_numbers[1]}";
        }
    }
}

