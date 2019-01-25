using System;
using System.Collections.Generic;

namespace PayloadPost.Models
{
    public class AlertNotificationViewModel
    {
        public string KeeperName { get; set; }
        public string AffectedSystem { get; set; }
        public string ErrorDetail { get; set; }
        public DateTime OccurrenceDateTime { get; set; }
        public string TicketLink { get; set; }
    }
}
