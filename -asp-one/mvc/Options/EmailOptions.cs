using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Options
{
    public class SmtpServer
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class EmailOptions
    {
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public SmtpServer SmtpServer { get; set; }
    }
}
