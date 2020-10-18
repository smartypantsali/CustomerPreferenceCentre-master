namespace Framework.Common.Utilities
{
    public class ApiOffence
    {
        public string ErrorCode { get; set; }
		public ApiOffence(string errCode)
		{
			ErrorCode = errCode;
		}

		public static implicit operator ApiOffence(string errCode)
		{
			return new ApiOffence(errCode);
		}
	}
}
