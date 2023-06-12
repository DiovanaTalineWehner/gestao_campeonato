namespace gestao_campeonato.Models
{
    public class Campeonato
    {
        //com chave estrangeira
        public int id_campeonato {get;set;}
        public string nome_campeonato {get;set;}
        public Local_Campeonato local_campeonato {get;set;}
        public int id_local_campeonato {get;set;}
        //public virtual IEnumerable<Partida> partidas {get;set;}
        public IList<Partida> partidas { get; set; } = new List<Partida>();

    }
}