Write-Host "Scaffolding..." -ForegroundColor Green
dotnet ef dbcontext scaffold "Server=localhost;Integrated Security=True;Database=OrdersService" `
    Microsoft.EntityFrameworkCore.SqlServer `
    -c OrdersServiceContext -o Entities `
    --force

Write-Host "Done." -ForegroundColor Green
