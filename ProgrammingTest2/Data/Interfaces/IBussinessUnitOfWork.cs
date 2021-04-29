using Data.Context;
using Data.Model;

namespace Data.Interfaces
{
    public interface IBussinessUnitOfWork : IUnitOfWork
    {
        IRepository<Address, BussinessContext> Addresses { get; }
        IRepository<Client, BussinessContext> Clients { get; }
        IRepository<Bussiness, BussinessContext> Bussinesses { get; }
    }
}
