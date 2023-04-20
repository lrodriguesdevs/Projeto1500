using NovaMentoria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovaMentoria.Models
{

    public enum Status
    {
        BRANCO,
        CONCLUIDO
    }
    public class Learning
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tema")]
        public int ThemeId { get; set; }
        [DisplayName("Tema")]
        public Theme Theme { get; set; }
        [DisplayName("Círculo")]
        public int CircleId { get; set; }
        [DisplayName("Círculo")]
        public Circle Circle { get; set; }
        [DisplayName("Oportunidade de aprendizado")]
        public string OportunityLearning { get; set; } = string.Empty; //Campo texto por isso utiliza
        [DisplayName("Ação de Aprendizagem")]                                           //
        public string LearningAction { get; set; } = string.Empty;  //Campo texto por isso utiliza string
        [DisplayName("Data atual")]
        public DateTime MeasurementDate { get; set; } // Utiliza DataType devido ser data
        [DisplayName("Forma de Mediação")]
        public float MeasurementForm { get; set; }
        [DisplayName("Resultado")]
        public string Result { get; set; }
        [DisplayName("Comentários")]
        public string Comment { get; set; }
        [DisplayName("Situação")]
        public Status  Status { get; set; }

        public List<PersonLearning> PersonLearning { get; set; }
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
