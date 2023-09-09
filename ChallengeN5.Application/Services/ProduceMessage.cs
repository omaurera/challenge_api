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
                BootstrapServers = "pkc-6ojv2.us-west4.gcp.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "J7VSE4U42DD6UY3M",
                SaslPassword = "4y1DfTgZkw4J5Q4Eu9mAGLQ7ZQQFWr4qlfvgNKY/osCUkwr5KYy/EQTnBXASVO7g"
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

