using LSI.Domain.Queries;
using LSI.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LSI.Controllers
{
    public class ResultController: Controller
    {
        private readonly IMediator _mediator;

        public ResultController(IMediator mediator) => _mediator = mediator;

        protected async Task<IActionResult> FromQueryResult<T>(IResultQueryRequest<T> query, 
                                                               CancellationToken token) where T : class
        {
            var mediatorResult = await _mediator.Send(query, token);
            if (!mediatorResult.Succeeded)
            {
                if (mediatorResult.Error.Type == ErrorType.NOT_FOUND)
                {
                    return new NotFoundObjectResult(mediatorResult.Error.Message);
                }
                return new BadRequestObjectResult(mediatorResult.Error.Message);
            }

            return new OkObjectResult(mediatorResult.Value);
        }

    }
}
