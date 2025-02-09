using GameZone.Models;

namespace GameZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Categories> Categories { get; set; }
        public DbSet<Models.Device> Devices { get; set; }
        public DbSet<Models.Game> Games { get; set; }
        public DbSet<Models.GameDevice> GameDevices { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //#region BaseEntity With Fluent API
            //modelBuilder.Entity<BaseEntity>()
            //    .HasOne(b => b.ParentEntity)
            //    .WithMany()
            //    .HasForeignKey(b => b.ParentId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //#endregion

            #region Game And Devive with Fluent Api
            modelBuilder.Entity<Models.Game>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Models.Game>()
                .Property(e => e.Name)
                .HasMaxLength(300)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Models.Game>(G =>
            {
                G.Property(G => G.Description)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(300);
            });

            modelBuilder.Entity<Models.Game>(G =>
            {
                G.Property(G => G.Cover)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(300);
            });

            // Device :
            modelBuilder.Entity<Models.Device>()
                .HasKey(e => e.Id);
           
            modelBuilder.Entity<Models.Device>()
                .Property(e => e.Name)
                .HasMaxLength(300)
                .IsRequired()
                .IsUnicode(true);

            modelBuilder.Entity<Models.Device>(G =>
            {
                G.Property(G => G.Icon)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(300);
            });
            #endregion

            #region Game With Fluent API >> 1 to M game => category
            modelBuilder.Entity<Models.Game>(
                G =>
                {
                    G.HasOne(G => G.Categories)
                    .WithMany(C => C.Games)
                    .HasForeignKey(G => G.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);
                });
            #endregion

            #region GameDevice With Fluent API
            modelBuilder.Entity<GameDevice>()
                .HasKey(GD => new { GD.GameId, GD.DeviceId }); // ✅ المفتاح الأساسي المركب

            modelBuilder.Entity<GameDevice>()
                .HasOne(GD => GD.Game)
                .WithMany(G => G.Devices)
                .HasForeignKey(GD => GD.GameId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ الربط الصحيح

            modelBuilder.Entity<GameDevice>()
                .HasOne(GD => GD.Device)
                .WithMany(D => D.GameDevices) // ✅ تأكد أن `Device` يحتوي على `GameDevices`
                .HasForeignKey(GD => GD.DeviceId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Seed Data :
            modelBuilder.Entity<Models.Categories>().HasData(
                new Models.Categories[]
                {
                    new Models.Categories {Id= 1 , Name = "Sports" },
                    new Models.Categories {Id= 2 , Name = "Action" },
                    new Models.Categories {Id= 3 , Name = "Adventure" },
                    new Models.Categories {Id= 4 , Name = "Racing" },
                    new Models.Categories {Id= 5 , Name = "Fighting" },
                    new Models.Categories {Id= 6 , Name = "Film" }
                }
                );

            modelBuilder.Entity<Models.Device>()
                .HasData(new Models.Device[]
                {
                    new Models.Device {Id= 1 ,Name="PlyStation", Icon="bi bi-playstation" },
                    new Models.Device {Id= 2,Name="xbox", Icon="bi bi-xbox" },
                    new Models.Device {Id= 3 ,Name="Nintendo Switch", Icon="bi bi-nintendo-switch" },
                    new Models.Device {Id= 4 ,Name="Pc", Icon="bi bi-display" }
                });

            //modelBuilder.Entity<Game>().HasData(
            //    new Models.Game { Id = 100, Name = "FIFA 24", Description = "Football simulation game", Cover = "fifa24.jpg", CategoryId = 1 },
            //    new Models.Game { Id = 101, Name = "Call of Duty", Description = "First-person shooter", Cover = "cod.jpg", CategoryId = 2 },
            //    new Models.Game { Id = 102, Name = "The Legend of Zelda", Description = "Action-adventure game", Cover = "zelda.jpg", CategoryId = 3 },
            //    new Models.Game { Id = 103, Name = "Need for Speed", Description = "Racing game", Cover = "nfs.jpg", CategoryId = 4 },
            //    new Models.Game { Id = 104, Name = "Tekken 8", Description = "Fighting game", Cover = "tekken8.jpg", CategoryId = 5 },
            //    new Models.Game { Id = 105, Name = "Spider-Man 2", Description = "Superhero game", Cover = "spiderman2.jpg", CategoryId = 6 }
            //     );

            //modelBuilder.Entity<Models.GameDevice>().HasData(
            //    new Models.GameDevice { DeviceId = 1, GameId = 101 },
            //    new Models.GameDevice { DeviceId = 2, GameId = 100 },
            //    new Models.GameDevice { DeviceId = 3, GameId = 102 },
            //    new Models.GameDevice { DeviceId = 4, GameId = 103 }
            //    );

            #endregion





        }

    }
}
