using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sale.Domain.Invoices;

namespace Sale.Infrastructure.Persistence.Configurations;
internal sealed class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Sale", "Invoice");

        builder.HasKey(invoice => invoice.Id);

        builder.Property(invoice => invoice.Id)
           .HasConversion(invoiceId => invoiceId.Value, value => new InvoiceId(value));

        builder.Property(invoice => invoice.Id)
        .ValueGeneratedNever()
        .HasColumnName("InvoiceId");
    }
}
