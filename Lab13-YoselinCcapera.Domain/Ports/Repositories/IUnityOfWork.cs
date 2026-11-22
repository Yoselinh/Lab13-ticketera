namespace Lab13_YoselinCcapera.Domain.Ports.Repositories;


public interface IUnityOfWork
{
    IGenericRepository<T> Repository<T>() where T : class;
    IReportRepository Reports { get; }
    Task<int> SaveChangesAsync();
}