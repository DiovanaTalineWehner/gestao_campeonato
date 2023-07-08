using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestao_campeonato.Models;

namespace gestao_campeonato.Service.Communication
{
    public class CampeonatoResponse : BaseResponse<Campeonato>
    {
        public CampeonatoResponse(Campeonato campeonato) : base(campeonato) { }

        public CampeonatoResponse(string message) : base(message) { }
    }
}