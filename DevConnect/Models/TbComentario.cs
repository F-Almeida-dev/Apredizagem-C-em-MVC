using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnect.Models;

[Table("tb_Comentario")]
public partial class TbComentario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("texto")]
    [StringLength(300)]
    public string Texto { get; set; } = null!;

    [Column("dataComentario")]
    public DateOnly DataComentario { get; set; }

    [Column("id_Publicacao")]
    public int IdPublicacao { get; set; }

    [Column("id_Usuario")]
    public int IdUsuario { get; set; }

    [ForeignKey("IdPublicacao")]
    [InverseProperty("TbComentario")]
    public virtual TbPublicacao IdPublicacaoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("TbComentario")]
    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;
}
