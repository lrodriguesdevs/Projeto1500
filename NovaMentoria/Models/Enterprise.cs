 using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace NovaMentoria.Models
{
    public class Enterprise
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        

    }
}
