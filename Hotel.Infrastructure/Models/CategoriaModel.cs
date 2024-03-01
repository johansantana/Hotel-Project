using System.ComponentModel.DataAnnotations;

public class CategoriaModel
{
    [Key]
  
    public string? Descripcion { get; set; }
    public bool? Estado { get; set; }

}