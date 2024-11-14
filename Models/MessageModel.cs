using System.Collections.Generic;

namespace Tiger_Tasks.Models
{
    // Model representing an individual message
    public class MessageModel
    {
        public string? MessageContent { get; set; } // Content of the message
        public string? Sender { get; set; } // Sender's name or ID
        public string? Timestamp { get; set; } // Timestamp for when the message was sent
    }

    // Model representing a direct conversation between two users
    public class DirectConversationModel
    {
        public DirectConversationModel(string user1, string user2)
        {
            User1 = user1;
            User2 = user2;
        }

        public string User1 { get; set; } // First user in the conversation
        public string User2 { get; set; } // Second user in the conversation
        public List<MessageModel> Messages { get; set; } = new List<MessageModel>(); // List of messages exchanged
    }
}
