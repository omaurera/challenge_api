using ChallengeN5.Application.Responses;

namespace ChallengeN5.Application.Services
{
	public interface IProduceMessage
	{
        Task CreateMessage(KafkaResponse kafkaResponse);
    }
}

