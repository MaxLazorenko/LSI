using AutoMapper;
using LSI.Domain.Queries;
using LSI.Domain.Responses;
using LSI.Domain.Responses.DTO;
using LSI.Domain.Storage.Repository;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LSI.Domain.Handlers
{
    public class GetReportListQueryHandler : IRequestHandler<GetReportListQuery, Result<IEnumerable<ReportDTO>>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public GetReportListQueryHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ReportDTO>>> Handle(GetReportListQuery request, CancellationToken cancellationToken)
        {
            DateTime.TryParse(request.From, out var fromDate);
            DateTime.TryParse(request.To, out var toDate);

            var resultFromDb = await _reportRepository.GetReports(request.RoomName, fromDate, toDate, cancellationToken);

            if (!resultFromDb.Any())
                return Result.Failure("Can't found any reports");

            var mappedResult = _mapper.Map<IEnumerable<ReportDTO>>(resultFromDb);

            return Result.Ok(mappedResult);
        }
    }
}
