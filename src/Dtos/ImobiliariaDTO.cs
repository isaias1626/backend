public class ImobiliariaDTO
{
    public string Tipo { get; set; }
    public int Preco { get; set; }
    public string Localizacao { get; set; }
    public string Link_detalhes { get; set; }
    public string Foto { get; set; }
    public string Descricao { get; set; }
    public string Caracteristicas { get; set; }
    public ContatoCorretorEntidade contatoCorretor { get; set; }
}