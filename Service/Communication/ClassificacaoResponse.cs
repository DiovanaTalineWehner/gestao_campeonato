using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestao_campeonato.Models;

namespace gestao_campeonato.Service.Communication
{
    public class ClassificacaoResponse : BaseResponse<Classificacao>
    {
        public ClassificacaoResponse(Classificacao classificacao) : base(classificacao) { }

        public ClassificacaoResponse(string message) : base(message) { }
    }
}