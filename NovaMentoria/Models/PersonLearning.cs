using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NovaMentoria.Models
{ 
    public class PersonLearning
{
    [Key]
    public int Id { get; set; }
    public TypePerson TypePerson { get; set; }
    [DisplayName("Aluno")]
    public int PersonId { get; set; }
        [DisplayName("Aluno")]
        [ForeignKey("PersonId")]  
        public Person Person { get; set; }

    public int LearningId { get; set; }
        [DisplayName("Aprendizado")]
        public Learning Learning { get; set; }
}
}

