using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Linq;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@android:style/Theme.DeviceDefault.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public string Number;
        public string NumberInput;

        public string GetNumberInput(string input)
        {
            if (input == "*" ||
                input == "/" ||
                input == "-" ||
                input == "+" ||
                input == "=" ||
                input == "DEL") return Number;
            else return Number = Number + input;
        }
        public decimal CalculateDecimalResult(string operation, decimal firstNum, decimal secondNum)
        {
            switch (operation)
            {
                case "+":
                    return firstNum + secondNum;
                case "-":
                    return firstNum - secondNum;
                case "*":
                    return firstNum * secondNum;
                case "/":
                    return firstNum / secondNum;
                default:
                    return -1;
            }
        }

    }
}