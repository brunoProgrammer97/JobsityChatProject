﻿using System;

namespace JobsityChatProject.Core.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
    }
}
