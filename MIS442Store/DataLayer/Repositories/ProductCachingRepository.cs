using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductCachingRepository : ProductRepository
    {
        public override List<Product>GetList()
        {
            List<Product> product = null;   
            product = (List<Product>)HttpRuntime.Cache["ProductList"];
            if (product == null)
            {
                product = base.GetList();
                HttpRuntime.Cache["ProductList"] = product;
            }
            return product;
        }
        public override void Save (Product product)
        {
            base.Save(product);
            HttpRuntime.Cache.Remove("ProductList");
        }
        public override Product Get(int id)
        {
            return base.Get(id);
        }
    }
}