using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System {
    public static class DateTimeExtensions {

        /// <summary>
        /// Return IST time assuming given date is UTC
        /// </summary>
        /// <param name="date">UTC Date</param>
        /// <returns></returns>
        public static DateTime ToIst(this DateTime date) {
            return date.AddHours(5).AddMinutes(30);
        }


    }
}
