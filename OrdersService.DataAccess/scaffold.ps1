Write-Host "Scaffolding..." -ForegroundColor Green
dotnet ef dbcontext scaffold "Server=(LocalDb)\TestDb;Integrated Security=True;Database=OrdersService" `
    Microsoft.EntityFrameworkCore.SqlServer `
    -c OrdersServiceContext -o Entities `
    --force

Write-Host "Done." -ForegroundColor Green
