using MediatR;
using Transaction.Domain.Abstractions;

namespace Transaction.Application.Core.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}