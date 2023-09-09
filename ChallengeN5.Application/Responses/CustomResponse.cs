namespace ChallengeN5.Application.Responses
{
	public class CustomResponse<T>
	{
		public bool IsSuccess { get; set; }
		public int ResponseCode { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
	}
}

