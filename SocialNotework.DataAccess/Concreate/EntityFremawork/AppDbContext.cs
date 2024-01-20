using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Configration;
using SocialNetwork.Core.Entities.Concreate;
using SocialNotework.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNotework.DataAccess.Concreate.EntityFremawork
{
    public class AppDBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DataBaseConfigration.ConnectionString);
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserRole> GetAppUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendList>().HasKey(e => e.Id);

            modelBuilder.Entity<FriendList>().HasOne(z =>z.User)
                .WithMany(x =>x.FriendLists)
                .HasForeignKey(e => e.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>().
                HasOne(e => e.User).WithMany()
                .HasForeignKey(x =>x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reaction>().
                  HasOne(e => e.User).WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
