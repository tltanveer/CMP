using CMP.DBContexts;
using CMP.Models;
using Microsoft.EntityFrameworkCore;

namespace CMP.Repository
{
    public class ClientNDARepository : IClientNDARepository
    {
        private readonly CMPContext _dbContext;
        public ClientNDARepository(CMPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteClientNDA(int clientNDAId)
        {
            var clientNDA = _dbContext.ClientNDA.Find(clientNDAId);
            _dbContext.ClientNDA.Remove(clientNDA);
            save();
        }

        public ClientNDA GetClientNDAByID(int Id)
        {
            return _dbContext.ClientNDA.Find(Id);
        }

        public IEnumerable<ClientNDA> GetClientNDAs()
        {
           return _dbContext.ClientNDA.ToList();
        }

        public void InsertClientNDA(ClientNDA clientNDA)
        {
            _dbContext.ClientNDA.Add(clientNDA);
            save();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateClientNDA(ClientNDA clientNDA)
        {
            _dbContext.Entry(clientNDA).State = EntityState.Modified;
            save();
        }
    }
}
