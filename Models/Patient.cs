using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ch11.Models;

[Table("Patient")]
public partial class Patient
{
    [Key]
    [Column("UR_Number")]
    public int UrNumber { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? Address { get; set; }

    public int? Age { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MedicareCardNumber { get; set; }

    [Column("DoctorID")]
    public int? DoctorId { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Patients")]
    public virtual Doctor? Doctor { get; set; }

    [InverseProperty("UrNumberNavigation")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
