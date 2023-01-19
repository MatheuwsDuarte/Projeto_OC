using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacaoCuriosidade.Models
{

    [Table("Colaboradores")]
    public class Colaborador
    {

        [Key]
        public int id_colaborador { get; set; }

        public string Nome { get; set; }

        public DateTime idade { get; set; } 

        public string telefone { get; set; }

        public string email { get; set; }

        public string endereco { get; set; }

        public string outrasInfo { get; set; }

        public string interesses { get; set; }

        public string sentimentos { get; set; }

        public string valores { get; set; }

        public DateTime data_cadastro { get; set; } = DateTime.Now;

        public string login_cadastro { get; set; }

    }
}
