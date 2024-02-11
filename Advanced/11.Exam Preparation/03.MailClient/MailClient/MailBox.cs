using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            this.Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }


        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {   
            Mail mail = Inbox.FirstOrDefault(x => x.Sender == sender);
            if (mail != null)// && Inbox.Count<Capacity)
            {
                Inbox.Remove(mail);
                return true;
            }
            return false;
        }

        public int ArchiveInboxMessages()
        {
            int removedMails = 0;

            while (Inbox.Count>0)
            {
                Mail mail = Inbox.First();
                Inbox.Remove(mail);
                Archive.Add(mail);
                removedMails++;
            }
            
            return removedMails;
        }

        public string GetLongestMessage()
        {
            string longestMessage = "";
            Mail longestMail = null;
            foreach (Mail mail in Inbox) 
            {
                if (mail.Body.Length > longestMessage.Length)
                {
                    longestMessage = mail.Body;
                    longestMail = mail;
                }
            }
            return longestMail.ToString();
        }

        public string InboxView()
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            
            foreach (Mail mail in Inbox) 
            {
                sb.AppendLine(mail.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
