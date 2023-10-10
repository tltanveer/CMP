using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMP.Models
{
    public class ClientSOW
    {
        [Required]
        public int ClientMSAId { get; set; }
        [ForeignKey(nameof(ClientName))]
        public string ClientName { get; set; }
        public string MSA { get; set; }
        public string MSAName { get; set; }
        public DateTime MSASignedDate { get; set; }
        public DateTime MSAEndDate { get; set; }
        public string status { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
