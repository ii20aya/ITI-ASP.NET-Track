using ComplaintSystem.Data;
using ComplaintSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
namespace ComplaintSystem.Hubs
{
    

    [Authorize]
    public class ChatHub : Hub
    {
        private readonly AppDbContext _db;
        public ChatHub(AppDbContext db) => _db = db;

        public async Task JoinComplaintGroup(int complaintId)
            => await Groups.AddToGroupAsync(Context.ConnectionId, $"complaint-{complaintId}");

        public async Task SendMessage(int complaintId, string message)
        {
            var sender = Context.User?.Identity?.Name ?? "Unknown";

            var chat = new ChatMessage
            {
                ComplaintId = complaintId,
                SenderName = sender,
                Message = message,
                SentAt = DateTime.Now
            };
            _db.ChatMessages.Add(chat);
            await _db.SaveChangesAsync();

            await Clients.Group($"complaint-{complaintId}")
                .SendAsync("ReceiveMessage", sender, message, chat.SentAt.ToString("HH:mm"));
        }
    }
}
