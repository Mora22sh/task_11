using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ch11.Models;

[Table("Prescription")]
public partial class Prescription
{
    [Key]
    [Column("PrescriptionID")]
    public int PrescriptionId { get; set; }

    [Column("DoctorID")]
    public int? DoctorId { get; set; }

    [Column("UR_Number")]
    public int? UrNumber { get; set; }

    [Column("DrugID")]
    public int? DrugId { get; set; }

    public DateOnly? Date { get; set; }

    public int? Quantity { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Prescriptions")]
    public virtual Doctor? Doctor { get; set; }

    [ForeignKey("DrugId")]
    [InverseProperty("Prescriptions")]
    public virtual Drug? Drug { get; set; }

    [ForeignKey("UrNumber")]
    [InverseProperty("Prescriptions")]
    public virtual Patient? UrNumberNavigation { get; set; }
}
