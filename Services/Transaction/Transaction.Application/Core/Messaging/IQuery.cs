using MediatR;
using Transaction.Domain.Abstractions;

namespace Transaction.Application.Core.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
