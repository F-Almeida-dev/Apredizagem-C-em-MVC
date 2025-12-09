using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnect.Models;

[Table("tb_Usuario")]
[Index("NomeDeUsuario", Name = "UQ__tb_Usuar__70ECC7B2CADE39F3", IsUnique = true)]
[Index("Email", Name = "UQ__tb_Usuar__AB6E6164BF314300", IsUnique = true)]
public partial class TbUsuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nomeCompleto")]
    [StringLength(255)]
    public string NomeCompleto { get; set; } = null!;

    [Column("nomeDeUsuario")]
    [StringLength(20)]
    public string NomeDeUsuario { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("senha")]
    [StringLength(50)]
    public string Senha { get; set; } = null!;

    [Column("fotoPerfilUrl")]
    [StringLength(255)]
    public string? FotoPerfilUrl { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<TbComentario> TbComentario { get; set; } = new List<TbComentario>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<TbCurtida> TbCurtida { get; set; } = new List<TbCurtida>();

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<TbPublicacao> TbPublicacao { get; set; } = new List<TbPublicacao>();

    [ForeignKey("IdUsuarioSeguir")]
    [InverseProperty("IdUsuarioSeguir")]
    public virtual ICollection<TbUsuario> IdUsuarioSeguido { get; set; } = new List<TbUsuario>();

    [ForeignKey("IdUsuarioSeguido")]
    [InverseProperty("IdUsuarioSeguido")]
    public virtual ICollection<TbUsuario> IdUsuarioSeguir { get; set; } = new List<TbUsuario>();
}
