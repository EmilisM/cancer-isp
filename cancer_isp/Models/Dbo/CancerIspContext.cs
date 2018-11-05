using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace cancer_isp.Models.Dbo
{
    public class CancerIspContext : DbContext
    {
        public CancerIspContext(DbContextOptions<CancerIspContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistCreated> ArtistCreated { get; set; }
        public virtual DbSet<ArtistWork> ArtistWork { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Statistic> Statistic { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfileInfo> UserProfileInfo { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<WorkType> WorkType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasIndex(e => e.FkOccupationid)
                    .HasName("has");

                entity.HasIndex(e => e.FkUserid)
                    .HasName("registers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FkOccupationid)
                    .HasColumnName("fk_Occupationid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUserid)
                    .HasColumnName("fk_Userid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OccupationStartDate)
                    .HasColumnName("occupation_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Pseudonym)
                    .HasColumnName("pseudonym")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.FkOccupation)
                    .WithMany(p => p.Artist)
                    .HasForeignKey(d => d.FkOccupationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("has");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Artist)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registers");
            });

            modelBuilder.Entity<ArtistCreated>(entity =>
            {
                entity.HasKey(e => new { e.FkArtistWorkid, e.FkArtistid });

                entity.HasIndex(e => e.FkArtistid)
                    .HasName("who_is");

                entity.Property(e => e.FkArtistWorkid)
                    .HasColumnName("fk_ArtistWorkid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FkArtistid)
                    .HasColumnName("fk_Artistid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.FkArtistWork)
                    .WithMany(p => p.ArtistCreated)
                    .HasForeignKey(d => d.FkArtistWorkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("created");

                entity.HasOne(d => d.FkArtist)
                    .WithMany(p => p.ArtistCreated)
                    .HasForeignKey(d => d.FkArtistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("who_is");
            });

            modelBuilder.Entity<ArtistWork>(entity =>
            {
                entity.HasIndex(e => e.FKGenreid)
                    .HasName("is_of");

                entity.HasIndex(e => e.FkImageid)
                    .HasName("is_preserved");

                entity.HasIndex(e => e.FkUserid)
                    .HasName("assigns");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FKGenreid)
                    .HasColumnName("fK_Genreid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkImageid)
                    .HasColumnName("fk_Imageid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUserid)
                    .HasColumnName("fk_Userid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LengthInSeconds)
                    .HasColumnName("length_in_seconds")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publish_date")
                    .HasColumnType("date");

                entity.Property(e => e.RecordLabel)
                    .HasColumnName("record_label")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.FKGenre)
                    .WithMany(p => p.ArtistWork)
                    .HasForeignKey(d => d.FKGenreid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("is_of");

                entity.HasOne(d => d.FkImage)
                    .WithMany(p => p.ArtistWork)
                    .HasForeignKey(d => d.FkImageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("is_preserved");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.ArtistWork)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assigns");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.FkArtistid)
                    .HasName("discusses");

                entity.HasIndex(e => e.FkUserid)
                    .HasName("writes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment1)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CommentDate)
                    .HasColumnName("comment_date")
                    .HasColumnType("date");

                entity.Property(e => e.FkArtistid)
                    .HasColumnName("fk_Artistid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUserid)
                    .HasColumnName("fk_Userid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.FkArtist)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.FkArtistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("discusses");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("writes");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.FkWorkTypeid)
                    .HasName("has_a");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FkWorkTypeid)
                    .HasColumnName("fk_WorkTypeid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.YearOfDiscovery)
                    .HasColumnName("year_of_discovery")
                    .HasColumnType("date");

                entity.HasOne(d => d.FkWorkType)
                    .WithMany(p => p.Genre)
                    .HasForeignKey(d => d.FkWorkTypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("has_a");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(e => e.FkArtistid)
                    .HasName("is_captured_in");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkArtistid)
                    .HasColumnName("fk_Artistid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageDate)
                    .HasColumnName("image_date")
                    .HasColumnType("date");

                entity.Property(e => e.ImageName)
                    .HasColumnName("image_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Photographer)
                    .HasColumnName("photographer")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.FkArtist)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.FkArtistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("is_captured_in");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasIndex(e => e.FkArtistWorkid)
                    .HasName("appreciates");

                entity.HasIndex(e => e.FkUserid)
                    .HasName("evaluates");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.FkArtistWorkid)
                    .HasColumnName("fk_ArtistWorkid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUserid)
                    .HasColumnName("fk_Userid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.FkArtistWork)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.FkArtistWorkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appreciates");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evaluates");
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.HasIndex(e => e.FkRatingid)
                    .HasName("evaluated");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkRatingid)
                    .HasColumnName("fk_Ratingid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.FkRating)
                    .WithMany(p => p.Statistic)
                    .HasForeignKey(d => d.FkRatingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evaluated");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.FkUserProfileInfoid)
                    .HasName("completes");

                entity.HasIndex(e => e.FkUserRoleid)
                    .HasName("assigned");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FkUserProfileInfoid)
                    .HasColumnName("fk_UserProfileInfoid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUserRoleid)
                    .HasColumnName("fk_UserRoleid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KarmaPoints)
                    .HasColumnName("karma_points")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("password_salt")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registration_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserState)
                    .HasColumnName("user_state")
                    .HasColumnType("varchar(255)")
                    .HasConversion(new EnumToStringConverter<UserStateEnum>());

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.FkUserProfileInfo)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.FkUserProfileInfoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("completes");

                entity.HasOne(d => d.FkUserRole)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.FkUserRoleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assigned");
            });

            modelBuilder.Entity<UserProfileInfo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasConversion(new EnumToStringConverter<UserRoleEnum>());
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });
        }
    }
}