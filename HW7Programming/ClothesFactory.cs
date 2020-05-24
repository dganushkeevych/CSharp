using Clothes_Factory.Abstract_products;
using Clothes_Factory.Products;

namespace Clothes_Factory
{
    interface ClothesFactory
    {
        Shirt CreateShirt();
        Trousers CreateTrousers();
    }
}