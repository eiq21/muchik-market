using MediatR;
using Transaction.Domain.Abstractions;

namespace Transaction.Application.Core.Messaging;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
where TCommand : ICommand<TResponse>
{ }
