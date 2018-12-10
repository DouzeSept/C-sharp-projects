using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FooBarQix
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Return_string_1_if_input_is_1()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(1);
            Assert.AreEqual("1", Result);
        }

        [TestMethod]
        public void Return_string_2_if_input_is_2()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(2);
            Assert.AreEqual("2", Result);
        }

        [TestMethod]
        public void Return_string_Foo_if_input_is_6()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(6);
            Assert.AreEqual("Foo", Result);
        }

        [TestMethod]
        public void Return_string_FooFoo_if_input_is_1311()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(1311);
            Assert.AreEqual("FooFoo", Result);
        }

        [TestMethod]
        public void Return_string_FooQix_if_input_is_21()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(21);
            Assert.AreEqual("FooQix", Result);
        }

        [TestMethod]
        public void Return_string_FooBarBarBar_if_input_is_255()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(255);
            Assert.AreEqual("FooBarBarBar", Result);
        }

        [TestMethod]
        public void Return_string_FooBarQixStarBar_if_input_is_105()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(105);
            Assert.AreEqual("FooBarQix*Bar", Result);
        }

        [TestMethod]
        public void Return_string_1Star4_if_input_is_104()
        {
            FooBarQix fbq = new FooBarQix();
            string Result = fbq.Convert(104);
            Assert.AreEqual("1*4", Result);
        }
    }

    public class FooBarQix
    {
        public FooBarQix()
        {

        }

        public struct ReplacementBundle
        {
            public int Divisor;
            public string ReplacingString;

            public ReplacementBundle(int d, string r)
            {
                Divisor = d;
                ReplacingString = r;
            }
        }

        public string Convert(uint Input)
        {
            string Output, OutputBis = "";
            ReplacementBundle[] rbs = new ReplacementBundle[]
            {
                new ReplacementBundle(3, "Foo"),
                new ReplacementBundle(5, "Bar"),
                new ReplacementBundle(7, "Qix")
            };
            var strQuery = from rb in rbs
                           where Input % rb.Divisor == 0
                           select rb.ReplacingString;
            Output = String.Join("", strQuery);
            foreach (char c in Input.ToString())
            {
                strQuery = from rb in rbs
                           where Char.GetNumericValue(c) == rb.Divisor
                           select rb.ReplacingString;
                Output += String.Join("", strQuery);
                if (c == '0')
                {
                    Output += "*";
                    OutputBis += "*";
                }
                else
                    OutputBis += c.ToString();
            }
            return Output.All(c => c == '*') ? OutputBis : Output;
        }

        /* V7
        public string Convert(uint Input)
        {
            char[] arrChars = Input.ToString().ToCharArray();
            string Output = "";
            List<ReplacementBundle> rbs = new List<ReplacementBundle>
            {
                new ReplacementBundle(3, "Foo"),
                new ReplacementBundle(5, "Bar"),
                new ReplacementBundle(7, "Qix")
            };
            var strQuery = from rb in rbs
                           where Input % rb.Divisor == 0
                           select rb.ReplacingString;
            foreach (string str in strQuery)
                Output += str;
            rbs.Add(new ReplacementBundle(0, "*"));
            foreach (char c in arrChars)
            {
                strQuery = from rb in rbs
                           where Char.GetNumericValue(c) == rb.Divisor
                           select rb.ReplacingString;
                foreach (string str in strQuery)
                    Output += str;
            }
            return Output == "" ? Input.ToString() : Output;
        }
        */
        /* V6
        public string Convert(uint Input)
        {
            char[] arrChars = Input.ToString().ToCharArray();
            string Output = "";
            ReplacementBundle[] rbs = {new ReplacementBundle(3, "Foo"),
                                       new ReplacementBundle(5, "Bar"),
                                       new ReplacementBundle(7, "Qix")};
            var strQuery = from rb in rbs
                           where Input % rb.Divisor == 0
                           select rb.ReplacingString;
            foreach (string str in strQuery)
                Output += str;
            foreach (char c in arrChars)
            {
                strQuery = from rb in rbs
                           where Char.GetNumericValue(c) == rb.Divisor
                           select rb.ReplacingString;
                foreach (string str in strQuery)
                    Output += str;
            }
            return Output == "" ? Input.ToString() : Output;
        }
        */
        /* V5
        public string Convert(uint Input)
        {
            uint Temp = Input;
            string Output = "";
            ReplacementBundle[] rbs = {new ReplacementBundle(3, "Foo"),
                                       new ReplacementBundle(5, "Bar"),
                                       new ReplacementBundle(7, "Qix")};
            var strQuery = from rb in rbs
                           where Input % rb.Divisor == 0
                           select rb.ReplacingString;
            foreach (string str in strQuery)
                Output += str;
            while (Temp > 0)
            {
                if (Temp % 10 == 3)
                    Output += "Foo";
                Temp /= 10;
            }
            return Output == "" ? Input.ToString() : Output;
        }
        */
        /* V4
        public string Convert(uint Input)
        {
            uint Temp = Input;
            string Output = "";
            if (Input % 3 == 0)
                Output += "Foo";
            while (Temp > 0)
            {
                if (Temp % 10 == 3)
                    Output += "Foo";
                Temp /= 10;
            }
            return Output == "" ? Input.ToString() : Output;
        }
        */
        /* V3
        public string Convert(uint Input)
        {
            if (Input % 3 == 0)
                return "Foo";
            return Input.ToString();
        }
        */
        /* V2
        public string Convert(uint Input)
        {
            return Input.ToString();
        }
        */
        /* V1
        public string Convert(uint Input)
        {
            return "1";
        }
        */
    }
}
