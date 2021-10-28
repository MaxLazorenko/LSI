using LSI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LSI.Domain.Storage.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportContext _reportContext;

        public ReportRepository(ReportContext reportContext)
        {
            _reportContext = reportContext;
        }

        public async Task<List<Report>> GetReports(string room, DateTime dateFrom, DateTime? dateTo, CancellationToken cancellationToken)
        {
            var reportsQuery = _reportContext.Reports.AsQueryable()
                                                     .AsNoTracking()
                                                     .Where(_ => _.NameOfRoom == room && _.DateOfExport >= dateFrom);

            if (dateTo.HasValue)
            {
                reportsQuery = reportsQuery.Where(_ => _.DateOfExport >= dateFrom && _.DateOfExport <= dateTo);
            }


            return await reportsQuery.ToListAsync(cancellationToken);
        }
    }
}
