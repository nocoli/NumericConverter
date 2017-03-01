using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericConverter;

namespace NumericConverter.Tests
{
    [TestClass]
    public class ConversionTests
    {
        // SET UP ARRAYS IDENTICLE TO THE ONES IN THE FORM
        string[] digits = { "ZERO ", "ONE ", "TWO ", "THREE ", "FOUR ", "FIVE ", "SIX ", "SEVEN ", "EIGHT ", "NINE ", };
        string[] teens = { "TEN ", "ELEVEN ", "TWELVE ", "THIRTEEN ", "FOURTEEN ", "FIFTEEN ", "SIXTEEN ", "SEVENTEEN ", "EIGHTEEN ", "NINETEEN " };
        string[] tens = { "TWENTY-", "THIRTY-", "FOURTY-", "FIFTY-", "SIXTY-", "SEVENTY-", "EIGHTY-", "NINETY-" };
        string[] units = { "HUNDRED ", "THOUSAND ", "MILLION " };


        // TESTS FOR THE "ForbiddenCharacters" method

        [TestMethod]
        public void CharacterInputTest1()
        {
            // the method second contraint is not tested
            var NumericConverter = new NumericConverter.Converter();
            bool chars = NumericConverter.ForbiddenCharacters("hello", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest2()
        {
            var NumericConverter = new NumericConverter.Converter();
            bool chars = NumericConverter.ForbiddenCharacters("h4sd55s2", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("s1111", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("10.25.23", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("jj#", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("7856!", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest7()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("654@", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest8()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("15.%", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest9()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("123$", 15.25);
            Assert.IsFalse(chars);
        }

        [TestMethod]
        public void CharacterInputTest10()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("550^.10", 15.25);
            Assert.AreEqual(chars, false);
        }

        [TestMethod]
        public void CharacterInputTest11()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("550.10", 15.25);
            Assert.IsTrue(chars);
        }

        [TestMethod]
        public void CharacterInputTest12()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("1", 15.25);
            Assert.IsTrue(chars);
        }

        [TestMethod]
        public void CharacterInputTest13()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("22458.05", 15.25);
            Assert.IsTrue(chars);
        }

        [TestMethod]
        public void CharacterInputTest14()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters(".35", 15.25);
            Assert.IsTrue(chars);
        }

        [TestMethod]
        public void CharacterInputTest15()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool chars = conversionWebSite.ForbiddenCharacters("6947.", 15.25);
            Assert.IsTrue(chars);
        }

        // TESTS FOR THE "RemoveLeading0s" method

        [TestMethod]
        public void Leading0sTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.RemoveLeading0s("01");
            Assert.AreEqual(value, "1");
        }

        [TestMethod]
        public void Leading0sTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.RemoveLeading0s("0000638");
            Assert.AreEqual(value, "638");
        }

        [TestMethod]
        public void Leading0sTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.RemoveLeading0s("0562030");
            Assert.AreEqual(value, "562030");
        }

        [TestMethod]
        public void Leading0sTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.RemoveLeading0s("1000005");
            Assert.AreEqual(value, "1000005");
        }

        [TestMethod]
        public void Leading0sTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.RemoveLeading0s("050505");
            Assert.AreEqual(value, "50505");
        }

        // TESTS FOR THE "EmptyString" method
        [TestMethod]
        public void EmptyStringTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool value = conversionWebSite.EmptyString("050505");
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void EmptyStringTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool value = conversionWebSite.EmptyString(".");
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void EmptyStringTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool value = conversionWebSite.EmptyString("");
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void EmptyStringTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool value = conversionWebSite.EmptyString(null);
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void EmptyStringTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            bool value = conversionWebSite.EmptyString(".25");
            Assert.IsFalse(value);
        }

        // TESTS FOR THE "Millions" method
        [TestMethod]
        public void MillionsTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Millions(2, digits, units);
            Assert.AreEqual(value, "TWO MILLION ");
        }

        [TestMethod]
        public void MillionsTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Millions(4, digits, units);
            Assert.AreEqual(value, "FOUR MILLION ");
        }

        [TestMethod]
        public void MillionsTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Millions(9, digits, units);
            Assert.AreEqual(value, "NINE MILLION ");
        }

        [TestMethod]
        public void MillionsTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Millions(0, digits, units);
            Assert.AreEqual(value, "ZERO MILLION ");
        }

        [TestMethod]
        public void MillionsTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Millions(7, digits, units);
            Assert.IsFalse(value == "SIX MILLION ");
        }

        // TESTS FOR THE "HundredThousands" method
        [TestMethod]
        public void HundredThousandsTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.HundredThousands(7, 8, 9, digits, units, 0);
            Assert.IsTrue(value != "SEVEN HUNDRED AND ");
            //Console.WriteLine(value);
        }

        [TestMethod]
        public void HundredThousandsTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.HundredThousands(1, 5, 1, digits, units, 0);
            Assert.IsTrue(value != "ONE HUNDRED AND ");
            //Console.WriteLine(value);
        }

        [TestMethod]
        public void HundredThousandsTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.HundredThousands(0, 5, 1, digits, units, 1);
            Assert.IsTrue(value == "");
            //Console.WriteLine(value);
        }

        [TestMethod]
        public void HundredThousandsTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.HundredThousands(9, 0, 3, digits, units, 0);
            Assert.IsTrue(value != "NINE HUNDRED AND ");
            //Console.WriteLine(value);
        }

        [TestMethod]
        public void HundredThousandsTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.HundredThousands(0, 0, 0, digits, units, 0);
            //Console.WriteLine(value);
            Assert.IsTrue(value == "" || value == null);
            //Console.WriteLine(value);
        }

        [TestMethod]
        public void HundredThousandsTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.HundredThousands(9, 0, 0, digits, units, 0);
            //Console.WriteLine(value);
            Assert.IsTrue(value == "NINE HUNDRED ");
        }

        // TESTS FOR THE "TenThousands" method
        [TestMethod]
        public void TenThousandsTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.TenThousands(5, 7, digits, tens, teens, 4);
            //Console.WriteLine(value);
            Assert.AreEqual(value, "FIFTY-");
        }

        [TestMethod]
        public void TenThousandsTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.TenThousands(0, 7, digits, tens, teens, 4);
            Assert.AreEqual(value, "SEVEN ");
        }

        [TestMethod]
        public void TenThousandsTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.TenThousands(7, 7, digits, tens, teens, 4);
            Assert.AreEqual(value, "SEVENTY-");
        }

        [TestMethod]
        public void TenThousandsTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.TenThousands(0, 0, digits, tens, teens, 4);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void TenThousandsTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.TenThousands(1, 0, digits, tens, teens, 4);
            Console.WriteLine(value);
            Assert.AreEqual(value, "TEN ");
        }

        [TestMethod]
        public void TenThousandsTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.TenThousands(1, 6, digits, tens, teens, 4);
            Console.WriteLine(value);
            Assert.AreEqual(value, "SIXTEEN ");
        }

        [TestMethod]
        public void TenThousandsTest7()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.TenThousands(0, 1, digits, tens, teens, 4);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ONE ");
        }

        // TESTS FOR THE "Thousands" method
        [TestMethod]
        public void ThousandsTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Thousands(5, 7, digits, units, 4);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIVE THOUSAND ");
        }

        [TestMethod]
        public void ThousandsTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Thousands(2, 8, digits, units, 4);
            Console.WriteLine(value);
            Assert.AreEqual(value, "TWO THOUSAND ");
        }

        [TestMethod]
        public void ThousandsTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Thousands(1, 7, digits, units, 4);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ONE THOUSAND ");
        }

        [TestMethod]
        public void ThousandsTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Thousands(1, 2, digits, units, 4);
            Console.WriteLine(value);
            Assert.IsFalse(value == "TWELVE THOUSAND ");
        }

        [TestMethod]
        public void ThousandsTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Thousands(0, 6, digits, units, 4);
            Console.WriteLine(value);
            Assert.IsTrue(value == "ZERO THOUSAND ");
        }

        [TestMethod]
        public void ThousandsTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Thousands(0, 3, digits, units, 4);
            Console.WriteLine(value);
            Assert.IsFalse(value == "THREE THOUSAND ");
        }

        // TESTS FOR THE "Hundreds" method
        [TestMethod]
        public void HundredsTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(5, 7, 3, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIVE HUNDRED AND ");
        }

        [TestMethod]
        public void HundredsTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(6, 0, 3, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "SIX HUNDRED AND ");
        }

        [TestMethod]
        public void HundredsTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(0, 7, 3, digits, units);
            Console.WriteLine(value);
            Assert.IsFalse(value == "SEVEN HUNDRED AND ");
        }

        [TestMethod]
        public void HundredsTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(1, 0, 1, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ONE HUNDRED AND ");
        }

        [TestMethod]
        public void HundredsTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(4, 0, 0, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FOUR HUNDRED ");
        }

        [TestMethod]
        public void HundredsTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(0, 0, 0, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void HundredsTest7()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(0, 1, 0, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "AND ");
        }

        [TestMethod]
        public void HundredsTest8()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(0, 0, 9, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "AND ");
        }

        [TestMethod]
        public void HundredsTest9()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Hundreds(9, 0, 9, digits, units);
            Console.WriteLine(value);
            Assert.AreEqual(value, "NINE HUNDRED AND ");
        }

        // TESTS FOR THE "Tens" method
        [TestMethod]
        public void TensTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(5, 7, tens, teens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIFTY-");
        }

        [TestMethod]
        public void TensTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(8, 9, tens, teens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "EIGHTY-");
        }

        [TestMethod]
        public void TensTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(1, 7, tens, teens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "SEVENTEEN ");
        }

        [TestMethod]
        public void TensTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(1, 2, tens, teens);
            Console.WriteLine(value);
            Assert.IsTrue(value == "TWELVE ");
        }

        [TestMethod]
        public void TensTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(1, 0, tens, teens);
            Console.WriteLine(value);
            Assert.IsTrue(value == "TEN ");
        }

        [TestMethod]
        public void TensTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(0, 2, tens, teens);
            Console.WriteLine(value);
            Assert.IsTrue(value == "");
        }

        [TestMethod]
        public void TensTest7()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(0, 6, tens, teens);
            Console.WriteLine(value);
            Assert.IsTrue(value == "");
        }

        [TestMethod]
        public void TensTest8()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(0, 8, tens, teens);
            Console.WriteLine(value);
            Assert.IsFalse(value == "EIGHTY" || value == "EIGHTEEN");
        }

        [TestMethod]
        public void TensTest9()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Tens(0, 5, tens, teens);
            Console.WriteLine(value);
            Assert.IsFalse(value == "ZER0 ");
        }

        // TESTS FOR THE "Ones" method
        [TestMethod]
        public void OnesTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(5, 7, digits, 1);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIVE ");
        }

        [TestMethod]
        public void OnesTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(8, 9, digits, 1);
            Console.WriteLine(value);
            Assert.AreEqual(value, "EIGHT ");
        }

        [TestMethod]
        public void OnesTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(5, 7, digits, 2);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIVE ");
        }

        [TestMethod]
        public void OnesTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(2, 3, digits, 1);
            Console.WriteLine(value);
            Assert.IsTrue(value == "TWO ");
        }

        [TestMethod]
        public void OnesTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(2, 3, digits, 0);
            Console.WriteLine(value);
            Assert.AreEqual(value, "TWO ");
        }

        [TestMethod]
        public void OnesTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(2, 1, digits, 0);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest7()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(9, 1, digits, 0);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest8()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(2, 0, digits, 0);
            Console.WriteLine(value);
            Assert.AreEqual(value, "TWO ");
        }

        [TestMethod]
        public void OnesTest9()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(0, 1, digits, 0);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest10()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(0, 5, digits, 0);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest11()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(5, 1, digits, 2);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest12()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(1, 1, digits, 2);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest13()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(1, 1, digits, 1);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ONE ");
        }

        [TestMethod]
        public void OnesTest14()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(1, 1, digits, 0);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest15()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(0, 0, digits, 2);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void OnesTest16()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.Ones(0, 1, digits, 1);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ZERO ");
        }

        // TESTS FOR THE "CalculateDecimal" method
        [TestMethod]
        public void DecimalTest1()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("15", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIFTEEN ");
        }

        [TestMethod]
        public void DecimalTest2()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("17", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "SEVENTEEN ");
        }

        [TestMethod]
        public void DecimalTest3()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("15", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIFTEEN ");
        }

        [TestMethod]
        public void DecimalTest4()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("05", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIVE ");
        }

        [TestMethod]
        public void DecimalTest5()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("09", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "NINE ");
        }

        [TestMethod]
        public void DecimalTest6()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("00", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ZERO ");
        }

        [TestMethod]
        public void DecimalTest7()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("5", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIFTY-");
        }

        [TestMethod]
        public void DecimalTest8()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("2", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "TWENTY-");
        }

        [TestMethod]
        public void DecimalTest9()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("0", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "");
        }

        [TestMethod]
        public void DecimalTest10()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("00", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ZERO ");
        }

        [TestMethod]
        public void DecimalTest11()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("11", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "ELEVEN ");
        }

        [TestMethod]
        public void DecimalTest12()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("19", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "NINETEEN ");
        }

        [TestMethod]
        public void DecimalTest13()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("17", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "SEVENTEEN ");
        }

        [TestMethod]
        public void DecimalTest14()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("25", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "TWENTY-FIVE");
        }

        [TestMethod]
        public void DecimalTest15()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("55", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "FIFTY-FIVE");
        }

        [TestMethod]
        public void DecimalTest16()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("00", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.IsFalse(value == "ZERO ZERO");
        }

        [TestMethod]
        public void DecimalTest17()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("90", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "NINETY-ZERO");
        }

        [TestMethod]
        public void DecimalTest18()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("03", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "THREE ");
        }

        [TestMethod]
        public void DecimalTest19()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("03", 2, digits, teens, tens);
            Console.WriteLine(value);
            Assert.IsFalse(value == "ZERO THREE ");
        }

        [TestMethod]
        public void DecimalTest20()
        {
            var conversionWebSite = new NumericConverter.Converter();
            string value = conversionWebSite.CalculateDecimal("90", 1, digits, teens, tens);
            Console.WriteLine(value);
            Assert.AreEqual(value, "NINETY-ZERO");
        }

    }
}

