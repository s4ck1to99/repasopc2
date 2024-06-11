using Microsoft.EntityFrameworkCore;
using repaso_pc2_appsweb.Shared.Domain.Repositories;
using repaso_pc2_appsweb.Shared.Infrastracture.Persistence.EFC.Configuration;
using repaso_pc2_appsweb.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace repaso_pc2_appsweb.Shared.Infrastracture.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public async Task<TEntity?> FindAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
}