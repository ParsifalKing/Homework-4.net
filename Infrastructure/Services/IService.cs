using Npgsql.Replication.PgOutput.Messages;

namespace Infrastructure.Services;

public interface IService<T>
{
    void Add(T some);
    List<T> Get();
    void Update(T some);
    void Delete(int id);
}
