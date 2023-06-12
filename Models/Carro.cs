namespace gestao_campeonato.Models
{
    public class Carro
    {
        public int id_carro {get;set;}
        public string nome_carro {get;set;}
        public Equipe equipe {get;set;}
        public int id_equipe {get;set;}        

    }
}