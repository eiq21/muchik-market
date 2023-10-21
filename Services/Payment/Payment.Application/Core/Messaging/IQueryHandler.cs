using MediatR;
using Payment.Domain.Abstractions;

namespace Payment.Application.Core.Messaging;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}
