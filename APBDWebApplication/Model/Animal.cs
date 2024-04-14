using System.ComponentModel.DataAnnotations;

namespace APBDWebApplication.Model;

public class Animal
{
    public int IdAnimal { get; set; }
    [Required, MaxLength(100)] public string Name { get; set; }
    [MaxLength(200)] public string Description { get; set; }
    [Required, MaxLength(50)] public string Category { get; set; }
    [Required, MaxLength(100)] public string Area { get; set; }
}