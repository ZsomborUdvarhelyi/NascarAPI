using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NascarAPI.Models;

public partial class RaceWinner
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int? Year { get; set; }

    public int? NoRaces { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DriverName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CarMake { get; set; }
}
