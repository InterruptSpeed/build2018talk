using System.Threading.Tasks;
using System.Threading.Channels;
using Microsoft.AspNetCore.SignalR;

namespace build2018talk.demo1 {
    public class ApplicationHub : Hub {
        public Task Send(ChatMessage message) {
            return Clients.All.SendAsync("Send", message.Message);
        }

        public ChannelReader<int> CountDown(int from) {
            var channel = Channel.CreateUnbounded<int>();

            _ = WriteToChannel(channel.Writer, from);

            return channel.Reader;

            async Task WriteToChannel(ChannelWriter<int> writer, int thing) {
                for (int i = thing - 1; i >= 0 ; i--)
                {
                    await writer.WriteAsync(i);
                    await Task.Delay(1000);
                }

                writer.Complete();
            }
        }
    }
}