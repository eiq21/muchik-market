using MediatR;
using Payment.Domain.Abstractions;

namespace Payment.Application.Core.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
