using MassTransit;
using Messaging2.ViewModel;
using System.Threading.Tasks;

namespace Messaging2
{
    public class OrderConsumer :
       IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var data = context.Message;
            // message received.
        }
    }
}
