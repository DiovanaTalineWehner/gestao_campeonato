namespace gestao_campeonato.Models
{
    public class Classificacao
    {
        public int id_classificacao {get;set;}
        public decimal tempo_classificacao {get;set;}
        public int classificacao {get;set;}
        public Equipe equipe {get;set;}
        public int id_equipe {get;set;}
    }
}