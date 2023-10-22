using EventBus;
using Payment.Application.Clock;
using Payment.Application.Core.Messaging;
using Payment.Application.Features.Payments.Events;
using Payment.Domain.Abstractions;
using Payment.Domain.Payments;

namespace Payment.Application.Features.Payments.Commands.CreatePayment;
internal class CreatePaymentCommandHandler : ICommandHandler<CreatePaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventBus _eventBus;
    public CreatePaymentCommandHandler(
        IUnitOfWork unitOfWork,
        IPaymentRepository paymentRepository,
        IDateTimeProvider dateTimeProvider,
        IEventBus eventBus)
    {
        _unitOfWork = unitOfWork;
        _paymentRepository = paymentRepository;
        _dateTimeProvider = dateTimeProvider;
        _eventBus = eventBus;
    }
    public async Task<Result> Handle(
        CreatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var paymentResult = Domain.Payments.Payment.Create(
            request.InvoiceId,
            request.Amount,
            _dateTimeProvider.UtcNow);

        _paymentRepository.Add(paymentResult.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _eventBus.Publish(new PayedInvoiceEvent
        {
            InvoiceId = paymentResult.Value.InvoiceId,
            Amount = paymentResult.Value.Amount
        });

        return Result.Success();
    }
}
