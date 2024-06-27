using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ImobiliariaEntidade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Tipo { get; set; }
    public int Preco { get; set; }
    public string Localizacao { get; set; }
    public string Link_detalhes { get; set; }
    public string Foto { get; set; }
    public string Descricao { get; set; }
    public string Caracteristicas { get; set; }
    public ContatoCorretorEntidade contatoCorretor { get; set; }
}

