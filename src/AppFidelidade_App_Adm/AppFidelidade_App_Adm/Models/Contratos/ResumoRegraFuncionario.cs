using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFidelidade_App_Adm.Models.Contratos
{
    public class ResumoRegraFuncionario
    {
        public int RegrasCadastradas { get; set; }
        public int MaxRegrasCadastradas { get; set; }
        public int FuncionariosCadastrados { get; set; }
        public int MaxFuncionariosCadastrados { get; set; }
        public string DetalhesRegras => $"{RegrasCadastradas}/{MaxRegrasCadastradas}";
        public string DetalhesFuncionarios => $"{FuncionariosCadastrados}/{MaxFuncionariosCadastrados}";
    }

}
