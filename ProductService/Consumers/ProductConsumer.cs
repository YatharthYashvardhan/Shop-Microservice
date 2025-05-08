using MassTransit;
using ProductService.Model;
using System.Text.Json;

namespace ProductService.Consumers
{
    public class ProductConsumer : IConsumer<ProductModel>
    {
        public async Task Consume(ConsumeContext<ProductModel> context)
        {
            var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

            Console.WriteLine($"NotificationCreated event consumed. Message: {serializedMessage}");
        }
    }
}
