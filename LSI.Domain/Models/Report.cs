using System;

namespace LSI.Domain.Models
{
    public class Report: BaseEntity<Guid>
    {
        
        public string NameOfExport { get; set; }
        
        public DateTime? DateOfExport { get; set; }
        
        public string NameOfRoom { get; set; }
        
        public string UserName { get; set; }
    }
}