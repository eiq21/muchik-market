using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.Application.Features.Payments.Commands.CreatePayment;

namespace Payment.API.Controllers.Payments
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly ISender _sender;
        public PaymentsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(
                CreatePaymentRequest request,
                CancellationToken cancellationToken
            )
        {
            var command = new CreatePaymentCommand(
                request.InvoiceId,
                 request.Amount
            );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return NoContent();
        }
    }
}