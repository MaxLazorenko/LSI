using LSI.Domain.Mappings;
using LSI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSI.Domain.Responses.DTO
{
    public class ReportDTO: IMapFrom<Report>
    {
        public string NameOfExport { get; set; }

        public DateTime? DateOfExport { get; set; }

        public string NameOfRoom { get; set; }

        public string UserName { get; set; }
    }
}
