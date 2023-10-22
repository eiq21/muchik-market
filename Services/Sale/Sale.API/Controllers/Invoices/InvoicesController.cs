using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sale.Application.Features.Invoices.Commands.CreateInvoice;
using Sale.Application.Features.Invoices.Commands.PayInvoice;
using Sale.Application.Features.Invoices.Queries.GetInvoices;

namespace Sale.API.Controllers.Invoices;

[ApiController]
[Route("api/invoices")]
public class InvoicesController : ControllerBase
{
    private readonly ISender _sender;
    public InvoicesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(
        CreateInvoiceRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new CreateInvoiceCommand(
             request.Amount
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return NoContent();
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken
    )
    {
        var query = new GetInvoicesQuery();

        var result = await _sender.Send(query, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

   // [HttpPatch("pay/{id}")]
   // public async Task<IActionResult> Pay(
   //    Guid id,
   //    CancellationToken cancellationToken
   //)
   // {
   //     var query = new PayInvoiceCommand(id);

   //     var result = await _sender.Send(query, cancellationToken);

   //     if (result.IsFailure)
   //         return BadRequest(result.Error);

   //     return NoContent();
   // }
}
