using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum StyleMusical
{
    Classique,
    Pop,
    Rap,
    Rock
}

public class Chanson
{
    [Key]
    public int ChansonId { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateSortie { get; set; }

    public int Duree { get; set; }

    public StyleMusical StyleMusical { get; set; }

    [StringLength(12, MinimumLength = 3)]
    public string Titre { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "VuesYoutube doit être un entier positif.")]
    public int VuesYoutube { get; set; }

    [ForeignKey("Artiste")]
    public int ArtisteFk { get; set; }
    public virtual Artiste Artiste { get; set; }
}