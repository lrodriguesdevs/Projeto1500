using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace NovaMentoria.Models
{
    public class HourDay

    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Projeto")]
        public int ActualStateId { get; set; }
        [DisplayName("Projeto")]
        public ActualState ActualState { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [DisplayName("Horas")]
        public float Hours { get; set; }
        [DisplayName("Entrega")]
        public bool Delivered { get; set; }
    }

}