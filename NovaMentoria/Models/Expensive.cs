using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NovaMentoria.Models
{
    public class Expensive
    {
        [Key] 
        public int Id { get; set; }
        [DisplayName("Recebimento")]
        public bool Type { get; set; }
        [DisplayName("Data de Realização")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime RegisterDate { get; set; }
        [DisplayName("Data do Caixa")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CashDate { get; set; }
        [DisplayName("Mês Caixa")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yy}")]
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
        [DisplayName("Saldo do Banco")]
        public float Balance { get; set; }
        [DisplayName("Saldo da Empresa")]
        public float EnterpriseBalance { get; set; }

    }
}
