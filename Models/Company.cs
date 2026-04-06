using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ch11.Models;

[Table("Company")]
public partial class Company
{
    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string CompanyName { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [InverseProperty("CompanyNameNavigation")]
    public virtual ICollection<Drug> Drugs { get; set; } = new List<Drug>();
}
