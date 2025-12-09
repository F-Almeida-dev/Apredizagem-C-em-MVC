using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CadAluno.Models;

[Table("fruta")]
public partial class Frutum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Cor { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Categoria { get; set; } = null!;
}
