using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OperacaoCuriosidade.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public string login_usuario { get; set; }
        public string senha_usuario { get; set; }
    }
}