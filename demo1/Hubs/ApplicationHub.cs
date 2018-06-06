using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace demo1 {
    public class ApplicationHub : Hub {
        public Task Send(ChatMessage message) {
            return Clients.All.SendAsync("Send", message.Message);
        }
    }
}