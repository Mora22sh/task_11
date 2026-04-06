using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ch11.Models;

[Table("Drug")]
public partial class Drug
{
    [Key]
    [Column("DrugID")]
    public int DrugId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TradeName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Strength { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CompanyName { get; set; }

    [ForeignKey("CompanyName")]
    [InverseProperty("Drugs")]
    public virtual Company? CompanyNameNavigation { get; set; }

    [InverseProperty("Drug")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
