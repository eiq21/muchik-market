using MediatR;
using Transaction.Domain.Abstractions;

namespace Transaction.Application.Core.Messaging;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{

}
