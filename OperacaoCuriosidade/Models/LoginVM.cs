using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacaoCuriosidade.Models
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool PermanecerLogado { get; set; }
        public string ReturnURL { get; set; }
    }
}
