﻿namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string ImageFile { get; set; } = default!;

        public List<string> Catalog { get; set; } = new();

        public decimal Price {  get; set; }
    }
}
