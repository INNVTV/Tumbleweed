using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tumbleweed.Models
{
    public class WaitingListModel
    {
        public string Email { get; set; }
        public DateTimeOffset SignUpDate { get; set; }
    }
}