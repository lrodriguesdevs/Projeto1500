using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovaMentoria.Models
{
    public class Expensive
    {
        [Key] 
        public int Id { get; set; }
        [DisplayName("Type")]
        public bool Type { get; set; }
        [DisplayName("Data de Realização")]
        public DateTime RegisterDate { get; set; }
        [DisplayName("Data do Caixa")]
        public DateTime CashDate { get; set; }
        [DisplayName("Mês Caixa")]
        public DateTime MonthDate { get; set; }
        [DisplayName("Data Competência")]
        public DateTime CompDate { get; set; }
        [DisplayName("Centro de Custo")]
        public int DisbursementId { get; set; }
        [DisplayName("Centro de Custo")]
        public CostCenter? Disbursement { get; set; }
        [DisplayName("Conta")]
        public int CaptureId { get; set; }
        [DisplayName("Conta")]
        public Capture? Capture { get; set; }
        [DisplayName("Pessoa")]
        public int? PersonId { get; set; }
        [DisplayName("Pessoa")]
        public Person Person { get; set; }
        [DisplayName("Banco")]
        public int? BankAccountId { get; set; }
        [DisplayName("Banco")]

        public BankAccount? BankAccount { get; set; }
        [DisplayName("Despesa")]
        public string TargetBill { get; set; }
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [DisplayName("Valor")]
        public float Value { get; set; }
        public bool Plan { get; set; }
        [DisplayName("Saldo")]
        public float Balance { get; set; }  

    }
}
