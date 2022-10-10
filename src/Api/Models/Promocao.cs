﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Promocao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da promoção é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O código da promoção é obrigatório")]
        public string Codigo{ get; set; }
    }
}
