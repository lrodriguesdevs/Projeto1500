using Microsoft.AspNetCore.Identity;
using NovaMentoria.Models;
using NovaMentoriaSistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

 public class Person : IdentityUser<int> 
//public class Person 
{
    //[Key]
   
   
    [DisplayName("Turma/Circulo:")]
    public int ?CircleId { get; set; }
    public Circle Circle { get; set; }// recebe dados da classe circle
    [DisplayName("Nome:")]
    public string Name { get; set; }
    [DisplayName("Tipo:")]
    public TypePerson Type { get; set; }
    public string CPF { get; set; } 
    [DisplayName("Telefone:")]
    public string Phone { get; set; }
    [DisplayName("Data de Nascimento:")]
    public DateTime DateBorn { get; set; }
    [DisplayName("Nível de Estudo:")]
    public NivelStudy NivelStudy { get; set; }
    [DisplayName("Universidade:")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
    public string University { get; set; }
    [DisplayName("Data de conclusão:")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
    public DateTime GraduateDate { get; set; }
    [DisplayName("Data Atual:")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
    public DateTime DateRegister { get; set; }
    [DisplayName("Empresa:")]
    public string Enterprise { get; set; }
    [DisplayName("Recomendação:")]
    public bool Recommendation { get; set; }
    [DisplayName("Esta estudando:")]
    public bool IsStudying { get; set; }
    public string Email { get; set; }

    public List<Learning> Learnings { get; set; } 
    public List<Feedback> Feedback { get; set; } 
    public List<ActualState> ActualStates { get; set; }
    public virtual List<PersonFeedback> PersonFeedbacks { get; set; } = new List<PersonFeedback>();
}

public enum TypePerson
{
    Mentorado,
    Mentor,
    
}

public enum NivelStudy
{
    EnsinoFundamentalIncompleto,
    EnsinoFundamentalCompleto,
    EnsinoMedioIncompleto,
    EnsinoMedioCompleto,
    EnsinoSuperiorIncompleto,
    EnsinoSuperiorCompleto
}

