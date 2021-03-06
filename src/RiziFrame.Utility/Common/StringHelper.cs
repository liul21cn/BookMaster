﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RiziFrame.Utility.Common
{
    public static class StringHelper
    {
        // 判断是否数字
        public static bool IsNumeric(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                 !objTwoDotPattern.IsMatch(strNumber) &&
                 !objTwoMinusPattern.IsMatch(strNumber) &&
                 objNumberPattern.IsMatch(strNumber);

        }

        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?/d*$");
        }

        public static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^/d*[.]?/d*$");
        }
    }
}
