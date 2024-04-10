using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core
{
    public class Notification
    {
        public Notification()
        {
            SendMessage = new List<string>();
        }

        [NotMapped]
        public List<string> SendMessage { get; set; }
    }
}