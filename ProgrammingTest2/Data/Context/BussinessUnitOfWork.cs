using Data.Interfaces;
using Data.Model;
using System.Threading.Tasks;

namespace Data.Context
{
    public class BussinessUnitOfWork : UnitOfWork<BussinessContext>, IBussinessUnitOfWork
    {
        public BussinessUnitOfWork() : base()
        {
            _addresses = new Repository<Address, BussinessContext>(Context);
            _clients = new Repository<Client, BussinessContext>(Context);
            _bussinesses = new Repository<Bussiness, BussinessContext>(Context);
            
            InsertMockData().GetAwaiter().GetResult();
        }

        readonly Repository<Address, BussinessContext> _addresses;
        public IRepository<Address, BussinessContext> Addresses { get => _addresses; }

        readonly Repository<Client, BussinessContext> _clients;
        public IRepository<Client, BussinessContext> Clients { get => _clients; }

        readonly Repository<Bussiness, BussinessContext> _bussinesses;
        public IRepository<Bussiness, BussinessContext> Bussinesses { get => _bussinesses; }

        /// <summary>
        /// Fill DbContext With Mock Data for the Programming Test
        /// </summary>
        private async Task InsertMockData()
        {
            // TODO
            await Bussinesses.Add(SeedData.GenerateBussinesses());
            await Complete();
            await Clients.Add(SeedData.GenerateClients(await Bussinesses.GetAll()));
            await Complete();
            await Addresses.Add(SeedData.GenerateAddresses(await Clients.GetAll()));
            await Complete();
        }
    }
}
