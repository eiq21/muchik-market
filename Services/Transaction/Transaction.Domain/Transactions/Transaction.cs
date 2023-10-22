using Transaction.Domain.Abstractions;

namespace Transaction.Domain.Transactions;
public sealed class Transaction : IEntity
{
    private Transaction(
        Guid id,
        Guid invoiceId,
        decimal amount,
        DateTime createdOnUtc
    )
    {
        Id = id;
        InvoiceId = invoiceId;
        Amount = amount;
        CreatedOnUtc = createdOnUtc;
    }
    public Guid Id { get; private set; }
    public Guid InvoiceId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public static Result<Transaction> Create(
      Guid invoiceId,
      decimal amount,
      DateTime createdOnUtc
  )
    {
        var transaction = new Transaction(
         Guid.NewGuid(),
         invoiceId,
         amount,
         createdOnUtc
        );

        return transaction;
    }

    //     private Transaction(
    //         Guid id,
    //         Guid invoiceId,
    //         decimal amount,
    //         DateTime createdOnUtc
    // )
    //     {
    //         InvoiceId = invoiceId;
    //         Amount = amount;
    //         CreatedOnUtc = createdOnUtc;
    //         Id = id;
    //     }
    //     private Transaction() { }

    //     public Guid InvoiceId { get; private set; }
    //     public decimal Amount { get; private set; }
    //     public DateTime CreatedOnUtc { get; private set; }
    //     public Guid Id { get; set; }



}
