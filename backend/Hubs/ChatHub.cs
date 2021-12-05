using Microsoft.AspNetCore.SignalR;

namespace backend.Hubs
{
   public class ChatHub : Hub 
   {
      private readonly ILogger _logger;
      public ChatHub(ILogger<ChatHub> logger)
      {
         _logger = logger;
      }
      public async Task NewMessage(string username, string message)
      {
         _logger.LogInformation($"Got a new message from {username}: {message}");
	 await Clients.All.SendAsync("MessageReceived", username, message);
      }
   }
}
