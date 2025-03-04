﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstAPIProject.Validators;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIProject.DAL.Models;

[Index("DoctorId", Name = "IX_Appointments_DoctorId")]
[Index("PatientId", Name = "IX_Appointments_PatientId")]
public partial class Appointment
{
    [Key]
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }


    [DateInFuture(ErrorMessage = "Please Enter Future Date")]
    public DateTime AppointmentDateTime { get; set; }

    [Required]
    public string Status { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Appointments")]
    public virtual Doctor Doctor { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Appointments")]
    public virtual Patient Patient { get; set; }
}