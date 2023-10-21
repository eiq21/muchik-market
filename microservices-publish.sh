echo "Generate publish Security API..."
dotnet publish ./Services/Security/Security.API/ --os linux --arch x64
# dotnet dotnet ef database update --context SecurityDbContext --project ./Services/Security/Security.Infrastructure/ --startup-project ./Services/Security/Security.API/
echo "Publish Security API successfully..."

echo "Generate publish Payment API..."
dotnet publish ./Services/Payment/Payment.API/ --os linux --arch x64
# dotnet dotnet ef database update --context PaymentDbContext --project ./Services/Payment/Payment.Infrastructure/ --startup-project ./Services/Payment/Payment.API/
echo "Publish Payment API successfully..."

echo "Generate publish Sale API..."
dotnet publish ./Services/Sale/Sale.API/ --os linux --arch x64
# dotnet dotnet ef database update --context SaleDbContext --project ./Services/Sale/Sale.Infrastructure/ --startup-project ./Services/Sale/Sale.API/
echo "Publish Sale API successfully..."