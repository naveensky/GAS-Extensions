namespace System {
    public static class NumericExtensions {
        public static double ToDouble(this decimal @decimal) {
            return Convert.ToDouble(@decimal);
        }

        public static decimal ToDecimal(this double @double) {
            return Convert.ToDecimal(@double);
        }

        public static decimal Roundup(this decimal @decimal) {
            return Decimal.Round(@decimal, 2);
        }

        public static decimal Roundup(this decimal @decimal, int decimalPlace) {
            return Decimal.Round(@decimal, decimalPlace);
        }
    }
}