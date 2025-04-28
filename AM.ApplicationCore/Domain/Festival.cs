using System.ComponentModel.DataAnnotations;

public class Festival
{
    [Key]
    public int FestivalId { get; set; }
    public string Label { get; set; }
    public string Ville { get; set; }
    public int Capacite { get; set; }

    public virtual IList<Concert> Concerts { get; set; }
}

