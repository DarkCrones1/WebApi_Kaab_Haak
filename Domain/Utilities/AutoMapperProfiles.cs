using AutoMapper;
using Web_API_Kaab_Haak.Entities;
using Web_API_Kaab_Haak.DTOS;

namespace ApWeb_API_Kaab_HaakVie.Domain.Utilities;
public class AutoMapperProfiles :Profile
{
    public AutoMapperProfiles()
    {
        // Mapeo Brand
        CreateMap<BrandCDTO, Brand>().ForMember(x => x.Image, options => options.Ignore());
        CreateMap<Brand, BrandDTO>();
        CreateMap<BrandPatchDTO, Brand>().ReverseMap();

        // Mapeo Category
        CreateMap<CategoryCDTO, Category>().ForMember(x => x.Image, options => options.Ignore());
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryPatchDTO, Category>().ReverseMap();

        // Mapeo Product
        CreateMap<ProductCDTO, Product>().ForMember(x => x.Image, options => options.Ignore());
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductPatchDTO, Product>().ReverseMap();

        //Mapeo Inventory
        CreateMap<InventoryCDTO, Inventory>();
        CreateMap<Inventory, InventoryDTO>();
        CreateMap<Inventory, InventoryDTOW>().ForMember(InventoryDTO => InventoryDTO.Stock, opcions => opcions.MapFrom(MapInventoryDTOProducts));

        //Mapeo Cart
        CreateMap<CartCDTO, Cart>();
        CreateMap<Cart, CartDTO>();
        CreateMap<Cart, CartDTOW>().ForMember(CartDTO => CartDTO.Items, opcions => opcions.MapFrom(MapCartDTOCartItems));

        //Mapeo CartItem
        CreateMap<CartItemCDTO, CartItem>();
        CreateMap<CartItem, CartItemDTO>();
        
        //Mapeo UserData
        CreateMap<UserDataCDTO, UserData>().ForMember(x => x.Image, options => options.Ignore());
        CreateMap<UserData, UserDataDTO>();
        CreateMap<UserDataPatchDTO, UserData>().ReverseMap();

        //Mapeo DataAddress
        CreateMap<UserAddressCDTO, UserAddress>();
        CreateMap<UserAddress, UserAddressDTO>();
        CreateMap<UserAddressPatchDTO, UserAddress>().ReverseMap();

        //Mapeo Order
        CreateMap<OrderCDTO, Order>();
        CreateMap<Order, OrderDTO>();

        //Mapeo PaymentMethod
        // CreateMap<PaymentMethodCDTO, PaymentMethod>();
        //CreateMap<PaymentMethod, PaymentMethodDTO>();

        //Mapeo Sucursal
        // CreateMap<SucursalCDTO, Sucursal>();
        // CreateMap<Sucursal, SucursalDTO>();
    }

    

    private List<ProductDTO> MapInventoryDTOProducts(Inventory inventory, InventoryDTO inventoryDTO){
        var result = new List<ProductDTO>();

        if(inventory.Stock == null){
            return result;
        }

        foreach (var Product in inventory.Stock){
            result.Add(new ProductDTO{
                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price
            });
        }

        return result;
    }

    private List<CartItemDTO> MapCartDTOCartItems(Cart cart, CartDTO cartDTO){
        var result = new List<CartItemDTO>();

        if(cart.Items == null){
            return result;
        }

        foreach (var item in cart.Items){
            result.Add(new CartItemDTO{
                Id = item.Id,
                Price = item.Price,
                Quantity = item.Quantity,
                
            });
        }

        return result;
    }
}