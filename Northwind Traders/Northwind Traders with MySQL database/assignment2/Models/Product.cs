using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace assignment2.Models;

[Table("products")]
[Index("CategoryId", Name = "categories_products")]
[Index("CategoryId", Name = "category_id")]
[Index("ProductName", Name = "product_name")]
[Index("SupplierId", Name = "supplier_id")]
[Index("SupplierId", Name = "suppliers_products")]
public partial class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_name")]
    [StringLength(40)]
    [Display(Name = "Product")]
    public string ProductName { get; set; } = null!;

    [Column("supplier_id")]
    [Display(Name ="Supplier")]
    public int? SupplierId { get; set; }

    [Column("category_id")]
    [Display(Name ="Category")]
    public int? CategoryId { get; set; }

    [Column("quantity_per_unit")]
    [Display(Name ="Quantity Per Unit")]
    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }

    [Column("unit_price", TypeName = "money")]
    [Display(Name = "Price")]
    public decimal? UnitPrice { get; set; }

    [Column("units_in_stock")]
    [Display(Name = "In Stock")]
    public short? UnitsInStock { get; set; }

    [Column("units_on_order")]
    [Display(Name = "Units on Order")]
    public short? UnitsOnOrder { get; set; }

    [Column("reorder_level")]
    [Display(Name ="Reorder Level")]
    public short? ReorderLevel { get; set; }

    [Column("discontinued")]
    [Display(Name = "Discontinued")]
    public bool Discontinued { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    [Display(Name = "Category")]
    public virtual Category? Category { get; set; }

    [ForeignKey("SupplierId")]
    [InverseProperty("Products")]
    [Display(Name = "Supplier")]
    public virtual Supplier? Supplier { get; set; }
}
