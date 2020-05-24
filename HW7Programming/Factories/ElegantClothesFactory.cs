using Clothes_Factory.Abstract_products;
using Clothes_Factory.Products;

namespace Clothes_Factory.Factories
{
    class ElegantClothesFactory : ClothesFactory
    {
        public Shirt CreateShirt()
        {
            return new DressShirt();
        }

        public Trousers CreateTrousers()
        {
            return new SuitTrousers();
        }
    }
}