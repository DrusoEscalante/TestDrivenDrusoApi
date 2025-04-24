using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDrivenDrusoApi.models
{

    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        [Column("CustomerId")]
        public long CustomerId { get; set; }

    }
}
