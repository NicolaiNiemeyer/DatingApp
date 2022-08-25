using DatingApp.BL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.EntityFramework
{
  public class ApplicationDbContext : DbContext
  {
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    public DbSet<Chat> Chats { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Likes> Likes { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Gender> Genders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Chat>().Property(b =>
      b.ReadStatus).HasDefaultValueSql("0");

      modelBuilder.Entity<Likes>().Property(b =>
      b.IsDeleted).HasDefaultValueSql("0");

      modelBuilder.Entity<Account>().Property(b =>
      b.IsDeleted).HasDefaultValueSql("0");

      modelBuilder.Entity<Profile>().Property(b =>
      b.CreatedDate).HasDefaultValueSql("getdate()");



      modelBuilder.Entity<Chat>()
      .HasOne(p => p.ProfileSender)
      .WithMany(b => b.SendChats)
      .HasForeignKey(p => p.SenderId)
      .OnDelete(DeleteBehavior.NoAction);

      modelBuilder.Entity<Chat>()
      .HasOne(p => p.ProfileReceiver)
      .WithMany(b => b.ReceiveChats)
      .HasForeignKey(p => p.ReceiverId)
      .OnDelete(DeleteBehavior.NoAction);

      modelBuilder.Entity<Likes>()
      .HasOne(p => p.ProfileLiker)
      .WithMany(b => b.SentLikes)
      .HasForeignKey(p => p.LikerId)
      .OnDelete(DeleteBehavior.NoAction);

      modelBuilder.Entity<Likes>()
      .HasOne(p => p.ProfileLikee)
      .WithMany(b => b.ReceivedLikes)
      .HasForeignKey(p => p.LikeeId)
      .OnDelete(DeleteBehavior.NoAction);
    }
  }
}
