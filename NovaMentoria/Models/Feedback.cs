using NovaMentoria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaMentoriaSistema.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [DisplayName("Turma/Círculo")]
        public int CircleId { get; set; }
        [DisplayName("Turma/Círculo")]
        public Circle Circle { get; set; }
        [DisplayName("Tema")]
        public int ThemeId { get; set; }
        [DisplayName("Tema")]
        public Theme Theme { get; set; }
        [DisplayName("Oportunidade de Aprendizado")]
        public string OportunityLearning { get; set; } = string.Empty;
        [DisplayName("Notas")]
        public float Note { get; set; } 
        [DisplayName("Comentários")]
        public string Comment { get; set; }
        [DisplayName("Apagar")]
       

        public List<PersonFeedback> PersonFeedbacks { get; set; }

        [NotMapped]
        [DisplayName("Professor")]
        public int TeacherPersonId { get; set; }
        [NotMapped]
        [DisplayName("Aluno")]
        public int StudentPersonId { get; set; }
        [NotMapped]
        public Person TeacherPerson { get; set; }
        [NotMapped]
        public Person StudentPerson { get; set; }


    }
}
