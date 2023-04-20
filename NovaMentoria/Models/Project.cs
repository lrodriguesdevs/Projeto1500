using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovaMentoria.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Projeto")]
        public string Name { get; set; }
        [DisplayName("Tipo de Contrato")]
        public TypeTime Type { get; set; }
        [DisplayName("Tarifa")]
        public TypeFee Fee { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Empresa")]
        public string Enterprise { get; set; }
        [DisplayName("Duração")]
        public float Duration { get; set; }
        [DisplayName("Valor")]
        public float Value { get; set; }
        [DisplayName("Data Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime StartDate { get; set; }
        [DisplayName("Data de Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime EndDate { get; set; }
        [DisplayName("Data Inserção")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime InsertDate { get; set; }
        [DisplayName("Situação")]
        public bool Status { get; set; }
        public List<ActualState> ActualStates { get; set;}

    }

    public enum TypeTime
    {
        Horas,
        PrecoFechado
    }

    public enum TypeFee
    {
        Tarifa1,
        Tarifa2,
        Tarifa3,
        Tarifa4,
        Tarifa5
    }


}
