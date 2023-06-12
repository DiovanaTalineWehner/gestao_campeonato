namespace gestao_campeonato.Models
{
    public class Partida
    {
        public int id_partida {get;set;}
        public IList<Classificacao> classificacoes { get; set; } = new List<Classificacao>();

        //public virtual IEnumerable<Classificacao> classificacoes {get;set;}

        public Campeonato campeonato {get;set;}
        public int id_campeonato {get;set;}

        public Equipe equipe {get;set;}
        public int id_equipe {get;set;}
    }
}