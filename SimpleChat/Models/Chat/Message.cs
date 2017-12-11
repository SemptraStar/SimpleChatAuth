﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleChat.Models.Chat
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Sign { get; set; }

        public DateTime When { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
    }
}
