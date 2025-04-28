using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Concert
{
    public double Cachet { get; set; }

    [Required]
    public DateTime DateConcert { get; set; }
    public int Duree { get; set; }

    [Required]
    [ForeignKey("Artiste")]
    public int ArtisteFk { get; set; }
    public virtual Artiste Artiste { get; set; }

    [Required]
    [ForeignKey("Festival")]
    public int FestivalFk { get; set; }
    public virtual Festival Festival { get; set; }




}
