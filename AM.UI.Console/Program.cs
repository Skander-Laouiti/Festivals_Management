using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("********* Gestion des programmes des festivals d’été **********");


var context = new AMContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var artiste2 = new Artiste 
{
    Nom = "Bond",
    Prenom = "James",
    Contact = "james.bond@gmail.com",
    Nationalite = "Américaine",
    DateNaissance = new DateTime(1990, 8, 20),
};

var artiste3 = new Artiste
{
    Nom = "Carter",
    Prenom = "Jay",
    Contact = "jay.carter@example.com",
    Nationalite = "Américaine",
    DateNaissance = new DateTime(1990, 2, 10),
};
context.Artistes.AddRange(artiste2, artiste3);


var festival1 = new Festival
{
    Label = "Festival de Jazz Tunis",
    Ville = "Tunis",
    Capacite = 6000,
};
var festival2 = new Festival
{
    Label = "Festival de Rap Paris",
    Ville = "Paris",
    Capacite = 7500,
};
var festival3 = new Festival
{
    Label = "Festival Sonoro",
    Ville = "Lisbonne",
    Capacite = 9000,
};
context.Festivals.AddRange(festival1, festival2, festival3);


var chanson2 = new Chanson
{
    Titre = "Rythmes de Paris",
    DateSortie = new DateTime(2024, 7, 18),
    Duree = 200,
    StyleMusical = StyleMusical.Rap,
    VuesYoutube = 18000,
    Artiste = artiste2, 
};
var chanson3 = new Chanson
{
    Titre = "Vibes de Lisbonne",
    DateSortie = new DateTime(2022, 10, 5),
    Duree = 360,
    StyleMusical = StyleMusical.Classique,
    VuesYoutube = 9500,
    Artiste = artiste3,
};
context.Chansons.AddRange(chanson1, chanson2, chanson3);


var concert2 = new Concert
{
    DateConcert = new DateTime(2024, 11, 12),
    Duree = 140,
    Cachet = 21000,
    Artiste = artiste3,
    Festival = festival3,
};
context.Concerts.AddRange(concert2);


context.SaveChanges();


Console.WriteLine("\nListe des artistes :");
var artistes = context.Artistes.ToList();
foreach (var artiste in artistes)
{
    Console.WriteLine($"- ID: {artiste.ArtisteId}, Nom: {artiste.Nom}, Prénom: {artiste.Prenom}, Nationalité: {artiste.Nationalite}, Contact: {artiste.Contact}");
}


Console.WriteLine("\nListe des festivals :");
var festivals = context.Festivals.ToList();
foreach (var festival in festivals)
{
    Console.WriteLine($"- Festival: {festival.Label}, Ville: {festival.Ville}, Capacité: {festival.Capacite}");
}


Console.WriteLine("\nListe des chansons avec artistes :");
var chansons = context.Chansons.Include(c => c.Artiste).ToList();
foreach (var chanson in chansons)
{
    Console.WriteLine($"- Titre: {chanson.Titre}, Artiste: {chanson.Artiste.Nom}, Style: {chanson.StyleMusical}, Vues: {chanson.VuesYoutube}");
}


Console.WriteLine("\nListe des concerts :");
var concerts = context.Concerts.Include(c => c.Artiste).Include(c => c.Festival).ToList();
foreach (var concert in concerts)
{
    Console.WriteLine($"- Date: {concert.DateConcert.ToShortDateString()}, Artiste: {concert.Artiste.Nom}, Festival: {concert.Festival.Label}, Cachet: {concert.Cachet:C}, Durée: {concert.Duree} minutes");
}