using Explore_ease.Models;
using Microsoft.EntityFrameworkCore;

namespace ExploreEase.Context
{
    public class ExploreEaseContext : DbContext
	{
		public ExploreEaseContext(DbContextOptions<ExploreEaseContext> options) : base(options)
		{
		}

        // DbSet para cada liga
		public DbSet<PremierLeague> PremierLeague { get; set; }
		public DbSet<Laliga> LaLiga { get; set; }
		public DbSet<SerieA> SerieA { get; set; }
		public DbSet<Bundesliga> Bundesliga { get; set; }
		public DbSet<Ligue1> Ligue1 { get; set; }
		

		// DbSet para la tabla Person (puede ser utilizada para cualquier liga)
		public DbSet<Person> Person { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			EntityConfuguration(modelBuilder);
		}

		private void EntityConfuguration(ModelBuilder modelBuilder)
		{
			// Configuración de la tabla Person
			modelBuilder.Entity<Person>().ToTable("Person");
			modelBuilder.Entity<Person>().Property(u => u.id).HasColumnName("PlayerID").ValueGeneratedOnAdd();
			modelBuilder.Entity<Person>().Property(u => u.Nombre).HasColumnName("Name");
			modelBuilder.Entity<Person>().Property(u => u.Posicion).HasColumnName("Position");
			modelBuilder.Entity<Person>().Property(u => u.Club).HasColumnName("Club");
			modelBuilder.Entity<Person>().Property(u => u.Nacionalidad).HasColumnName("Nationality");
			modelBuilder.Entity<Person>().Property(u => u.Edad).HasColumnName("Age");
			modelBuilder.Entity<Person>().Property(u => u.Correo).HasColumnName("Correo");


			// Configuración para la Premier League
			modelBuilder.Entity<PremierLeague>().ToTable("PremierLeague");
			modelBuilder.Entity<PremierLeague>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
			modelBuilder.Entity<PremierLeague>().Property(u => u.Club).HasColumnName("Club");
			modelBuilder.Entity<PremierLeague>().Property(u => u.Pais).HasColumnName("Pais");
			modelBuilder.Entity<PremierLeague>().Property(u => u.Fundacion).HasColumnName("Fundacion");
			modelBuilder.Entity<PremierLeague>().Property(u => u.Estadio).HasColumnName("Estadio");

            // Configuración para La Liga
			modelBuilder.Entity<Laliga>().ToTable("LaLiga");
			modelBuilder.Entity<Laliga>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
			modelBuilder.Entity<Laliga>().Property(u => u.Club).HasColumnName("Club");
			modelBuilder.Entity<Laliga>().Property(u => u.Pais).HasColumnName("Pais");
			modelBuilder.Entity<Laliga>().Property(u => u.Fundacion).HasColumnName("Fundacion");
			modelBuilder.Entity<Laliga>().Property(u => u.Estadio).HasColumnName("Estadio");

			// Configuración para Serie A
			modelBuilder.Entity<SerieA>().ToTable("SerieA");
			modelBuilder.Entity<SerieA>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
			modelBuilder.Entity<SerieA>().Property(u => u.Club).HasColumnName("Club");
			modelBuilder.Entity<SerieA>().Property(u => u.Pais).HasColumnName("Pais");
			modelBuilder.Entity<SerieA>().Property(u => u.Fundacion).HasColumnName("Fundacion");
			modelBuilder.Entity<SerieA>().Property(u => u.Estadio).HasColumnName("Estadio");
			
			// Configuración para Bundesliga
			modelBuilder.Entity<Bundesliga>().ToTable("Bundesliga");
			modelBuilder.Entity<Bundesliga>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
			modelBuilder.Entity<Bundesliga>().Property(u => u.Club).HasColumnName("Club");
			modelBuilder.Entity<Bundesliga>().Property(u => u.Pais).HasColumnName("Pais");
			modelBuilder.Entity<Bundesliga>().Property(u => u.Fundacion).HasColumnName("Fundacion");
			modelBuilder.Entity<Bundesliga>().Property(u => u.Estadio).HasColumnName("Estadio");
			

			// Configuración para Ligue 1
			modelBuilder.Entity<Ligue1>().ToTable("Ligue1");
			modelBuilder.Entity<Ligue1>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
			modelBuilder.Entity<Ligue1>().Property(u => u.Club).HasColumnName("Club");
			modelBuilder.Entity<Ligue1>().Property(u => u.Pais).HasColumnName("Pais");
			modelBuilder.Entity<Ligue1>().Property(u => u.Fundacion).HasColumnName("Fundacion");
			modelBuilder.Entity<Ligue1>().Property(u => u.Estadio).HasColumnName("Estadio");
			

		}

		public async Task<bool> SaveAsync()
		{
			return await SaveChangesAsync() > 0;
		}
	}
}