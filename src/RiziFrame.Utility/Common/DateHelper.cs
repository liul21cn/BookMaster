﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiziFrame.Utility.Common
{
    /// <summary>
    /// 日期方法类
    /// </summary>
    public static class DateHelper
    {
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期字符串</param>
        /// <param name="d2">要参与计算的另一个日期字符串</param>
        /// <returns>一个表示日期间隔的TimeSpan类型</returns>
        public static TimeSpan toResult(string d1, string d2)
        {
            try
            {
                DateTime date1 = DateTime.Parse(d1);
                DateTime date2 = DateTime.Parse(d2);
                return toResult(date1, date2);
            }
            catch
            {
                throw new Exception("字符串参数不正确!");
            }
        }
       
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期</param>
        /// <param name="d2">要参与计算的另一个日期</param>
        /// <returns>一个表示日期间隔的TimeSpan类型</returns>
        public static TimeSpan toResult(DateTime d1, DateTime d2)
        {
            TimeSpan ts;
            if (d1 > d2)
            {
                ts = d1 - d2;
            }
            else
            {
                ts = d2 - d1;
            }
            return ts;
        }
        
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期字符串</param>
        /// <param name="d2">要参与计算的另一个日期字符串</param>
        /// <param name="drf">决定返回值形式的枚举</param>
        /// <returns>一个代表年月日的int数组，具体数组长度与枚举参数drf有关</returns>
        public static int[] toResult(string d1, string d2, diffResultFormat drf)
        {
            try
            {
                DateTime date1 = DateTime.Parse(d1);
                DateTime date2 = DateTime.Parse(d2);
                return toResult(date1, date2, drf);
            }
            catch
            {
                throw new Exception("字符串参数不正确!");
            }
        }

        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期</param>
        /// <param name="d2">要参与计算的另一个日期</param>
        /// <param name="drf">决定返回值形式的枚举</param>
        /// <returns>一个代表年月日的int数组，具体数组长度与枚举参数drf有关</returns>
        public static int[] toResult(DateTime d1, DateTime d2, diffResultFormat drf)
        {
            #region 数据初始化
            DateTime max;
            DateTime min;
            int year;
            int month;
            int tempYear, tempMonth;
            if (d1 > d2)
            {
                max = d1;
                min = d2;
            }
            else
            {
                max = d2;
                min = d1;
            }
            tempYear = max.Year;
            tempMonth = max.Month;
            if (max.Month < min.Month)
            {
                tempYear--;
                tempMonth = tempMonth + 12;
            }
            year = tempYear - min.Year;
            month = tempMonth - min.Month;
            #endregion
            #region 按条件计算
            if (drf == diffResultFormat.dd)
            {
                TimeSpan ts = max - min;
                return new int[] { ts.Days };
            }
            if (drf == diffResultFormat.mm)
            {
                return new int[] { month + year * 12 };
            }
            if (drf == diffResultFormat.yy)
            {
                return new int[] { year };
            }
            return new int[] { year, month };
            #endregion
        }

        #region 常用日期
        public static DateTime dt = DateTime.Now;  //当前时间 
        public static DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一 
        public static DateTime endWeek = startWeek.AddDays(6);  //本周周日  

        public static DateTime ByFirstDay = dt.AddDays(1 - dt.Day);  //本月月初  
        public static DateTime ByEndDay = ByFirstDay.AddMonths(1).AddDays(-1);  //本月月末   

        public static DateTime SyFirstDay = ByFirstDay.AddMonths(-1);  //本月月初  
        public static DateTime SyEndDay = SyFirstDay.AddMonths(1).AddDays(-1);  //本月月末   

        public static DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);  //本季度初  
        public static DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末  

        public static DateTime BnFirstDay = new DateTime(dt.Year, 1, 1);  //本年年初  
        public static DateTime BnEndDay = new DateTime(dt.Year, 12, 31);  //本年年末

        public static DateTime QnFirstDay = DateTime.Parse(dt.ToString("yyyy-01-01")).AddYears(-1);  
        public static DateTime QnEndDay = DateTime.Parse(dt.ToString("yyyy-01-01")).AddDays(-1);  

        //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).ToShortDateString();   
        //DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).AddDays(-1).ToShortDateString(); 

        #endregion

    }
    


    /// <summary>
    /// 关于返回值形式的枚举
    /// </summary>
    public enum diffResultFormat
    {
        /// <summary>
        /// 年数和月数
        /// </summary>
        yymm,
        /// <summary>
        /// 年数
        /// </summary>
        yy,
        /// <summary>
        /// 月数
        /// </summary>
        mm,
        /// <summary>
        /// 天数
        /// </summary>
        dd,
    }
}
