namespace CMP.Models
{
    public class ClientNDA
    {
        public int ClientNDAId { get; set; }
        public string ClientName { get; set; }
        public string NDA { get; set; }
        public DateTime NDAStartDate { get; set; }
        public DateTime NDAEndDate { get; set; }
        public string status { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
