using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using

    Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NovaMentoria.Models
{
    public class PeopleLearn // Plano Aprendizado
    {
        [Key]
        public int Id { get; set; }
        public TypePerson Type { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int LearningId { get; set; }
        public Learning Learning { get; set; }
    }
}