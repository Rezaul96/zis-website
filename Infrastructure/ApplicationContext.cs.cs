using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Transactions;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public virtual DbSet<EventShare> EventShares { get; set; }
        public virtual DbSet<EventSequenceObject> EventSequenceObjects { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<BroadcastImage> BroadcastImages { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventObject> EventObjects { get; set; }
        public virtual DbSet<EventObjectDetail> EventObjectDetails { get; set; }
        public virtual DbSet<EventScorerecord> EventScorerecords { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<ObjectType> ObjectTypes { get; set; }
        public virtual DbSet<ParticipantImage> ParticipantImages { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Sequence> Sequences { get; set; }
        public virtual DbSet<SequenceObject> SequenceObjects { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Entity<Branch>().HasOne(e => e.Area).WithMany().OnDelete(DeleteBehavior.Restrict); 
            //modelBuilder.Entity<Branch>().HasOne(e => e.City).WithMany().OnDelete(DeleteBehavior.Restrict); 
            base.OnModelCreating(modelBuilder);

        }
    }
}