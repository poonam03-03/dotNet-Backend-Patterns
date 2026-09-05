using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProcedureCRUD.Models;

public partial class ProcedureDbContext : DbContext
{
    public ProcedureDbContext()
    {
    }

    public ProcedureDbContext(DbContextOptions<ProcedureDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientMaster> ClientMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DELL\\SQLEXPRESS; Initial Catalog=ProcedureDB; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientMaster>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__ClientMa__E67E1A24C27F7E4B");

            entity.ToTable("ClientMaster");

            entity.Property(e => e.AddedOn).HasColumnType("datetime");
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
