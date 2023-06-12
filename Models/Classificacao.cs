namespace gestao_campeonato.Models
{
    public class Classificacao
    {
        public int id_classificacao {get;set;}
        public decimal tempo_classificacao {get;set;}
        public int classificacao {get;set;}
        public Partida partida {get;set;}
        public int id_partida {get;set;}
    }
}