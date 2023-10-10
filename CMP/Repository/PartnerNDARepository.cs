using CMP.DBContexts;
using CMP.Models;
using Microsoft.EntityFrameworkCore;

namespace CMP.Repository
{
    public class PartnerNDARepository : IPartnerNDARepository
    {

        private readonly CMPContext _dbContext;
        public PartnerNDARepository(CMPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeletePartnerNDA(int partnerNDAId)
        {
            var partnerNDA = _dbContext.PartnerNDA.Find(partnerNDAId);
            _dbContext.PartnerNDA.Remove(partnerNDA);
            save();
        }

        public PartnerNDA GetPartnerNDAByID(int Id)
        {
            return _dbContext.PartnerNDA.Find(Id);
        }

        public IEnumerable<PartnerNDA> GetPartnerNDAs()
        {
            return _dbContext.PartnerNDA.ToList();
        }

        public void InsertPartnerNDA(PartnerNDA partnerNDA)
        {
            _dbContext.PartnerNDA.Add(partnerNDA);
            save();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePartnerNDA(PartnerNDA partnerNDA)
        {
            _dbContext.Entry(partnerNDA).State = EntityState.Modified;
            save();
        }
    }
}
