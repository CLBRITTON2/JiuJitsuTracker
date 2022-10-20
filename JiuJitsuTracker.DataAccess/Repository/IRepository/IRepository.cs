using System.Linq.Expressions;

namespace JiuJitsuTracker.DataAccess.Repository.IRepository
{
    // Generic repository
    public interface IRepository<T> where T : class
    {
        // Requirements for the Jiu Jitsu Log Controller atm:

        // Getting the class object from the db
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        // Retrieve Class info
        IEnumerable<T> GetAll();

        // Adding an object of the classinfo class to the db
        void Add(T entity);
        
        // Removing an object of the classinfo class from the db
        void Remove(T entity);

        // Removing more than one object from the db
        void RemoveRange(IEnumerable<T> entities);
    }
}
