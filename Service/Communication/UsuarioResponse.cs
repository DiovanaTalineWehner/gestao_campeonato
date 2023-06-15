using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestao_campeonato.Models;

namespace gestao_campeonato.Service.Communication
{
    public class UsuarioResponse : BaseResponse<Usuario>
    {
        public UsuarioResponse(Usuario usuario) : base(usuario) { }

        public UsuarioResponse(string message) : base(message) { }
    }
}