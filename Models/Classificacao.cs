namespace gestao_campeonato.Models
{
    public class Classificacao
    {
        public int id_classificacao {get;set;}
        public TimeSpan tempo_classificacao {get;set;}
        public string classificacao {get;set;}
        public Equipe equipe {get;set;}
        public int id_equipe {get;set;}
    }
}