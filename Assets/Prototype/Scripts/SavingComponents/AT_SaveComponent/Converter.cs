using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Convertitore
{
  
    class Converter
    {
        //private string[] alphabet = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private char[] alphabet;
        public Converter()
        {
            alphabet = new char[36];
            for (byte bt = 48; bt<58; bt++)
            {
                char ch = Convert.ToChar(bt);
                int i = Convert.ToInt32(bt - 48);
                alphabet[i] = ch;
            }

            for (byte bt = 65; bt < 91; bt++)
            {
                char ch = Convert.ToChar(bt);
                int i = Convert.ToInt32(bt - 55);
                alphabet[i] = ch;
            }
        }

        public string FromTo(int from, int to, string number)
        {
            try
            {
                string num = number.ToUpper();

                if (Verify(from, num) == true)
                {
                    int dec;
                    string other;

                    if (from == 1)
                        dec = FromRoman(num);
                    else
                        dec = ToDecimal(from, num);

                    if (dec > 0 || dec < 65536)
                    {
                        if (to == 1)
                            other = ToRoman(dec);
                        else
                            other = FromDecimal(to, dec);

                        return other;
                    }
                    return "Value must be between 1 and 65536";
                }
                else
                    return "Invalid number or base";
            }
            catch { return "Error"; }
        }

        /// <summary>
        /// Convert from 2 - 36 bases to a decimal number
        /// </summary>
        /// <param name="from">Base to convert</param>
        /// <param name="number">Number to convert</param>
        /// <returns>Decimal number</returns>
        public int ToDecimal(int from, string number)
        {
            try
            {
                //      *Esempio*
                //7DE in esadecimale
                //7DE = (7 * 16^2) + (13 * 16^1) + (14 * 16^0)
                //7DE = (7 * 256) + (13 * 16) + (14 * 1) 
                //7DE = 1792 + 208 + 14 
                //7DE = 2014 in decimale
                
                string numReverse = Reverse(number);
                int numDec = 0;
                for (int i = 0; i < numReverse.Length; i++)
                {
                    int pos = SearchPos(numReverse.Substring(i, 1));
                    numDec += pos * Esp(from, i);
                }
                return numDec;
            }
            catch { return -1; }
        }

        /// <summary>
        /// Convert from decimal to 2 - 36 bases
        /// </summary>
        /// <param name="to">Base to convert</param>
        /// <param name="numDec">Number to convert</param>
        /// <returns></returns>
        public string FromDecimal(int to, int numDec)
        {
            try
            {
                if (to != 1)
                {
                    string result = "";
                    int number = numDec;

                    do
                    {
                        int remainder = number % to;
                        result += ToAlphabet(remainder);
                        number /= to;
                    }
                    while (number != 0);

                    return Reverse(result);
                }
                else
                    return ToRoman(numDec);
            }
            catch { return "Error"; }
        }

        public string ToRoman(int number)
        {
            if ((number < 0) || (number > 65536)) return "Value must be between 1 and 65536";
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            return "";
        }

        public int FromRoman(string number)
        {
            int result = 0;
            while (number != "")
            {
                if (number.Length > 0)
                    if (number.Substring(number.Length - 1, 1) == "I") { result += 1; number = number.Substring(0, number.Length - 1); }
                if (number.Length > 1)
                    if (number.Substring(number.Length - 2, 2) == "IV") { result += 4; number = number.Substring(0, number.Length - 2); }
                if (number.Length > 0)
                    if (number.Substring(number.Length - 1, 1) == "V") { result += 5; number = number.Substring(0, number.Length - 1); }
                if (number.Length > 1)
                    if (number.Substring(number.Length - 2, 2) == "IX") { result += 9; number = number.Substring(0, number.Length - 2); }
                if (number.Length > 0)
                    if (number.Substring(number.Length - 1, 1) == "X") { result += 10; number = number.Substring(0, number.Length - 1); }
                if (number.Length > 1)
                    if (number.Substring(number.Length - 2, 2) == "XL") { result += 40; number = number.Substring(0, number.Length - 2); }
                if (number.Length > 0)
                    if (number.Substring(number.Length - 1, 1) == "L") { result += 50; number = number.Substring(0, number.Length - 1); }
                if (number.Length > 1)
                    if (number.Substring(number.Length - 2, 2) == "XC") { result += 90; number = number.Substring(0, number.Length - 2); }
                if (number.Length > 0)
                    if (number.Substring(number.Length - 1, 1) == "C") { result += 100; number = number.Substring(0, number.Length - 1); }
                if (number.Length > 1)
                    if (number.Substring(number.Length - 2, 2) == "CD") { result += 400; number = number.Substring(0, number.Length - 2); }
                if (number.Length > 0)
                    if (number.Substring(number.Length - 1, 1) == "D") { result += 500; number = number.Substring(0, number.Length - 1); }
                if (number.Length > 1)
                    if (number.Substring(number.Length - 2, 2) == "CM") { result += 900; number = number.Substring(0, number.Length - 2); }
                if (number.Length > 0)
                    if (number.Substring(number.Length - 1, 1) == "M") { result += 1000; number = number.Substring(0, number.Length - 1); }
            }
            return result;
        }

        private int Esp(int number, int i)
        {
            int result = 1;
            if (i == 0)
                return result;
            else
                for (int j = 0; j < i; j++)
                    result *= number;
            return result;
        }

        private string Reverse(string s)
        {
            string result = "";
            for (int i = s.Length - 1; i > -1; i--)
                result += s.Substring(i, 1);
            return result;
        }


        private int SearchPos(string letter)
        {
            for (int i = 0; i < alphabet.Length; i++)
                if (letter == alphabet[i].ToString())
                    return i;
            return -1;
        }

        private string ToAlphabet(int number)
        {
            try
            {
                return alphabet[number].ToString();
            }
            catch { return "Error"; }
        }

        private bool Verify(int from, string number)
        {
            try
            {
                if (Convert.ToInt32(number) <= 0)
                    return false;
            }
            catch { }


            if (from == 1)
                for (int i = 0; i < number.Length; i++)
                {
                    string ch = number.Substring(i, 1);
                    if (ch != "I" && ch != "V" && ch != "X" && ch != "L" && ch != "C" && ch != "D" && ch != "M")
                        return false;
                }
            else
                for (int i = 0; i < number.Length; i++)
                    if ((SearchPos(number.Substring(i, 1)) > from - 1) || from < 1 || from > 36)
                        return false;
            return true;

        }

    }
}