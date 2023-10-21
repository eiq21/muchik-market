using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.Payments;

namespace Payment.Infrastructure.Persistence.Configurations;
internal sealed class PaymentConfiguration : IEntityTypeConfiguration<Domain.Payments.Payment>
{
    public void Configure(EntityTypeBuilder<Domain.Payments.Payment> builder)
    {
        builder.ToTable("Payment");
        builder.HasKey(payment => payment.Id);

        builder.Property(payment => payment.Id)
        .HasConversion(paymentId => paymentId.Value, value => new PaymentId(value));

        builder.Property(payment => payment.Id)
        .ValueGeneratedNever()
        .HasColumnName("PaymentId");

    }
}
