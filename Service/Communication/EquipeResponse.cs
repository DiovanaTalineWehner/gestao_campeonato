using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestao_campeonato.Models;

namespace gestao_campeonato.Service.Communication
{
    public class EquipeResponse : BaseResponse<Equipe>
    {
        public EquipeResponse(Equipe equipe) : base(equipe) { }

        public EquipeResponse(string message) : base(message) { }
    }
}