using MediatR;
using Sale.Domain.Abstractions;

namespace Sale.Application.Core.Messaging;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}
