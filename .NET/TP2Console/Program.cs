using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TP2Console.Models.EntityFramework;

namespace TP2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                // update avec savechanges
                //Film titanic = ctx.Films.First(f => f.Nom.Contains("Titanic"));
                //titanic.Description = "Un bateau échoué. Date : " + DateTime.Now;
                //int nbChanges = ctx.SaveChanges();
                //Console.WriteLine("Nombre d'enregistrements modifiés ou ajoutés : " + nbChanges);

                // chargement explicite
                //Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
                //Console.WriteLine("Categorie : " + categorieAction.Nom);
                //Console.WriteLine("Films : ");
                //Chargement des films de la catégorie Action.
                //foreach (var film in ctx.Films
                //    .Where(f => f.CategorieNavigation.Nom == categorieAction.Nom)
                //    .ToList()
                //)
                //{
                //    Console.WriteLine(film.Nom);
                //}

                // chargement explicite avec Entry et Collection : one to many et Reference (many to one) (recommandé)
                //ctx.Entry(categorieAction).Collection(c => c.Films).Load();
                //Console.WriteLine("Films : ");
                //foreach (var film in categorieAction.Films)
                //{
                //    Console.WriteLine(film.Nom);
                //}

                // chargement hatif, la catégorie et ses films sont chargés
                //var categorieAction = ctx.Categories
                //    .Include(c => c.Films)
                //    .First(c => c.Nom == "Action");
                //Console.WriteLine("Categorie : " + categorieAction.Nom);
                //Console.WriteLine("Films : ");
                //foreach (var film in categorieAction.Films)
                //{
                //    Console.WriteLine(film.Nom);
                //}

                // lazy loading
                //categorieAction = ctx.Categories.First(c => c.Nom == "Action");
                //Console.WriteLine("Categorie : " + categorieAction.Nom);
                //Console.WriteLine("Films : ");
                ////Chargement des films de la catégorie Action.
                //foreach (var film in categorieAction.Films) // lazy loading initiated
                //{
                //    Console.WriteLine(film.Nom);
                //}
            }

            //Exo2Q1();
            //Exo2Q2();
            //Exo2Q3();
            //Exo2Q4();
            //Exo2Q5();
            //Exo2Q6();
            //Exo2Q7();
            //Exo2Q8();
            //Exo2Q9();

            //AddUtilisateur();
            //ModifierFilm();
            //DeleteFilm();
            //AjouterAvis();
            //Ajouter2FilmsCategorieDrame();

            Console.ReadKey();
        }

        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Films)
            {
                Console.WriteLine(film);
            }
        }

        public static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();
            var allEmails = ctx.Utilisateurs.Select(u => u.Email).ToList();
            foreach (var email in allEmails)
            {
                Console.WriteLine(email);
            }
        }

        public static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();
            var data = ctx.Utilisateurs.OrderBy(u => u.Login).ToList();
            foreach (var d in data)
            {
                Console.WriteLine(d.ToString());
            }
        }

        public static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();
            var data = ctx.Films
                   .Include(f => f.CategorieNavigation)
                   .Where(f => f.CategorieNavigation.Nom == "Action")
                   .Select(f => new { f.Id, f.Nom })
                   .ToList();

            foreach (var d in data)
            {
                Console.WriteLine(d);
            }
        }

        public static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();
            var data = ctx.Categories
                    .Distinct()
                    .Count();

            Console.WriteLine(data);
        }

        public static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();
            var data = ctx.Avis
                    .Min(a => a.Note);

            Console.WriteLine(data);
        }

        public static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();
            var data = ctx.Films
                    .Where(a => a.Nom.ToLower().StartsWith("le"))
                    .ToList();

            foreach (var d in data)
            {
                Console.WriteLine(d.ToString());
            }
        }

        public static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();
            var data = ctx.Avis
                    .Include(a => a.FilmNavigation)
                    .Where(a => a.FilmNavigation.Nom.ToLower().StartsWith("pulp fiction"))
                    .Average(a => a.Note);

            Console.WriteLine(data);
        }

        public static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();
            var data = ctx.Avis
                    .Include(a => a.UtilisateurNavigation)
                    .OrderByDescending(a => a.Note)
                    .Select(a => a.UtilisateurNavigation.Email)
                    .First();

            Console.WriteLine(data);
        }

        public static void AddUtilisateur()
        {
            var ctx = new FilmsDBContext();
            ctx.Utilisateurs.Add(new Utilisateur()
            {
                Email = "eloi.bellet@tp2.fr",
                Login = "eloi",
                Pwd = "random"
            });
            ctx.SaveChanges();
        }

        public static void ModifierFilm()
        {
            var ctx = new FilmsDBContext();
            var film = ctx.Films
                .FirstOrDefault(a => a.Nom.ToLower().StartsWith("L'armee des douze singes".ToLower()));
            var drame = ctx.Categories
                .FirstOrDefault(a => a.Nom.ToLower().StartsWith("drame"));

            film.Description = "random";
            film.Categorie = drame.Id;

            ctx.SaveChanges();
        }

        public static void DeleteFilm()
        {
            var ctx = new FilmsDBContext();
            var film = ctx.Films
                .Include(f => f.Avis)
                .FirstOrDefault(a => a.Nom.ToLower().StartsWith("L'armee des douze singes".ToLower()));

            ctx.Avis.RemoveRange(film.Avis);
            ctx.Films.Remove(film);

            ctx.SaveChanges();
        }

        public static void AjouterAvis()
        {
            var ctx = new FilmsDBContext();

            var myself = ctx.Utilisateurs.FirstOrDefault(u => u.Login == "eloi");

            ctx.Avis.Add(new Avi()
            {
                Film = 1,
                Utilisateur = myself.Id,
                Note = 0,
                Avis = "Excellent"
            });

            ctx.SaveChanges();
        }

        public static void Ajouter2FilmsCategorieDrame()
        {
            var ctx = new FilmsDBContext();

            var drame = ctx.Categories
                .FirstOrDefault(a => a.Nom.ToLower().StartsWith("drame"));

            ctx.Films.AddRange(new List<Film>()
            {
                new Film()
                {
                    Nom = "Nom1",
                    Categorie = drame.Id
                },
                new Film()
                {
                    Nom = "Nom2",
                    Categorie = drame.Id
                }
            });

            ctx.SaveChanges();
        }
    }
}
