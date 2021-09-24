using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace WSTP3.Models.EntityFramework
{
    public partial class TP3DBContext : DbContext
    {
        public TP3DBContext()
        {
        }

        public TP3DBContext(DbContextOptions<TP3DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favori> Favoris { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }
        public virtual DbSet<Film> Films { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Compte>()
                .Property(b => b.Pays)
                .HasDefaultValue("France");

            modelBuilder.Entity<Compte>()
               .Property(b => b.DateCreation)
               .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Compte>()
               .Property(b => b.DateCreation)
               .HasColumnType("date");

            modelBuilder.Entity<Film>()
               .Property(b => b.DateParution)
               .HasColumnType("date");

            modelBuilder.Entity<Favori>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CompteId })
                    .HasName("PK_FAV");

                entity.HasOne(d => d.CompteFavori)
                    .WithMany(p => p.FavorisCompte)
                    .HasForeignKey(d => d.CompteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FAV_CPT");

                entity.HasOne(d => d.FilmFavori)
                    .WithMany(p => p.FavorisFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FAV_FLM");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
