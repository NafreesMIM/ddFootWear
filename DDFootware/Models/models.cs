using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int ProductID { get; set; }

    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; }

    [Required]
    public int StockLevel { get; set; }
}

public class Order
{
    [Key]
    public int OrderID { get; set; }

    [ForeignKey("Product")]
    public int ProductID { get; set; }

    [Required]
    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    [Required]
    [MaxLength(50)]
    public string OrderStatus { get; set; }

    public virtual Product Product { get; set; }
}


public class OrderItem
{
    [Key]
    public int OrderItemID { get; set; }

    [ForeignKey("Order")]
    public int OrderID { get; set; }

    [Required]
    public int Quantity { get; set; }

    public virtual Order Order { get; set; }
}

public class Outlet
{
    [Key]
    public int OutletID { get; set; }

    [Required]
    [MaxLength(255)]
    public string OutletName { get; set; }
}

public class OutletStock
{
    [Key]
    public int OutletStockID { get; set; }

    [ForeignKey("Outlet")]
    public int OutletID { get; set; }

    [ForeignKey("Product")]
    public int ProductID { get; set; }

    [Required]
    public int StockLevel { get; set; }

    public virtual Outlet Outlet { get; set; }
    public virtual Product Product { get; set; }
}

public class WebOrder
{
    [Key]
    public int WebOrderID { get; set; }

    [ForeignKey("Product")]
    public int ProductID { get; set; }

    [Required]
    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    [Required]
    [MaxLength(50)]
    public string OrderStatus { get; set; }

    public virtual Product Product { get; set; }
}

public class PreOrder
{
    [Key]
    public int PreOrderID { get; set; }

    [ForeignKey("Product")]
    public int ProductID { get; set; }

    [Required]
    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    [Required]
    public int Priority { get; set; }

    public virtual Product Product { get; set; }
}

public class User
{
    [Key]
    public int UserID { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; }

    [Required]
    [MaxLength(50)]
    public string Role { get; set; }
}

public class AuthenticationToken
{
    [Key]
    public int TokenID { get; set; }

    [ForeignKey("User")]
    public int UserID { get; set; }

    [Required]
    [MaxLength(255)]
    public string TokenValue { get; set; }

    [Required]
    public DateTime ExpiryDateTime { get; set; }

    public virtual User User { get; set; }
}