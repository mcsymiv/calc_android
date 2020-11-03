using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CalcTest.Views
{
    public class CalcView
    {
        public static IApp App => AppInit.App;
        public Query textView = x => x.Id("input");
        public Query btnDel = x => x.Marked("DEL");
        public Query btnZero = x => x.Marked("0");
        public Query btnOne = x => x.Marked("1");
        public Query btnTwo = x => x.Marked("2");
        public Query btnPlus = x => x.Marked("+");
        public Query btnEqual = x => x.Marked("=");
        public static void Repl()
        {
            App.Repl();
        }
        public CalcView TapOnOne()
        {
            App.Tap(btnOne);
            return this;
        }
        public CalcView TapOnPlus()
        {
            App.Tap(btnPlus);
            return this;
        }
        public CalcView TapOnEqual()
        {
            App.Tap(btnEqual);
            return this;
        }
        public string GetResult()
        {
            return App.Query(textView)[0].Text.Trim();
        }
    }
}
