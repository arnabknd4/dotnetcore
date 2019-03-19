using System;
using System.Collections.Generic;
using System.Text;

namespace FMS_API_BAL
{
    /// <summary>
    /// Excel upload model and below order in Excel
    /// EventId - 0
    /// EventName - 1
    /// BeneficiaryName - 2
    /// BaseLocation - 3
    /// EventDate - 4
    /// EmplotyeeId - 5
    /// </summary>
    public class AssosiateFeedbackModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string BeneficiaryName { get; set; }
        public string BaseLocation { get; set; }
        public DateTime? EventDate { get; set; }
        public int EmplotyeeId { get; set; }
    }
}
