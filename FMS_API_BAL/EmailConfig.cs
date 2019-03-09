using System;
using System.Collections.Generic;
using System.Text;

namespace FMS_API_BAL
{
    public class EmailConfig
    {
        public string ToName { get; set; }
        public string ToEmailAddress { get; set; }
        public string Subject { get; set; }
        public string TextFormatter { get; set; }
        public string Body { get; set; }
    }
}
