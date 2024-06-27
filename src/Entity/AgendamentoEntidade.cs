using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AgendamentoEntidade{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public Guid Id { get; set; }
    public string Data { get; set; }
    public string Hora { get; set; }

}