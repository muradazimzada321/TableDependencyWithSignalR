using System.Data;

namespace TableDependencyWithSignalR.Repositories.Abstract
{
    public interface IRepository<T> where T : ModelBase
    {
        public Task<List<T>> GetAll();
    }
}
