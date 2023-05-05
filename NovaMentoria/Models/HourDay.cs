using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace NovaMentoria.Models
{
    public class HourDay

    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public int ActualStateId { get; set; }
        [DisplayName("Descrição")]
        public ActualState ActualState { get; set; }
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [DisplayName("Horas")]
        public float Hours { get; set; }
        [DisplayName("Entregue")]
        public bool Delivered { get; set; }
    }

}