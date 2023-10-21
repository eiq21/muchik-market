using MediatR;
using Payment.Domain.Abstractions;

namespace Payment.Application.Core.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}