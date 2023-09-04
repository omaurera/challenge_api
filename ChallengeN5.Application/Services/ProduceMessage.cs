using System;
using ChallengeN5.Application.Responses;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace ChallengeN5.Application.Services
{
	public class ProduceMessage : IProduceMessage
	{
        public async Task CreateMessage(KafkaResponse kafkaResponse)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = "challenge-app",
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };
            using
            var producer = new ProducerBuilder<Null, string>(config).Build();
            var message = new Message<Null, string>
            {
                Value = JsonConvert.SerializeObject(kafkaResponse)
            };
            var deliveryReport = await producer.ProduceAsync("challenge-topic", message);
        }
    }
}

