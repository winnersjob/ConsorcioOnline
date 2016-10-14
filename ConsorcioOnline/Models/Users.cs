using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsorcioOnline.Models
{
    [DataContract]
    public class Users:IValidatableObject
    {        
        [Key]
        [DataMember]
        public string Id { get; set;}

        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",ErrorMessage = "Digite um e-mail válido")]
        //[Required(ErrorMessage ="Digite um E-mail válido!")]
        [Display(Name ="E-mail: ")]
        [DataMember]
        public string UserName { get; set; }

        [StringLength(250,MinimumLength =5)]
        //[Required(ErrorMessage = "É necessário digitar um Nome!")]
        [Display(Name ="Nome: ")]
        [DataMember]
        public string Nome { get; set; }

        [StringLength(150,MinimumLength =5)]
        [Display(Name ="Apelido: ")]
        [DataMember]
        public string Apelido { get; set; }

        //[Required(ErrorMessage ="Selecione uma opção Válida!")]
        [Display(Name ="Fisica / Juridica: ")]
        [DataMember]
        public int FisJur { get; set; }

        [StringLength(14,MinimumLength =14,ErrorMessage = "Digite um CPF válido!")]
        [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}",ErrorMessage ="Digite um CPF válido!")]        
        [Display(Name ="CPF: ")]
        [DataMember]
        public string CPF { get; set; }

        [StringLength(18, MinimumLength = 18,ErrorMessage = "Digite um CNPJ válido!")]
        [RegularExpression(@"\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}", ErrorMessage = "Digite um CNPJ válido!")]
        [Display(Name="CNPJ: ") ]
        [DataMember]
        public string CNPJ { get; set; }

        [Display(Name ="Inscricao Estadual: ")]
        [DataMember]
        public string IE { get; set; }

        [Display(Name ="Bloqueado?: ")]
        [DataMember]
        public int Blocked { get; set; }

        [RegularExpression(@"[1-9]{2}\-[2-9][0-9]{7,8}", ErrorMessage = "Digite um telefone válido! Formato 11-XXXX-XXXX ou 11-XXXXX-XXXX")]
        [StringLength(15)]
        //[Required(ErrorMessage = "É necessário informar um Telefone!")]
        [Display(Name ="Telefone: ")]
        [DataMember]
        public string Telefone { get; set; }

        [DataMember]
        //[Required(ErrorMessage ="É necessário informar uma Senha!")]
        public string Senha { get; set; }

        [DataMember]
        [Compare("Senha",ErrorMessage ="As senhas não são iguais!")]
        //[Required(ErrorMessage = "É necessário informar a Confirmação da Senha!")]
        public string ConfirmSenha { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((FisJur == 1) && (CPF == null))
                yield return new ValidationResult("CPF é obrigatório para pessoa física!",new[] { "CPF" });

            if ((FisJur == 1) && (CNPJ!= null))
                yield return new ValidationResult("Não é permitido CNPJ para pessoa física!",new[] { "CNPJ" });

            if ((FisJur == 2) && (CNPJ == null))
                yield return new ValidationResult("CNPJ é obrigatório para pessoa jurídica!",new[] { "CNPJ" });

            if ((FisJur == 2) && (CPF != null))
                yield return new ValidationResult("Não é permitido CPF para pessoa jurídica!", new[] { "CPF" });

        }
    }
}
