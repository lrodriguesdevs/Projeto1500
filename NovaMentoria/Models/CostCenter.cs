using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovaMentoria.Models
{
    public class CostCenter
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
