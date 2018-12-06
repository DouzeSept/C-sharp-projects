using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumbersInWords
{
    [TestClass]
    public class NumbersInWordsTest
    {
        [TestMethod]
        public void Return_one_if_input_is_1()
        {
            var niw = new NumbersInWords();
            string Result = niw.Convert(1);
            Assert.AreEqual("one", Result);
        }

        [TestMethod]
        public void Return_eleven_if_input_is_11()
        {
            var niw = new NumbersInWords();
            string Result = niw.Convert(11);
            Assert.AreEqual("eleven", Result);
        }

        [TestMethod]
        public void Return_ninty_nine_if_input_is_99()
        {
            var niw = new NumbersInWords();
            string Result = niw.Convert(99);
            Assert.AreEqual("ninty nine", Result);
        }

        [TestMethod]
        public void Return_five_hundred_and_sixty_seven_if_input_is_567()
        {
            var niw = new NumbersInWords();
            string Result = niw.Convert(567);
            Assert.AreEqual("five hundred and sixty seven", Result);
        }

        [TestMethod]
        public void Return_eight_hundred_if_input_is_800()
        {
            var niw = new NumbersInWords();
            string Result = niw.Convert(800);
            Assert.AreEqual("eight hundred", Result);
        }

        [TestMethod]
        public void Return_three_million_comma_eighty_thousand_and_two_hundred_and_three_if_input_is_3080203()
        {
            var niw = new NumbersInWords();
            string Result = niw.Convert(3080203);
            Assert.AreEqual("three million, eighty thousand and two hundred and three", Result);
        }

        [TestMethod]
        public void one_quintillion_and_one_if_input_is_1000000000000000001()
        {
            var niw = new NumbersInWords();
            string Result = niw.Convert(1000000000000000001);
            Assert.AreEqual("one quintillion and one", Result);
        }
    }

    public class NumbersInWords
    {
        public NumbersInWords()
        {

        }

        public string Convert(ulong Input)
        {
            string[] KeywordsUnit = {"", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "ninteen"};
            string[] KeywordsTens = {"", "", "twenty", "thirty", "fourty", "fifty", "sixty",
            "seventy", "eighty", "ninty"};
            string[] Keywords000 = { "", " thousand", " million", " Billion", " trillion", " quatrillion", " quintillion" };
            int i = 0, l = Input.ToString().Length;
            int[] Digits = new int[l];
            int j = (l - 1) / 3;
            int k = (l - 1) % 3;
            string Output = "", ConnectString = "";
            bool IsZero = true;
            while (Input > 0)
            {
                Digits[i++] = (int)(Input % 10);
                Input /= 10;
            }
            for (i = l - 1; i >= 0; i--)
            {
                if (Digits[i] > 0)
                {
                    IsZero = false;
                    if (ConnectString == ", " && j == 0)
                        ConnectString = " and ";
                    Output += ConnectString;
                    switch (k)
                    {
                        case 2:
                            Output += KeywordsUnit[Digits[i]] + " hundred";
                            ConnectString = " and ";
                            break;
                        case 1:
                            if (Digits[i] == 1)
                            {
                                Output += KeywordsUnit[10 + Digits[--i]];
                                k--;
                            }
                            else
                            {
                                Output += KeywordsTens[Digits[i]];
                                ConnectString = " ";
                            }
                            break;
                        case 0:
                            Output += KeywordsUnit[Digits[i]];
                            break;
                    }
                }
                if (k == 0)
                {
                    if (!IsZero)
                    {
                        Output += Keywords000[j];
                        ConnectString = ", ";
                        IsZero = true;
                    }
                    k = 2;
                    j--;
                }
                else
                    k--;
            }
            return Output;
        }

        /* V6
        public string Convert(ulong Input)
        {
            string[] KeywordsUnit = {"", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "ninteen"};
            string[] KeywordsTens = {"", "", "twenty", "thirty", "fourty", "fifty", "sixty",
            "seventy", "eighty", "ninty"};
            string[] Keywords000 = { "", " thousand", " million"};
            int i = 0, l = Input.ToString().Length;
            int[] Digits = new int[l];
            int j = (l - 1) / 3;
            int k = (l - 1) % 3;
            string Output = "", ConnectString = "";
            while (Input > 0)
            {
                Digits[i++] = (int)(Input % 10);
                Input /= 10;
            }
            for (i = l - 1; i >= 0; i--)
            {
                if (Digits[i] > 0)
                {
                    Output += ConnectString;
                    switch (k)
                    {
                        case 2:
                            Output += KeywordsUnit[Digits[i]] + " hundred";
                            ConnectString = " and ";
                            break;
                        case 1:
                            if (Digits[i] == 1)
                            {
                                Output += KeywordsUnit[10 + Digits[--i]];
                                k--;
                            }
                            else
                            {
                                Output += KeywordsTens[Digits[i]];
                                ConnectString = " ";
                            }
                            break;
                        case 0:
                            Output += KeywordsUnit[Digits[i]];
                            break;
                    }
                }
                if (k == 0)
                {
                    Output += Keywords000[j];
                    if (j-- == 1)
                        ConnectString = " and ";
                    else
                        ConnectString = ", ";
                    k = 2;
                }
                else
                    k--;
            }
            return Output;
        }
        */
        /* V5
        public string Convert(ulong Input)
        {
            string[] KeywordsUnit = {"", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "ninteen"};
            string[] KeywordsTens = {"", "", "twenty", "thirty", "fourty", "fifty", "sixty",
            "seventy", "eighty", "ninty"};
            int i = 0, l = Input.ToString().Length;
            int[] Digits = new int[l];
            string Output = "", ConnectString = "";
            while (Input > 0)
            {
                Digits[i++] = (int)(Input % 10);
                Input /= 10;
            }
            for (i = l - 1; i >= 0; i--)
            {
                if (Digits[i] > 0)
                {
                    Output += ConnectString;
                    switch (i)
                    {
                        case 2:
                            Output += KeywordsUnit[Digits[i]] + " hundred";
                            ConnectString = " and ";
                            break;
                        case 1:
                            if (Digits[i] == 1)
                                Output += KeywordsUnit[10 + Digits[--i]];
                            else
                            {
                                Output += KeywordsTens[Digits[i]];
                                ConnectString = " ";
                            }  
                            break;
                        case 0:
                            Output += KeywordsUnit[Digits[i]];
                            break;
                    }
                }
            }
            return Output;
        }
        */
        /* V4
        public string Convert(ulong Input)
        {
            string[] KeywordsUnit = {"", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "ninteen"};
            string[] KeywordsTens = {"", "", "twenty", "thirty", "fourty", "fifty", "sixty",
            "seventy", "eighty", "ninty"};
            int i = 0, l = Input.ToString().Length;
            int[] Digits = new int[l];
            string Output = "";
            while (Input > 0)
            {
                Digits[i++] = (int) (Input % 10);
                Input /= 10;
            }
            for (i = l - 1; i >= 0; i--)
            {
                if (Digits[i] > 0)
                {
                    switch (i)
                    {
                        case 2:
                            Output += KeywordsUnit[Digits[i]] + " hundred and ";
                            break;
                        case 1:
                            if (Digits[i] == 1)
                                Output += KeywordsUnit[10 + Digits[--i]];
                            else
                                Output += KeywordsTens[Digits[i]] + " ";
                            break;
                        case 0:
                            Output += KeywordsUnit[Digits[i]];
                            break;
                    }
                }
            }
            return Output;
        }
        */
        /* V3
        public string Convert(ulong Input)
        {
            string[] KeywordsUnit = {"", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "ninteen"};
            string[] KeywordsTens = {"", "", "twenty", "thirty", "fourty", "fifty", "sixty",
            "seventy", "eighty", "ninty"};
            if (Input > 19)
                return KeywordsTens[Input / 10] + " " + KeywordsUnit[Input % 10];
            return KeywordsUnit[Input];
        }
        */
        /* V2
        public string Convert(ulong Input)
        {
            string[] Keywords = {"", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "ninteen"};

            return Keywords[Input];
        }
        */
        /* V1
        public string Convert(ulong Input)
        {
            return "one";
        }
        */
    }
}
