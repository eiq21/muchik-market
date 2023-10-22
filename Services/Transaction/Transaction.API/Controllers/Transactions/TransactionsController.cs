using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Features.Transactions.Commands;

namespace Transaction.API.Controllers.Transactions;

[ApiController]
[Route("api/transactions")]
public class TransactionsController : ControllerBase
{
    private readonly ISender _sender;
    public TransactionsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> Create(
            CreateTransactionRequest request,
            CancellationToken cancellationToken
        )
    {
        var command = new CreateTransactionCommand(
            request.InvoiceId,
            request.Amount,
            request.CreatedOnUtc
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return NoContent();
    }
}
