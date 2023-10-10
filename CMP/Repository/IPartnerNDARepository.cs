using CMP.Models;

namespace CMP.Repository
{
    public interface IPartnerNDARepository
    {
        IEnumerable<PartnerNDA> GetPartnerNDAs();
        PartnerNDA GetPartnerNDAByID(int Id);
        void InsertPartnerNDA(PartnerNDA partnerNDA);
        void UpdatePartnerNDA(PartnerNDA partnerNDA);
        void DeletePartnerNDA(int partnerNDA);
        void save();
    }
}
