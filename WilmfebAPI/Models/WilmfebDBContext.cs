using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WilmfebAPI.Models
{
    public partial class WilmfebDBContext : DbContext
    {
        public WilmfebDBContext()
        {
        }

        public WilmfebDBContext(DbContextOptions<WilmfebDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CategoryToMovie> CategoryToMovie { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Queue> Queue { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Watched> Watched { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
               optionsBuilder.UseSqlServer("Server=DESKTOP-SNIOHDE\\SQLEXPRESS;Database=WilmfebDB_v3;Trusted_Connection=True;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.Property(e => e.IdCategory)
                    .HasColumnName("idCategory")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryToMovie>(entity =>
            {
                entity.HasKey(e => new { e.IdCategoryToMovie, e.IdMovie, e.IdCategory });

                entity.HasIndex(e => e.IdCategory)
                    .HasName("fkIdx_79");

                entity.HasIndex(e => e.IdMovie)
                    .HasName("fkIdx_76");

                entity.Property(e => e.IdCategoryToMovie).HasColumnName("idCategoryToMovie");

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.CategoryToMovie)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_79");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany(p => p.CategoryToMovies)
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_76");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                //entity.HasKey(e => new { e.IdComments, e.IdUser, e.IdMovie });
                entity.HasKey(e => e.IdComments);

                entity.HasIndex(e => e.IdMovie)
                    .HasName("fkIdx_59");

                entity.HasIndex(e => e.IdUser)
                    .HasName("fkIdx_56");

                entity.Property(e => e.IdComments).HasColumnName("idComments");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany(p => p.Commentss)
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_59");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_56");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                //entity.HasKey(e => new { e.IdFriend, e.IdUser1, e.IdUser2 });
                entity.HasKey(e => new { e.IdFriend });

                entity.HasIndex(e => e.IdUser1)
                    .HasName("fkIdx_12");

                entity.HasIndex(e => e.IdUser2)
                    .HasName("fkIdx_15");

                entity.Property(e => e.IdFriend).HasColumnName("idFriend");

                entity.Property(e => e.IdUser1).HasColumnName("idUser_1");

                entity.Property(e => e.IdUser2).HasColumnName("idUser_2");

                entity.HasOne(d => d.IdUser1Navigation)
                    .WithMany(p => p.FriendIdUser1Navigation)
                    .HasForeignKey(d => d.IdUser1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_12");

                entity.HasOne(d => d.IdUser2Navigation)
                    .WithMany(p => p.FriendIdUser2Navigation)
                    .HasForeignKey(d => d.IdUser2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_15");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie);

                entity.Property(e => e.IdMovie)
                    .HasColumnName("idMovie")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Director)
                    .HasColumnName("director")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Trailer)
                    .HasColumnName("trailer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                // entity.HasKey(e => new { e.IdQueue, e.IdUser, e.IdMovie });
                entity.HasKey(e => new { e.IdQueue });
                entity.HasIndex(e => e.IdMovie)
                    .HasName("fkIdx_41");

                entity.HasIndex(e => e.IdUser)
                    .HasName("fkIdx_38");

                entity.Property(e => e.IdQueue).HasColumnName("idQueue");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany(p => p.Queues)
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_41");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Queue)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_38");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("passwordHash")
                    .HasMaxLength(512);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("passwordSalt")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<Watched>(entity =>
            {
                //entity.HasKey(e => new { e.IdWatched, e.IdUser, e.IdMovie });
                entity.HasKey(e => new { e.IdWatched});

                entity.HasIndex(e => e.IdMovie)
                    .HasName("fkIdx_31");

                entity.HasIndex(e => e.IdUser)
                    .HasName("fkIdx_28");

                entity.Property(e => e.IdWatched).HasColumnName("idWatched");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany(p => p.Watcheds)
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_31");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Watched)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_28");
            });
        }
    }
}
