using Sale.Domain.Abstractions;

namespace Sale.Domain.Invoices;
public class InvoiceErrors
{
    public static Error NotFound = new(
           "Invoice.Found",
           "The Invoice with the specified identifier was not found");

    public static Error NotPending = new(
        "Invoice.NotPending",
        "The Invoice is not pending");
}
