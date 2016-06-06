using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmLib.Business.Core.Service
{
    public class MessageItem
    {
        public string Text { get; set; }
    }

    public  class MessageList
    {
        public List<MessageItem> Items { get; set; } = new List<MessageItem>();

        public void AddItem(string text)
        {
            Items.Add(new MessageItem
            {
                Text = text
            });
        }

        public bool HasItems()
        {
            return Items.Count > 0;
        }
    }
}
