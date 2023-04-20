using System.ComponentModel;

namespace NovaMentoria.Models
{
    public class TypeConsultor
    {
        public int Id { get; set; }
        [DisplayName("Tipo")]
        public string Name { get; set; }
        [DisplayName("Valor Tarifa")]
        public float Fee { get; set; }
    }
}