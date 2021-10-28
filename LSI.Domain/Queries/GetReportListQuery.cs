using LSI.Domain.Responses.DTO;
using MediatR;
using System;

namespace LSI.Domain.Queries
{
    public class GetReportListQuery: IResultQueryRequest<ReportDTO>
    {
        public string RoomName { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}