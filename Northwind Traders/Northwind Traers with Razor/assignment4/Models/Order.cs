﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace assignment4.Models;

[Table("orders")]
[Index("CustomerId", Name = "customer_id")]
[Index("CustomerId", Name = "customers_orders")]
[Index("EmployeeId", Name = "employee_id")]
[Index("EmployeeId", Name = "employees_orders")]
[Index("OrderDate", Name = "order_date")]
[Index("ShipPostalCode", Name = "ship_postal_code")]
[Index("ShippedDate", Name = "shipped_date")]
[Index("ShipVia", Name = "shippers_orders")]
public partial class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("customer_id")]
    [StringLength(5)]
    public string? CustomerId { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [Column("order_date", TypeName = "datetime")]
    [Display(Name = "Ordered")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? OrderDate { get; set; }

    [Column("required_date", TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column("shipped_date", TypeName = "datetime")]
    [Display(Name = "Shipped")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? ShippedDate { get; set; }

    [Column("ship_via")]
    [Display(Name = "Shipper")]
    public int? ShipVia { get; set; }

    [Column("freight", TypeName = "money")]
    [Display(Name = "Freight")]
    public decimal? Freight { get; set; }

    [Column("ship_name")]
    [StringLength(40)]
    [Display(Name = "Ship Name")]
    public string? ShipName { get; set; }

    [Column("ship_address")]
    [StringLength(60)]
    public string? ShipAddress { get; set; }

    [Column("ship_city")]
    [StringLength(15)]
    public string? ShipCity { get; set; }

    [Column("ship_region")]
    [StringLength(15)]
    [Display(Name = "Region")]
    public string? ShipRegion { get; set; }

    [Column("ship_postal_code")]
    [StringLength(10)]
    public string? ShipPostalCode { get; set; }

    [Column("ship_country")]
    [StringLength(15)]
    [Display(Name = "Country")]
    public string? ShipCountry { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Orders")]
    public virtual Employee? Employee { get; set; }

    [ForeignKey("ShipVia")]
    [InverseProperty("Orders")]
    public virtual Shipper? ShipViaNavigation { get; set; }
}
