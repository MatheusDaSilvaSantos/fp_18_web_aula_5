using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fp_web_aula_1_core.Models
{

    public class Time
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [EmailAddress]
        public string EnderecoDeEmail { get; set; }
        public string Bandeira { get; set; }
        public bool Publicado { get; set; }
    }
}
