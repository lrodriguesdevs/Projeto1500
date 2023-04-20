using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovaMentoria.Models
{
    public class BankAccount
    {
        [Key]

        public int Id { get; set; }
        
        public int EnterpriseId { get; set; }
        [DisplayName("Empresa")]
        public Enterprise Enterprise { get; set; }
        [DisplayName("Centro de Custo")]
        public string CostCenter { get; set; }
        [DisplayName("Saldo Atual")]
        public string Balance { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Saldo Inicial")]
        public string InitialBalance { get; set; }

    }
}
