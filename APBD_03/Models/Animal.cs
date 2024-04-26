﻿using System.ComponentModel.DataAnnotations;

namespace APBD_03.Models;

public class Animal
{
    
    public int IdAnimal { get; set; }
    [StringLength(200)]
    [Required]
    public string Name { get; set; }
    [StringLength(200)]
    public string? Description { get; set; }
    [StringLength(200)]
    [Required]
    public string Category { get; set; }
    [StringLength(200)]
    [Required]
    public string Area { get; set; }
    
}