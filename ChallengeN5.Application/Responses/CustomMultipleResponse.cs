namespace ChallengeN5.Application.Responses
{
	public class CustomMultipleResponse<T>
	{
        public bool IsSuccess { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}

