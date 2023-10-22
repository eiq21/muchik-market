using Transaction.Application.Core.Messaging;
using Transaction.Domain.Abstractions;
using Transaction.Domain.Transactions;

namespace Transaction.Application.Features.Transactions.Commands;
internal sealed class CreateTransactionCommandHandler
: ICommandHandler<CreateTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionCommandHandler(
        ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Result> Handle(
        CreateTransactionCommand request,
        CancellationToken cancellationToken)
    {

        var transactionResult = Domain.Transactions.Transaction.Create(
            request.InvoiceId,
            request.Amount,
            request.CreatedOnUtc
        );

        _transactionRepository.Add(transactionResult.Value);

        await Task.FromResult(true);

        return Result.Success();
    }
}
