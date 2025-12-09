using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevConnect.Models;

[Table("tb_Curtida")]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__tb_Curti__ED9C4F561FD157FB", IsUnique = true)]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__tb_Curti__ED9C4F5640FAA01A", IsUnique = true)]
[Index("IdUsuario", "IdPublicacao", Name = "UQ__tb_Curti__ED9C4F56CC11AB44", IsUnique = true)]
public partial class TbCurtida
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_Usuario")]
    public int IdUsuario { get; set; }

    [Column("id_Publicacao")]
    public int IdPublicacao { get; set; }

    [ForeignKey("IdPublicacao")]
    [InverseProperty("TbCurtida")]
    public virtual TbPublicacao IdPublicacaoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("TbCurtida")]
    public virtual TbUsuario IdUsuarioNavigation { get; set; } = null!;
}
