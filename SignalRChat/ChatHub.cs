using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        Random rand = new Random();
        public async Task SendMessage(string user, string message)
        {
            await Console.Out.WriteLineAsync("Testing");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task GetID(string user)
        {
            Console.WriteLine("GET ID CALLED");
            int id = rand.Next();
            await Clients.Caller.SendAsync("ReciveID", id);
        }
    }
}
