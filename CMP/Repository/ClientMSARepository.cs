using CMP.DBContexts;
using CMP.Models;
using Microsoft.EntityFrameworkCore;

namespace CMP.Repository
{
    public class ClientMSARepository : IClientMSARepository
    {
        private readonly CMPContext _dbContext;
        public ClientMSARepository(CMPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteClientMSA(int clientMSAId)
        {
            var clientMsa = _dbContext.ClientMSA.Find(clientMSAId);
            _dbContext.ClientMSA.Remove(clientMsa);
            save();
        }

        public ClientMSA GetClientMSAByID(int Id)
        {
            return _dbContext.ClientMSA.Find(Id);
        }

        public IEnumerable<ClientMSA> GetClientMSAs()
        {
            return _dbContext.ClientMSA.ToList();
        }

        public void InsertClientMSA(ClientMSA clientMSA)
        {
            _dbContext.Add(clientMSA);
            save();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateClientMSA(ClientMSA clientMSA)
        {
            _dbContext.Entry(clientMSA).State = EntityState.Modified;
            save();
        }
    }
}
