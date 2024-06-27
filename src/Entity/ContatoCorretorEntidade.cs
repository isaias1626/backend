using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ContatoCorretorEntidade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Nome { get; set; }
    public int Telefone { get; set; }
    public string Email { get; set; }
    public ContatoCorretorEntidade()
    {
        Nome = string.Empty;
        Telefone = 0;
        Email = string.Empty;
    }
}