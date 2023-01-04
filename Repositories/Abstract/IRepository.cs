using System.Data;

namespace TableDependencyWithSignalR.Repositories.Abstract
{
    public interface IRepository
    {
        public DataTable GetAll();
    }
}
