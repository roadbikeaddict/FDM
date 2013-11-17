using System.Collections.Generic;

namespace FDM
{
    public class MessageQueue
    {
        // ReSharper disable InconsistentNaming
        private readonly Queue<Message> messages;
        // ReSharper restore InconsistentNaming

        public MessageQueue()
        {
            messages = new Queue<Message>();
        }

        public void AddMessage(Message msg)
        {
            messages.Enqueue(msg);
        }

        public void AddMessage(string text)
        {
            var msg = new Message
                {
                    Text = text,
                    MessageId = GetCurrentMessageId() + 1,
                    SubSystem = "FDM",
                    Type = MessageType.eText
                };
            messages.Enqueue(msg);
        }

        public void AddMessage(string text, bool bVal)
        {
            var msg = new Message
                {
                    Text = text,
                    MessageId = GetCurrentMessageId() + 1,
                    SubSystem = "FDM",
                    Type = MessageType.eBool,
                    BVal = bVal
                };
            messages.Enqueue(msg);
        }

        private int GetCurrentMessageId()
        {
            var currentMessageId = -1;
            if (messages.Count > 0)
            {
                currentMessageId = messages.Peek().MessageId;
            }
            return currentMessageId;
        }

        public void AddMessage(string text, int iVal)
        {
            var msg = new Message
                {
                    Text = text,
                    MessageId = GetCurrentMessageId() + 1,
                    SubSystem = "FDM",
                    Type = MessageType.eInteger,
                    BVal = (iVal != 0)
                };
            messages.Enqueue(msg);
        }


        public void AddMessage(string text, double dVal)
        {
            var msg = new Message
                {
                    Text = text,
                    MessageId = GetCurrentMessageId() + 1,
                    SubSystem = "FDM",
                    Type = MessageType.eDouble,
                    BVal = (dVal != 0.0)
                };
            messages.Enqueue(msg);
        }

        public bool IsMessageQueueEmpty()
        {
            return messages.Count <= 0;
        }

        public Message GetMessage()
        {
            Message retVal = null;
            if (!IsMessageQueueEmpty())
            {
                retVal = messages.Dequeue();
            }
            return retVal;
        }

    }
}