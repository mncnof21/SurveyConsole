using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SurveyConsole.Libs
{
    public class Helper
    {     
        // Convert String (ddMMyyyy) to Datetime
        public static Nullable<DateTime> ConvertDateFromString(String strdate, String separator)
        {
            try
            {
                String[] arrstring = strdate.Split(separator);
                var day = Convert.ToInt32(arrstring[0]);
                var month = Convert.ToInt32(arrstring[1]);
                var year = Convert.ToInt32(arrstring[2]);

                return new DateTime(year, month, day);
            }
            catch (Exception)
            {
                return null;
            }
        }        
    }
}
