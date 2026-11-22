using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using Lab13_YoselinCcapera.IInfrastructure.Context;

namespace Lab13_YoselinCcapera.IInfrastructure.Adapters.Repositories;


public class UnityOfWork(ApplicationDbContext context) : IUnityOfWork
{
    private readonly Dictionary<Type, object> _repositories = new();
    private IReportRepository? _reports;

    public IGenericRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);

        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new GenericRepository<T>(context);
        }

        return (IGenericRepository<T>)_repositories[type];
    }

    public IReportRepository Reports
    {
        get
        {
            _reports ??= new ReportRepository(context);
            return _reports;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}