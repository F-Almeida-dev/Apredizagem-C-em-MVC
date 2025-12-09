using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CadAluno.Models;

public partial class CadAlunoContext : DbContext
{
    public CadAlunoContext()
    {
    }

    public CadAlunoContext(DbContextOptions<CadAlunoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Frutum> Fruta { get; set; }
    public virtual DbSet<Aluno> Alunos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NOTE13-S21\\SQLEXPRESS;Database=CadAluno;User Id=sa;Password=senai@134;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Frutum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__fruta__3213E83F33F8F091");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
