﻿using NovaMentoria.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovaMentoria.Models
{
    public class Theme
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Tema")]
        public string Name { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; } = string.Empty;

        public List<Learning> Learnings { get; set; }
        
    }
}

