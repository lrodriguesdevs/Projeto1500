using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovaMentoria.Models
{
    public class Circle
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Turma/Circulo:")]
        public string Name { get; set; }
        public List<Person> Persons { get; set; }
        public List<Learning> Learnings { get; set; }
    }
}
