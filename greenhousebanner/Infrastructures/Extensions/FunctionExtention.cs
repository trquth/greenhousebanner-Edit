namespace greenhousebanner.Infrastructures.Extensions
{
    public static class FunctionExtention
    {
        public static bool IsNull(this object value)
        {
            if (value == null)
                return true;
            return false;
        }

        public static bool IsNotNull(this object value)
        {
            return !value.IsNull();
        }
    }
}