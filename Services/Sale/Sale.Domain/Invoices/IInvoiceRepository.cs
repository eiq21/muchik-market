namespace Sale.Domain.Invoices;
public interface IInvoiceRepository
{
    Task<Invoice?> GetByIdAsync(InvoiceId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Invoice>> GetInvoicesAsync(CancellationToken cancellationToken = default);

    void Add(Invoice invoice);


}
