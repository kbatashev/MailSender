﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Lib.Entities
{
    public class Letter
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
