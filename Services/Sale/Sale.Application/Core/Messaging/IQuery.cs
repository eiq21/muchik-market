using MediatR;
using Sale.Domain.Abstractions;

namespace Sale.Application.Core.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
