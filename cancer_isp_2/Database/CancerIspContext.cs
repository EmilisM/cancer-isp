using Microsoft.EntityFrameworkCore;

namespace cancer_isp_2.Database
{
    public class CancerIspContext : DbContext
    {
        public CancerIspContext()
        {
        }

        public CancerIspContext(DbContextOptions<CancerIspContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistAlbum> ArtistAlbum { get; set; }
        public virtual DbSet<ArtistSong> ArtistSong { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSong { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<SongGenre> SongGenre { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=cancer_isp_2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album", "cancer_isp_2");

                entity.HasIndex(e => e.ImageId)
                    .HasName("image_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageId)
                    .HasColumnName("image_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("album_ibfk_1");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist", "cancer_isp_2");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OriginDate)
                    .HasColumnName("origin_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Artist)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artist_ibfk_1");
            });

            modelBuilder.Entity<ArtistAlbum>(entity =>
            {
                entity.HasKey(e => new {e.ArtistId, e.AlbumId});

                entity.ToTable("artist_album", "cancer_isp_2");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("album_id");

                entity.Property(e => e.ArtistId)
                    .HasColumnName("artist_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AlbumId)
                    .HasColumnName("album_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artist_album_ibfk_2");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artist_album_ibfk_1");
            });

            modelBuilder.Entity<ArtistSong>(entity =>
            {
                entity.HasKey(e => new {e.SongId, e.ArtistId});

                entity.ToTable("artist_song", "cancer_isp_2");

                entity.HasIndex(e => e.ArtistId)
                    .HasName("artist_id");

                entity.Property(e => e.SongId)
                    .HasColumnName("song_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtistId)
                    .HasColumnName("artist_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artist_song_ibfk_2");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artist_song_ibfk_1");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre", "cancer_isp_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image", "cancer_isp_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("playlist", "cancer_isp_2");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Playlist)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("playlist_ibfk_1");
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.HasKey(e => new {e.PlaylistId, e.SongId});

                entity.ToTable("playlist_song", "cancer_isp_2");

                entity.HasIndex(e => e.SongId)
                    .HasName("song_id");

                entity.Property(e => e.PlaylistId)
                    .HasColumnName("playlist_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SongId)
                    .HasColumnName("song_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistSong)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playlist_song_ibfk_1");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.PlaylistSong)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("playlist_song_ibfk_2");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("rating", "cancer_isp_2");

                entity.HasIndex(e => e.SongId)
                    .HasName("song_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("date");

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SongId)
                    .HasColumnName("song_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rating_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rating_ibfk_2");
            });


            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("report", "cancer_isp_2");

                entity.HasIndex(e => e.SongId)
                    .HasName("song_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reason)
                    .HasColumnName("comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SongId)
                    .HasColumnName("song_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("song", "cancer_isp_2");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("album_id");

                entity.HasIndex(e => e.ImageId)
                    .HasName("image_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AlbumId)
                    .HasColumnName("album_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImageId)
                    .HasColumnName("image_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LengthInSeconds)
                    .HasColumnName("length_in_seconds")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.YoutubeVideoId)
                    .HasColumnName("youtube_video_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("song_ibfk_2");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("song_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("song_ibfk_3");
            });

            modelBuilder.Entity<SongGenre>(entity =>
            {
                entity.HasKey(e => new {e.SongId, e.GenreId});

                entity.ToTable("song_genre", "cancer_isp_2");

                entity.HasIndex(e => e.GenreId)
                    .HasName("genre_id");

                entity.Property(e => e.SongId)
                    .HasColumnName("song_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SongGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("song_genre_ibfk_2");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Genres)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("song_genre_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "cancer_isp_2");

                entity.HasIndex(e => e.UserProfileId)
                    .HasName("user_profile_id")
                    .IsUnique();

                entity.HasIndex(e => e.UserRoleId)
                    .HasName("user_role_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KarmaPoints)
                    .HasColumnName("karma_points")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("password_hash")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasColumnName("password_salt")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");

                entity.Property(e => e.UserProfileId)
                    .HasColumnName("user_profile_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserRoleId)
                    .HasColumnName("user_role_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserProfile)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.UserProfileId)
                    .HasConstraintName("user_ibfk_2");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("user_ibfk_1");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("user_profile", "cancer_isp_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role", "cancer_isp_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}