using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System {
    public static class StringExtensions {
        public static IEnumerable<string> CsvToArray(this string stringData) {
            if (stringData == null)
                return new List<string>();
            return stringData.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ArrayToCsv(this IEnumerable<string> csvData) {
            if (csvData == null || csvData.Count() == 0)
                return string.Empty;

            return string.Join(",", csvData);
        }
    }
}
