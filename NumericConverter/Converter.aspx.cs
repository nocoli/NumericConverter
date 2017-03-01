using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumericConverter
{
    public partial class Converter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            // take string input
            string stringInput = TextBox1.Text;

            // count forbidden characters in string
            double errorCount = 0;
            bool isNumeric = ForbiddenCharacters(stringInput, errorCount);

            // is the input empty
            bool isEmpty = EmptyString(stringInput);

            // if the input box is empty or null
            if (isEmpty)
            {
                Response.Write("<script>alert('Input is empty');</script>");
            }
            // if the input is in the incorrect format
            else if (!isNumeric)
            {
                Response.Write("<script>alert('Input contains forbidden characters. Only digits \"0-9\" and a single \".\" to indicate a decimal are accepted');</script>");
                Label1.Text = "Input contains forbidden characters.";
            }
            else if(stringInput.Length > 7 && !stringInput.Contains('.'))
            {
                Response.Write("<script>alert('Maximum input is 9,999,999.99');</script>");
            }
            else
            {
                // Remove any leading 0's
                // eg: 057.15 -> 57.15, 0002 -> 2 
                stringInput = RemoveLeading0s(stringInput);

                // convert string input to double
                double numericConversion = Convert.ToDouble(stringInput);

                // strings to write answers to
                string answerWhole = "DOLLARS";
                string answerDec = "";

                // boolean checking if there is a decimal
                bool dec = stringInput.Contains('.');

                // set up all number strings needed to construct numbers as worded strings
                string[] digits = { "ZERO ", "ONE ", "TWO ", "THREE ", "FOUR ", "FIVE ", "SIX ", "SEVEN ", "EIGHT ", "NINE ", };
                string[] teens = { "TEN ", "ELEVEN ", "TWELVE ", "THIRTEEN ", "FOURTEEN ", "FIFTEEN ", "SIXTEEN ", "SEVENTEEN ", "EIGHTEEN ", "NINETEEN " };
                string[] tens = { "TWENTY-", "THIRTY-", "FOURTY-", "FIFTY-", "SIXTY-", "SEVENTY-", "EIGHTY-", "NINETY-" };
                string[] units = { "HUNDRED ", "THOUSAND ", "MILLION " };

                // the number without the decimal, the value of the deciaml
                double inputWithoutDecimal;
                double decimalCount;

                // splits the input by the decimal
                string[] decSplit = stringInput.Split('.');

                // if there is a decimal
                if (dec)
                {
                    // set decimal
                    decimalCount = Convert.ToDouble(decSplit[1]);
                    // set the whole number (no decimal)
                    inputWithoutDecimal = Math.Floor(numericConversion);
                }
                else
                {
                    // set the whole number (no decimal)
                    inputWithoutDecimal = numericConversion;
                    // set decimal to 0 to show there is no remainder
                    decimalCount = 0;
                }

                // whole number length
                double temp = inputWithoutDecimal.ToString().Length;
                // number length (how many sections of 3)
                double temp2 = temp / 3;
                // how many full sections
                double temp3 = Math.Floor(temp2);

                // for each index of the input
                for (int j = Convert.ToInt32(temp); j > 0; j--)
                {
                    // int value of the input string index[j]
                    int val = (int)Char.GetNumericValue(stringInput[j - 1]);

                    // solving for the millions digit
                    if (temp > 6 && j == temp - 6)
                    {
                        // write the millions to the answer string
                        string millions = Millions(val, digits, units);
                        answerWhole = answerWhole.Insert(0, millions);
                    }

                    // solving for the hundreds of thousands digit
                    if (temp > 5 && j == temp - 5)
                    {
                        // set digits 1 to the right and 2 to the right of current index
                        int val2 = (int)Char.GetNumericValue(stringInput[j]);
                        int val3 = (int)Char.GetNumericValue(stringInput[j + 1]);

                        // write hundreds of thousands to answer string
                        string hundredsThousands = HundredThousands(val, val2, val3, digits, units, j);
                        answerWhole = answerWhole.Insert(0, hundredsThousands);
                    }

                    // solving for the tens of thousands digit
                    if (temp > 4 && j == temp - 4)
                    {
                        // set digits 1 to the right of the current index
                        int val2 = (int)Char.GetNumericValue(stringInput[j]);

                        // write tens of thousands to answer string
                        string tensThousands = TenThousands(val, val2, digits, tens, teens, j);
                        answerWhole = answerWhole.Insert(0, tensThousands);
                    }

                    // solving for the thousands digit
                    if (temp > 3 && j == temp - 3)
                    {
                        // setting the index 1 plae to the left
                        int val3 = (int)Char.GetNumericValue(stringInput[j - 1]);

                        // writing the thousands to answer string
                        string thousands = Thousands(val, val3, digits, units, Convert.ToInt32(temp));
                        answerWhole = answerWhole.Insert(0, thousands);
                    }

                    // solving for the hundreds digit
                    if (temp > 2 && j == temp - 2)
                    {
                        // set digits 1 to the right of the current index
                        int val2 = (int)Char.GetNumericValue(stringInput[j]);
                        // set digits 2 to the right of the current index
                        int val3 = (int)Char.GetNumericValue(stringInput[j + 1]);

                        // writing the hundreds to answer string
                        string hundreds = Hundreds(val, val2, val3, digits, units);
                        answerWhole = answerWhole.Insert(0, hundreds);
                    }

                    // solving for the tens digit
                    if (temp > 1 && j == temp - 1)
                    {
                        // set digits 1 to the right of the current index
                        int val2 = (int)Char.GetNumericValue(stringInput[j]);

                        // writing the tens to the answer string
                        string tens_string = Tens(val, val2, tens, teens);
                        answerWhole = answerWhole.Insert(0, tens_string);
                    }

                    // solving for the ones digit
                    if (temp > 0 && j == temp)
                    {
                        int val2;
                        if (temp > 1)
                        {
                            // set digits 1 to the left of the current index
                            val2 = (int)Char.GetNumericValue(stringInput[j - 2]);
                        }
                        else
                        {
                            // place holder - will not be used
                            val2 = 1;
                        }

                        // writing the ones to the answer string
                        string onesString = Ones(val, val2, digits, temp);
                        answerWhole = answerWhole.Insert(0, onesString);
                    }
                }

                // if there is a decimal to display
                if (dec)
                {
                    // set the decimal to a string and its length
                    string temp_dec = decSplit[1];
                    int decimalLength = decSplit[1].Length;

                    // add string decimal to the answerDec (decimal answer)
                    string decimalString = CalculateDecimal(decSplit[1], decimalCount, digits, teens, tens);
                    answerDec = answerDec.Insert(0, decimalString);

                }

                // if there is no decimal to display
                if (answerDec.Length < 1)
                {
                    // remove the s from dollars if answer = 1 dollar
                    if (answerWhole == "ONE DOLLARS")
                    {
                        answerWhole = answerWhole.Remove(answerWhole.Length - 1);
                    }

                    // set output to labels text
                    Label1.Text = answerWhole;
                }
                // if there is a decimal to display, format output correctly
                else
                {
                    // remove the s from dollars if answer = 1 dollar
                    if (answerWhole == "ONE DOLLARS")
                    {
                        answerWhole = answerWhole.Remove(answerWhole.Length - 1);
                    }
                    if (answerDec == "ONE ")
                    {
                        answerDec = answerDec.Remove(answerDec.Length - 1);
                        Label1.Text = answerWhole + " AND " + answerDec + " CENT";
                    }
                    else
                    {
                        Label1.Text = answerWhole + " AND " + answerDec + " CENTS";
                    }
                }
            }
        }

        // returns true if there are forbidden characters in the input
        public bool ForbiddenCharacters(string input, double errors)
        {
            return double.TryParse(input, out errors); ;
        }

        // returns true if string input is empty
        public bool EmptyString(string input)
        {
            if (input == null || input == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Removes leading 0's infront of a number
        public string RemoveLeading0s(string input)
        {
            double tempDouble = Convert.ToDouble(input);
            return tempDouble.ToString();
        }

        // Writes the millions to answer string
        public string Millions(int value, string[] digits, string[] units)
        {
            // return "'x' MILLIONS"
            return digits[value] + units[2];
        }

        // calculates and returns the value of the hundreds of thoudsands digit
        public string HundredThousands(int value, int value2, int value3, string[] digits, string[] units, int index)
        {
            if (value == 0)
            {
                // return nothing
                return "";

            }
            // if value not equal to 0
            else
            {
                string tempString = "";

                // if tens of thousands digit equals 0
                if (value2 == 0)
                {
                    // if thousands digit is equal to 0 eg: 100,455
                    if (value3 == 0)
                    {
                        tempString = tempString.Insert(0, digits[value] + units[0]);
                        return tempString;
                    }
                    // if thousands digit is not equal to 1 eg: 103,245
                    else
                    {
                        tempString = tempString.Insert(0, digits[value] + units[0] + " AND ");
                        return tempString;
                    }
                }
                // if tens of thousands digit is not equal to 0. eg: 150,658
                else
                {
                    tempString = tempString.Insert(0, digits[value] + units[0] + " AND ");
                    return tempString;
                }
            }
        }

        // calculate and return the value of the tens of thousands digit
        public string TenThousands(int value, int value2, string[] digits, string[] tens, string[] teens, int index)
        {
            // if tens of thousands digit equals 1
            if (value == 1)
            {
                // return teen value eg: 115,365 returns "FIFTEEN"
                return teens[value2];
            }
            // if tens of thousands digit equals 0
            else if (value == 0)
            {
                // if thousands digit does not equal 0
                if (value2 != 0)
                {
                    return digits[value2];
                }
                else
                {
                    // return nothing
                    return "";
                }
            }
            // if tens of thousands digit not equal to 0 and not equal to 1
            else
            {
                // return tens value. eg: 52,356 returns "FIFTY"
                return tens[value - 2];
            }
        }

        // calculate and return the value of the thousands digit
        public string Thousands(int value, int value3, string[] digits, string[] units, int length)
        {
            // set temp string
            string tempString = "";

            // if input has a length of 4 (answerWhole is in thousands eg: "1234")
            if (length == 4)
            {
                // write thousand and digit value
                tempString = tempString.Insert(0, digits[value] + units[1]);

            }
            // if input has a length greater than 4
            else
            {
                // if value is in the tens
                if (value3 == 1)
                {
                    // write thousand only
                    tempString = tempString.Insert(0, units[1]);
                }
                else
                {
                    // if thousands digit equal to 0
                    if (value == 0)
                    {
                        // write thousands. eg: 10,123
                        tempString = tempString.Insert(0, units[1]);
                    }
                    // if thousands digit not equal to 0
                    else
                    {
                        // write digit and thousndand value. eg: 25,345
                        tempString = tempString.Insert(0, digits[value] + units[1]);
                    }
                }
            }

            // return constructed thousands string
            return tempString;
        }

        // calculate and return the value of the hundreds digit
        public string Hundreds(int value, int value2, int value3, string[] digits, string[] units)
        {
            string tempString = "";
            // if hundreds digit equal to 0
            if (value == 0)
            {
                // if tens digit is not equal to 0
                if (value2 != 0)
                {
                    tempString = tempString.Insert(0, "AND ");
                }
                // if ones digit is not equal to 0
                else if (value3 != 0)
                {
                    tempString = tempString.Insert(0, "AND ");
                }
            }
            else
            {
                // if tens digit is equal to 0
                if (value2 == 0)
                {
                    // if ones digit is equal to 0
                    if (value3 != 0)
                    {
                        tempString = tempString.Insert(0, "AND ");
                    }
                    tempString = tempString.Insert(0, digits[value] + units[0]);
                }
                else
                {
                    tempString = tempString.Insert(0, digits[value] + units[0] + "AND ");
                }
            }

            return tempString;
        }

        // calculates and returns the value of the tens digit
        public string Tens(int value, int value2, string[] tens, string[] teens)
        {
            string tempString = "";

            // if tens digit is equal to 1
            if (value == 1)
            {
                // write teen value. eg: eleven, seventeen
                tempString = tempString.Insert(0, teens[value2]);
            }
            else if (value != 0)
            {
                // write tens value. eg: fifty, twenty
                tempString = tempString.Insert(0, tens[value - 2]);
            }

            // return contructed tens string
            return tempString;
        }

        // calculate and return the value of the ones digit
        public string Ones(int value, int value2, string[] digits, double length)
        {
            string tempString = "";
            // need to be able to write for single numeric digit, eg: 1, 2, 5, 8
            if (length == 1)
            {
                tempString = tempString.Insert(0, digits[value]);
            }
            else if (length == 2)
            {
                // if ones digit is not equal to 0
                if (value != 0)
                {
                    // if not in the teens
                    if (value2 != 1)
                    {
                        tempString = tempString.Insert(0, digits[value]);
                    }
                }

            }
            else
            {
                // if value is not in the tens
                if (value2 != 1 && value != 0)
                {
                    // write thousand and digit value
                    tempString = tempString.Insert(0, digits[value]);
                }
            }
            return tempString;
        }

        // calculate and return the decimal value
        public string CalculateDecimal(string decimal_values, double decimal_count, string[] digits, string[] teens, string[] tens)
        {
            string decString = "";

            int decimal_length = decimal_values.Length;
            int valDec0 = (int)Char.GetNumericValue(decimal_values[0]);

            if (decimal_length == 1)
            {
                // value of the first char in the decimal
                if (valDec0 == 1)
                {
                    decString = decString.Insert(0, teens[valDec0 - 1]);
                }
                else if (valDec0 == 0)
                {
                    // add nothing
                }
                else
                {
                    decString = decString.Insert(0, tens[valDec0 - 2]);
                }
            }
            if (decimal_length >= 2)
            {
                int valDec1 = (int)Char.GetNumericValue(decimal_values[1]);
                string str_valDec0 = Convert.ToString(valDec0);
                string str_valDec1 = Convert.ToString(valDec1);

                if (str_valDec0 == "1")
                {
                    decString = decString.Insert(0, teens[Convert.ToInt32(str_valDec1)]);
                }
                else if (str_valDec0 == "0")
                {
                    decString = decString.Insert(0, digits[Convert.ToInt32(str_valDec1)]);
                }
                else
                {
                    // add values of the decimal to the decString to be returned 
                    decString = decString.Insert(0, tens[Convert.ToInt32(valDec0) - 2] + digits[Convert.ToInt32(str_valDec1)]);
                    decString = decString.Remove(decString.Length - 1);
                }
            }

            // return string value of the decimal
            return decString;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}