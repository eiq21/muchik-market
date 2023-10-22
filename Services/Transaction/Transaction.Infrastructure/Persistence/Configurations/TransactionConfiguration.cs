using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Transaction.Infrastructure.Persistence.Configurations;
internal sealed class TransactionConfiguration
{
    public TransactionConfiguration()
    {
        BsonClassMap.RegisterClassMap<Domain.Transactions.Transaction>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.Id)
                .SetSerializer(new GuidSerializer(BsonType.String))
                .SetElementName("TransactionId");
            cm.SetIgnoreExtraElements(true);
            cm.GetMemberMap(c => c.InvoiceId)
                .SetSerializer(new GuidSerializer(BsonType.String))
                .SetElementName("InvoiceId");
            cm.GetMemberMap(c => c.Amount)
                .SetSerializer(new DecimalSerializer(BsonType.Decimal128))
                .SetElementName("Amount");
            cm.GetMemberMap(c => c.CreatedOnUtc)
                .SetSerializer(new DateTimeSerializer(BsonType.DateTime))
                .SetElementName("CreatedOnUtc");
        });
    }

}