﻿namespace WebApi.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; } = DateTime.Now;

}
