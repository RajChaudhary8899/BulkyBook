﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;

public class Category
{
    // entity Framework

    [Key]  //anotation
    public int Id { get; set; }

    [Required] // attribute is used for not null property
    public string Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 200, ErrorMessage = "Display Order must be between 1 to 200!!")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

}

