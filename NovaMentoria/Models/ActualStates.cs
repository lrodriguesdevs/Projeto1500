using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NovaMentoria.Models
{
    public enum TypeObject
    {
        GESTAO,
        ETL,
        DASH,
        BBP,
        AULA,
        PREPAULA,
        DEV,
        MANUT
    }


    public class ActualState
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Turma/Circulo:")]
        public int CircleId { get; set; }
        [DisplayName("Turma/Circulo:")]
        public Circle Circle { get; set; }
        [DisplayName("Projeto")]
        public int ProjectId { get; set; }
        [DisplayName("Projeto")]
        public Project Project { get; set; }
        [DisplayName("Tipo")]
        public TypeObject TypeObject { get; set; }

        public int TypeConsultorId { get; set; }
        [DisplayName("Tarifa")]
        public TypeConsultor TypeConsultor { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Tempo Planejado")]
        public float TimePlanned { get; set; }
        [DisplayName("Valor")]
        public float Value { get; set; }
        [DisplayName("Consultor")]
        public int PersonId { get; set; }
        [DisplayName("Consultor")]
        [ForeignKey("PersonId")]  
        public Person Person { get; set; }
        [DisplayName("Tempo Utilizado")]
        public float RealTime { get; set; }
        
        [DisplayName("Entrega")]
        public bool Delivered { get; set; }
        [DisplayName("Produtividade")]
        public float Productivity { get; set; }
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data Entrega")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public  DateTime DateTime  { get; set; }
        [DisplayName("Valor Final")]
        public float FinalValue { get; set; }
        [DisplayName("Horas dia")]
        public List<HourDay> HoursDay { get; set; }

        public void AttCalculos()
        {
            this.Productivity = this.TimePlanned / this.RealTime; //Produtividade

            if (this.HoursDay != null)
            {
                this.RealTime = this.HoursDay.Sum(x => x.Hours);
                this.Delivered = this.HoursDay.FirstOrDefault(x => x.Delivered == true) != null;
            }
            //if (this.Project.Type == TypeTime.PrecoFechado)
            //{
            //    float tarifa = this.Project.Value / this.Project.Duration;
            //    this.Value = tarifa * this.TimePlanned;
            //}
            //else
            //{
            //      this.Value = this.TypeConsultor.Fee * this.TimePlanned;
            //}
            if (this.Delivered)
            {
                    if (this.Project.Type == TypeTime.PrecoFechado)
                {
                    float tarifa = this.Project.Value / this.Project.Duration;
                    this.FinalValue = this.TimePlanned * tarifa;
                     }
                     else
                     {
                         this.FinalValue = this.TypeConsultor.Fee * this.RealTime;
                     }
                }
            }
        }


    }

