using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasketballPlayerApi.Models
{
    public partial class SampleDatabaseContext : DbContext
    {
        public SampleDatabaseContext()
        {
        }

        public SampleDatabaseContext( DbContextOptions<SampleDatabaseContext> options )
            : base( options )
        {
        }

        public virtual DbSet<Player> Players { get; set; } = null!;
        //public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            if ( !optionsBuilder.IsConfigured )
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer( "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Databases\\SampleDB.mdf;Integrated Security=True;Connect Timeout=30" );
            }
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Player>( entity =>
            {
                entity.ToTable( "Player" );

                entity.Property( e => e.PlayerId ).HasColumnName( "playerId" );

                entity.Property( e => e.JerseyNumber ).HasColumnName( "jerseyNumber" );

                entity.Property( e => e.Name )
                    .HasMaxLength( 50 )
                    .IsUnicode( false )
                    .HasColumnName( "name" );
            } );

            OnModelCreatingPartial( modelBuilder );
        }

        partial void OnModelCreatingPartial( ModelBuilder modelBuilder );
    }
}
