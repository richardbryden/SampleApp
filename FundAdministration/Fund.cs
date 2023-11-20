using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FundAdministration.Models
{
    public class Fund
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FundId { get; set; }

        public string? Name { get; set; }

        public string? OpenClosed { get; set; }

        public string? InfoToBeVerified { get; set; }

        public bool IsVerified { get; set; }

        public float FundValue { get; set; }
    }
}