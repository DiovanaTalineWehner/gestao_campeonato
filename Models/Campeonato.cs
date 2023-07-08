namespace gestao_campeonato.Models
{
    public class Campeonato
    {
        //com chave estrangeira
        public int id_campeonato {get;set;}
        public string nome_campeonato {get;set;}
        public Equipe equipe {get;set;}
        public int id_equipe {get;set;}
    }
}