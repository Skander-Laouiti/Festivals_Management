using System;
using System.ComponentModel.DataAnnotations;

public class Artiste
{
    [Key]
    public int ArtisteId { get; set; }

    [Required]
    public string Nom { get; set; }

    [Required]
    public string Prenom { get; set; }

    [Required]
    public string Contact { get; set; }

    public DateTime DateNaissance { get; set; }

    [Required]
    public string Nationalite { get; set; }

    public virtual IList<Concert> Concerts { get; set; }



}