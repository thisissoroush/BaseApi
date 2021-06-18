using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Communication.Models.Email
{
    public class EmailModel
    {
        public string MailServer { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Provider { get; set; }

    }
}
