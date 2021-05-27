using Microsoft.EntityFrameworkCore;

namespace DataBaseConfig
{
    public class ClashRoyaleDB : DbContext
    {
        // these properties map to tables in the database

        public ClashRoyaleDB() {}

        public ClashRoyaleDB(DbContextOptions<ClashRoyaleDB> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<ClanMember> ClanMembers {get; set;}
        public DbSet<PlayerChallenge> PlayerChallenges {get; set;}
        public DbSet<Challenge> Challenges {get; set;}
        public DbSet<War> Wars {get; set;}
        public DbSet<WarClan> WarClans {get; set;}
        public DbSet<Region> Regions {get; set;}
        public DbSet<SpellCard> SpellCards {get; set;}
        public DbSet<PlayerSpellCard> PlayerSpellCards {get; set;}
        public DbSet<StructureCard> StructureCards {get; set;}
        public DbSet<PlayerStructureCard> PlayerStructureCards {get; set;}
        public DbSet<MeleeCard> MeleeCards {get; set;}
        public DbSet<PlayerMeleeCard> PlayerMeleeCards {get; set;}
        public DbSet<Battle> Battles {get; set;}
        public DbSet<MeleeCardDonation> MeleeCardDonations {get; set;}
        public DbSet<SpellCardDonation> SpellCardDonations {get; set;}
        public DbSet<StructureCardDonation> StructureCardDonations {get; set;}
        protected override void OnConfiguring(

        DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(
            System.Environment.CurrentDirectory, "ClashRoyale.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ClanMember>(entity => 
            {
                entity.HasKey( x => new {x.PlayerID, x.ClanID});
            });
            modelBuilder.Entity<PlayerChallenge>(entity => {

                entity.HasKey( x => new {x.PlayerID, x.ChallengeID});

                entity.HasOne(p => p.Player)
                    .WithMany(p => p.PlayerChallenges)
                    .HasForeignKey(p => p.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(c => c.Challenge)
                    .WithMany(c => c.PlayerChallenges)
                    .HasForeignKey(c => c.ChallengeID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WarClan>(entity => {

                entity.HasKey( x => new {x.ClanID, x.WarID});

                entity.HasOne(c => c.Clan)
                    .WithMany(c => c.WarClans)
                    .HasForeignKey(c => c.ClanID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                entity.HasOne(w => w.War)
                    .WithMany(w => w.WarClans)
                    .HasForeignKey(w => w.WarID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PlayerSpellCard>(entity => {

                entity.HasKey( x => new {x.PlayerID, x.CardID});

                entity.HasOne(p => p.Player)
                    .WithMany(p => p.PlayerSpellCards)
                    .HasForeignKey(p => p.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(c => c.SpellCard)
                    .WithMany(c => c.PlayerSpellCards)
                    .HasForeignKey(c => c.CardID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<SpellCard>(entity => {
                entity.HasKey( x => x.CardID);
            });

            modelBuilder.Entity<PlayerStructureCard>(entity => {

                entity.HasKey( x => new {x.PlayerID, x.CardID});

                entity.HasOne(p => p.Player)
                    .WithMany(p => p.PlayerStructureCards)
                    .HasForeignKey(p => p.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(c => c.StructureCard)
                    .WithMany(c => c.PlayerStructureCards)
                    .HasForeignKey(c => c.CardID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<StructureCard>(entity => {
                entity.HasKey(x => x.CardID);
            });

            modelBuilder.Entity<PlayerMeleeCard>(entity => {

                entity.HasKey( x => new {x.PlayerID, x.CardID});

                entity.HasOne(p => p.Player)
                    .WithMany(p => p.PlayerMeleeCards)
                    .HasForeignKey(p => p.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(c => c.MeleeCard)
                    .WithMany(c => c.PlayerMeleeCards)
                    .HasForeignKey(c => c.CardID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<MeleeCard>(entity => {
                entity.HasKey(x => x.CardID);
            });

            modelBuilder.Entity<Battle>(entity => {

                entity.HasOne(x => x.Player1)
                    .WithMany(x => x.Battles)
                    .HasForeignKey(x => x.Player1ID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MeleeCardDonation>(entity => {

                entity.HasKey(x => x.DonationID);

                entity.HasOne(x => x.Player)
                    .WithMany(x => x.MeleeCardDonations)
                    .HasForeignKey(x => x.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                entity.HasOne(x => x.MeleeCard)
                    .WithMany(x => x.MeleeCardDonations)
                    .HasForeignKey(x => x.CardID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.Clan)
                    .WithMany(x => x.MeleeCardDonations)
                    .HasForeignKey(x => x.ClanID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.Region)
                    .WithMany(x => x.MeleeCardDonations)
                    .HasForeignKey(x => x.RegionID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<SpellCardDonation>(entity => {

                entity.HasKey(x => x.DonationID);

                entity.HasOne(x => x.Player)
                    .WithMany(x => x.SpellCardDonations)
                    .HasForeignKey(x => x.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                entity.HasOne(x => x.SpellCard)
                    .WithMany(x => x.SpellCardDonations)
                    .HasForeignKey(x => x.CardID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.Clan)
                    .WithMany(x => x.SpellCardDonations)
                    .HasForeignKey(x => x.ClanID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.Region)
                    .WithMany(x => x.SpellCardDonations)
                    .HasForeignKey(x => x.RegionID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<StructureCardDonation>(entity => {

                entity.HasKey(x => x.DonationID);

                entity.HasOne(x => x.Player)
                    .WithMany(x => x.StructureCardDonations)
                    .HasForeignKey(x => x.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                entity.HasOne(x => x.StructureCard)
                    .WithMany(x => x.StructureCardDonations)
                    .HasForeignKey(x => x.CardID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.Clan)
                    .WithMany(x => x.StructureCardDonations)
                    .HasForeignKey(x => x.ClanID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(x => x.Region)
                    .WithMany(x => x.StructureCardDonations)
                    .HasForeignKey(x => x.RegionID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
        }
    }
}