using GiTinder.Models;
using System;

namespace GiTinder.Tests.Models
{
    class MessageFactory
    {
        public static Message CreateValidMessage()
        {
            return new Message()
            {
                Id = 1,
                From = "Michel",
                To = "Raspoutine",
                CreatedAt = DateTime.Now,
                Content = "message"                
            };
        }

        public static Message MessageWithoutFrom()
        {
            var message = CreateValidMessage();
            message.From = null;
            return message;
        }

        public static Message MessageWithoutTo()
        {
            var message = CreateValidMessage();
            message.To = null;
            return message;
        }

        public static Message MessageWithoutContent()
        {
            var message = CreateValidMessage();
            message.Content = null;
            return message;
        }

    }
}
