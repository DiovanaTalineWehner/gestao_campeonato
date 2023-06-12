using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestao_campeonato.Models;

namespace gestao_campeonato.Service.Communication
{
    public class CarroResponse : BaseResponse<Carro>
    {
        public CarroResponse(Carro carro) : base(carro) { }

        public CarroResponse(string message) : base(message) { }
    }
}