using LSI.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSI.Domain.Queries
{
    public interface IResultQueryRequest<T>: IRequest<Result<IEnumerable<T>>>
    {
    }
}
