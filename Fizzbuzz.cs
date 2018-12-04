using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fizzbuzz
{
    [TestClass]
    public class FizzbuzzTest
    {
        [TestMethod]
        public void Return_string_1_if_input_is_1()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(1);
            Assert.AreEqual(Result, "1");
        }

        [TestMethod]
        public void Return_string_2_if_input_is_2()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(2);
            Assert.AreEqual(Result, "2");
        }

        [TestMethod]
        public void Return_string_Fizz_if_input_is_3()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(3);
            Assert.AreEqual(Result, "Fizz");
        }

        [TestMethod]
        public void Return_string_Fizz_if_input_is_6()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(6);
            Assert.AreEqual(Result, "Fizz");
        }

        [TestMethod]
        public void Return_string_Fizz_if_input_is_13()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(13);
            Assert.AreEqual(Result, "Fizz");
        }

        [TestMethod]
        public void Return_string_Fizz_if_input_is_31()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(31);
            Assert.AreEqual(Result, "Fizz");
        }

        [TestMethod]
        public void Return_string_Buzz_if_input_is_25()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(25);
            Assert.AreEqual(Result, "Buzz");
        }

        [TestMethod]
        public void Return_string_Buzz_if_input_is_52()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(52);
            Assert.AreEqual(Result, "Buzz");
        }

        [TestMethod]
        public void Return_string_FizzBuzz_if_input_is_51()
        {
            var fb = new Fizzbuzz();
            string Result = fb.Convert(51);
            Assert.AreEqual(Result, "FizzBuzz");
        }
    }

    public class Fizzbuzz
    {
        public Fizzbuzz()
        {

        }

        public string Convert(int Input)
        {
            // Input = Math.Abs(Input);
            bool Fizz = false, Buzz = false;
            int temp = Input;
            if (Input % 3 == 0)
                Fizz = true;
            if (Input % 5 == 0)
                Buzz = true;
            do
            {
                if (temp % 10 == 3)
                    Fizz = true;
                if (temp % 10 == 5)
                    Buzz = true;
                if (Fizz && Buzz)
                    return "FizzBuzz";
                temp /= 10;
            } while (temp > 0);
            if (Fizz)
                return "Fizz";
            if (Buzz)
                return "Buzz";
            return Input.ToString();
        }
        /* eighth version
        public string Convert(int Input)
        {
            if (Input % 3 == 0)
                return "Fizz";
            if (Input % 5 == 0)
                return "Buzz";
            int temp = Input;
            do
            {
                if (temp % 10 == 3)
                    return "Fizz";
                if (temp % 10 == 5)
                    return "Buzz";
                temp /= 10;
            } while (temp > 0);
            return Input.ToString();
        }
        */
        /* seventh version
                public string Convert(int Input)
                {
                    if (Input % 3 == 0)
                        return "Fizz";
                    if (Input % 5 == 0)
                        return "Buzz";
                    int temp = Input;
                    do
                    {
                        if (temp % 10 == 3)
                            return "Fizz";
                        temp /= 10;
                    } while (temp > 0);
                    return Input.ToString();
                }
        */
        /* sixth version
                public string Convert(int Input)
                {
                    if (Input % 3 == 0)
                        return "Fizz";
                    int temp = Input;
                    do
                    {
                        if (temp % 10 == 3)
                            return "Fizz";
                        temp /= 10;
                    } while (temp > 0);
                    return Input.ToString();
                }
        */
        /* fifth version
                public string Convert(int Input)
                {
                    if (Input % 3 == 0 || Input % 10 == 3)
                        return "Fizz";
                    return Input.ToString();
                }
        */
        /* fourth version
                public string Convert(int Input)
                {
                    if (Input % 3 == 0)
                        return "Fizz";
                    else
                        return Input.ToString();
                }
        */
        /* third version
                public string Convert(int Input)
                {
                    if (Input == 3)
                        return "Fizz";
                    return Input.ToString();
                }
        */
        /* second version
                public string Convert(int Input)
                {
                    return Input.ToString();
                }
        */
        /* first version
                public string Convert(int Input)
                {
                    return "1";
                }
        */
    }
}
