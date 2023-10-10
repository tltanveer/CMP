using CMP.Models;

namespace CMP.Repository
{
    public interface IClientNDARepository
    {
        IEnumerable<ClientNDA> GetClientNDAs();
        ClientNDA GetClientNDAByID(int Id);
        void InsertClientNDA(ClientNDA clientNDA);
        void UpdateClientNDA(ClientNDA clientNDA);
        void DeleteClientNDA(int clientNDA);
        void save();
    }
}
