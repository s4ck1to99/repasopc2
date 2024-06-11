namespace repaso_pc2_appsweb.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}