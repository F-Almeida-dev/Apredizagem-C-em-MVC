using System;
using System.Collections.Generic;
using DevConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace DevConnect.Contexts;

public partial class DevConnectContext : DbContext
{
    public DevConnectContext()
    {
    }

    public DevConnectContext(DbContextOptions<DevConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbComentario> TbComentario { get; set; }

    public virtual DbSet<TbCurtida> TbCurtida { get; set; }

    public virtual DbSet<TbPublicacao> TbPublicacao { get; set; }

    public virtual DbSet<TbUsuario> TbUsuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DevCon_SA");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbComentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Comen__3213E83F3409B55D");

            entity.HasOne(d => d.IdPublicacaoNavigation).WithMany(p => p.TbComentario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_Coment__id_Pu__571DF1D5");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TbComentario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_Coment__id_Us__5812160E");
        });

        modelBuilder.Entity<TbCurtida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Curti__3213E83F5B863CF6");

            entity.HasOne(d => d.IdPublicacaoNavigation).WithMany(p => p.TbCurtida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_Curtid__id_Pu__5441852A");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TbCurtida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tb_Curtid__id_Us__534D60F1");
        });

        modelBuilder.Entity<TbPublicacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Publi__3213E83F036A6355");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TbPublicacao).HasConstraintName("FK__tb_Public__id_Us__5070F446");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Usuar__3213E83F98325225");

            entity.HasMany(d => d.IdUsuarioSeguido).WithMany(p => p.IdUsuarioSeguir)
                .UsingEntity<Dictionary<string, object>>(
                    "TbSeguidor",
                    r => r.HasOne<TbUsuario>().WithMany()
                        .HasForeignKey("IdUsuarioSeguido")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tb_Seguid__id_Us__05D8E0BE"),
                    l => l.HasOne<TbUsuario>().WithMany()
                        .HasForeignKey("IdUsuarioSeguir")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tb_Seguid__id_Us__04E4BC85"),
                    j =>
                    {
                        j.HasKey("IdUsuarioSeguir", "IdUsuarioSeguido").HasName("PK__tb_Segui__134B0CB3BF5F9629");
                        j.ToTable("tb_Seguidor");
                        j.IndexerProperty<int>("IdUsuarioSeguir").HasColumnName("id_Usuario_Seguir");
                        j.IndexerProperty<int>("IdUsuarioSeguido").HasColumnName("id_Usuario_Seguido");
                    });

            entity.HasMany(d => d.IdUsuarioSeguir).WithMany(p => p.IdUsuarioSeguido)
                .UsingEntity<Dictionary<string, object>>(
                    "TbSeguidor",
                    r => r.HasOne<TbUsuario>().WithMany()
                        .HasForeignKey("IdUsuarioSeguir")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tb_Seguid__id_Us__04E4BC85"),
                    l => l.HasOne<TbUsuario>().WithMany()
                        .HasForeignKey("IdUsuarioSeguido")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tb_Seguid__id_Us__05D8E0BE"),
                    j =>
                    {
                        j.HasKey("IdUsuarioSeguir", "IdUsuarioSeguido").HasName("PK__tb_Segui__134B0CB3BF5F9629");
                        j.ToTable("tb_Seguidor");
                        j.IndexerProperty<int>("IdUsuarioSeguir").HasColumnName("id_Usuario_Seguir");
                        j.IndexerProperty<int>("IdUsuarioSeguido").HasColumnName("id_Usuario_Seguido");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
