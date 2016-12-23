using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Bvx
{

    public class Formatter
    {

        private static readonly NumberFormatInfo LengthFormat = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberDecimalDigits = 5 };

   
        private static readonly NumberFormatInfo AngleFormat = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberDecimalDigits = 3 };

    
        public static int LenghtDigits { get; set; }

 
        public static int AngleDigits { get; set; }

        public static string FormatLength(double value)
        {
            return value.ToString("F", LengthFormat);
        }

        public static string FormatAngle(double value)
        {
            return (value * 180 / Math.PI).ToString("F", AngleFormat);
        }

       
        public static string FormatAlignment(Operation.Alignment value)
        {
            return new string[] { "Center", "Left", "Right" }[(int)value];
        }
    }
}
