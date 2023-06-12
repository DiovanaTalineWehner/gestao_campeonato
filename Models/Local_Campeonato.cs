namespace gestao_campeonato.Models
{
    public class Local_Campeonato
    {
        //com chave estrangeira
        public int id_local_campeonato {get;set;}
        public string cidade_local_campeonato {get;set;}
        public string estado_local_campeonato {get;set;}   
        //ypublic virtual IEnumerable<Campeonato> campeonatos {get;set;}
        public IList<Campeonato> campeonatos { get; set; } = new List<Campeonato>();

 
    }
}