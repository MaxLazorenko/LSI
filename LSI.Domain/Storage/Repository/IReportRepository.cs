using LSI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LSI.Domain.Storage.Repository
{
    public interface IReportRepository
    {
        public Task<List<Report>> GetReports(string room, DateTime? dateFrom, DateTime? dateTo, CancellationToken cancellationToken);
    }
}
