using LSI.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace LSI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController: ResultController
    {
        public ReportsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public Task<IActionResult> GetReports([FromQuery] GetReportListQuery query,  
                                              CancellationToken token)
        {
            return FromQueryResult(query, token);
        }
    }
}
