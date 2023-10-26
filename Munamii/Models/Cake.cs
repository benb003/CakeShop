using System.ComponentModel;

namespace Munamii.Models;

public partial class Cake
{
    public int CakeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Price { get; set; }
    public string? ImgUrl { get; set; }
    public bool IsCakeOfTheWeek { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}