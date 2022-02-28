using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsityChatProject.Core.Models
{
    public class ChatMessage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; private set; }
        public string Message { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
    }
}
