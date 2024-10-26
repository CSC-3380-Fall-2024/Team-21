using Microsoft.AspNetCore.Mvc;
using Tiger_Tasks.Models; // Namespace where your models are defined
using System.Collections.Generic;

namespace Tiger_Tasks.Controllers
{
    public class MessageController : Controller
    {
        // Temporary data structure for simulating messages (replace with database interaction later)
        private static List<DirectConversationModel> conversations = new List<DirectConversationModel>();

        // Action method to load the messaging page
        public IActionResult Index()
        {
            // Load and display all conversations (for now, just return a view)
            return View(conversations);
        }

        // Action method to start a new direct conversation
        public IActionResult StartConversation(string user1, string user2)
        {
            var conversation = new DirectConversationModel(user1, user2);
            conversations.Add(conversation);
            return RedirectToAction("Index");
        }

        // Action method to send a message in an existing conversation
        public IActionResult SendMessage(string user1, string user2, string messageContent)
        {
            var conversation = conversations.Find(c => c.User1 == user1 && c.User2 == user2);
            if (conversation != null)
            {
                // Add a message to the conversation
                conversation.Messages.Add(new MessageModel
                {
                    MessageContent = messageContent,
                    Sender = user1, // Assuming user1 is the sender for now
                    Timestamp = System.DateTime.Now.ToString() // Current timestamp
                });
            }
            return RedirectToAction("Index");
        }
    }
}
