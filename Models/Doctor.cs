using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ch11.Models;

[Table("Doctor")]
public partial class Doctor
{
    [Key]
    [Column("DoctorID")]
    public int DoctorId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Specialty { get; set; }

    public int? YearsExperience { get; set; }

    [InverseProperty("Doctor")]
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    [InverseProperty("Doctor")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
