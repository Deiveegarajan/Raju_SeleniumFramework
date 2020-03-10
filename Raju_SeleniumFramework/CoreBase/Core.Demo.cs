namespace CoreBase
{
    public class CoreBase
    {
        public int UserValue { get; }
        public int UserCode { get; }

        public CoreBase(int userValue, int userCode)
        {
            UserValue = userValue;
            UserCode = userCode;
        }

        public int LoginSamplePage()
        {
            return UserValue *UserCode;
        }
    }
}

