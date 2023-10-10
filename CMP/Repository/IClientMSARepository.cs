using CMP.Models;
namespace CMP.Repository

{
    public interface IClientMSARepository
    {
        IEnumerable<ClientMSA> GetClientMSAs();
        ClientMSA GetClientMSAByID(int Id);
        void InsertClientMSA(ClientMSA clientMSA);
        void UpdateClientMSA(ClientMSA clientMSA);
        void DeleteClientMSA(int clientMSA);
        void save();
    }
}
