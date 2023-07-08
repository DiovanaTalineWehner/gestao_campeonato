namespace gestao_campeonato.Models
{
    public class Equipe
    {
        //que está em uma chave estrangeira 
        public int id_equipe {get;set;}
        public string nome_equipe {get;set;}
        public IList<Carro> carros { get; set; } = new List<Carro>();
        public IList<Classificacao> classificacoes { get; set; } = new List<Classificacao>();

        public IList<Campeonato> campeonatos { get; set; } = new List<Campeonato>();
    }
}