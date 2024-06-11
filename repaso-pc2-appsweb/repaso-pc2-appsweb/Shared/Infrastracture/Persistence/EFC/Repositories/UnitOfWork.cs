using repaso_pc2_appsweb.Shared.Domain.Repositories;
using repaso_pc2_appsweb.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace repaso_pc2_appsweb.Shared.Infrastracture.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}