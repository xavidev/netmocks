using System;


namespace Mocks
{
    public class Stock
    {
        public Stock()
        {
        }

        public Product GetProductWithCode(string productCode)
        {
            return new Product();
        }
    }
}