
namespace Web_API_Kaab_Haak.DTOS;
public class CartItemDTO
{
    public int Id {get;set;}
    public int Price {get;set;}
    public int Quantity {get;set;}
    // public CartDTO CartDTO {get;set;}
    // public int ProductId {get;set;}
    public ProductDTO Product {get;set;}
}