using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        
        [DisplayName("Banco")]
        public string Name { get; set; }
        [DisplayName("Saldo Inicial")]
        public float InitialBalance { get; set; }
        [DisplayName("Saldo Atual")]
        public float Balance { get; set; }
        public List<Expensive> Expanses { get;}

        public void AttCalculos()
        {
            this.Balance =
            this.InitialBalance +
            this.Expanses.Where(x => x.Type).Sum(x => x.Value) -
            this.Expanses.Where(x => !x.Type).Sum(x => x.Value);
        }

    }
}
