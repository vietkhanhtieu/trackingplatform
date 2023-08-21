using Newtonsoft.Json;
using WooCommerceNET;
using WooCommerceNET.Base;
using WooCommerceNET.WooCommerce.v3;

namespace trackingPlatform.RestClients
{
    public class WooCommerceService
    {

        private const string Url = "https://trungtamduocpham.com/wp-json/wc/v3/";
        private const string ConsumerKey = "ck_540a2b7c274f2ddda1c0c86595f871d0a143e6bb";
        private const string ConsumerSecret = "cs_881aa44342a68706b80d950d9f5eefda9925db7d";
        private const string BatchUpdateProductsEndPoint = "products/batch";
        private const string BatchUpdateProductCategoriesEndPoint = "products/categories/batch";
        private const string ProductCategoriesEndPoint = "products/categories";
        private const string UpdateProductCategoriesEndPoint = "products/categories/{0}";
        private const string ProductsEndPoint = "products";

        private const ulong IdDanhMucHoatChat = 258;
        private const ulong IdDanhMucChungBenh = 33;
        private const ulong IdDanhMucCoQuan = 466;

        private RestAPI _wooRestApi;

        public WooCommerceService()
        {
            _wooRestApi = new RestAPI(Url, ConsumerKey, ConsumerSecret);
        }

        public async Task<List<BatchObject<Product>>> BatchUpdateProducts(List<BatchObject<Product>> productBatches)
        {
            List<BatchObject<Product>?> result = new List<BatchObject<Product>?>();
            foreach (BatchObject<Product> productBatch in productBatches)
            {
                result.Add(JsonConvert.DeserializeObject<BatchObject<Product>>(await _wooRestApi.PostRestful(BatchUpdateProductsEndPoint, productBatch)));
            }
            return result;
        }

        public async Task<List<BatchObject<ProductCategory>>> BatchUpdateProductCategories(List<BatchObject<ProductCategory>> productCategoryBatchObjects)
        {
            List<BatchObject<ProductCategory>?> result = new List<BatchObject<ProductCategory>?>();
            foreach (BatchObject<ProductCategory> productCategoryBatchObject in productCategoryBatchObjects)
            {
                result.Add(JsonConvert.DeserializeObject<BatchObject<ProductCategory>>(await _wooRestApi.PostRestful(BatchUpdateProductCategoriesEndPoint, productCategoryBatchObject)));
            }
            return result;
        }

        public async Task<ProductCategory> CreateHoatChat(string name)
        {
            ProductCategory productCategory = await CreateProductCategory(name);
            productCategory.parent = IdDanhMucHoatChat;
            return await UpdateProductCategory(productCategory);
        }

        public async Task<ProductCategory> CreateDmsptcb(string name)
        {
            ProductCategory productCategory = await CreateProductCategory(name);
            productCategory.parent = IdDanhMucChungBenh;
            return await UpdateProductCategory(productCategory);
        }

        public async Task<ProductCategory> CreateDmsptcq(string name)
        {
            ProductCategory productCategory = await CreateProductCategory(name);
            productCategory.parent = IdDanhMucCoQuan;
            return await UpdateProductCategory(productCategory);
        }

        public async Task<ProductCategory> CreateProductCategory(string name)
        {
            return JsonConvert.DeserializeObject<ProductCategory>(await _wooRestApi.PostRestful(ProductCategoriesEndPoint, new ProductCategory()
            {
                name = name
            }))!;
        }

        public async Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory)
        {
            return JsonConvert.DeserializeObject<ProductCategory>(await _wooRestApi.PutRestful(
                string.Format(UpdateProductCategoriesEndPoint, productCategory.id), productCategory))!;
        }

        public async Task<ProductCategory> GetProductCategory(string slug)
        {
            Dictionary<string, string> _params = new Dictionary<string, string> { { "slug", slug } };
            List<ProductCategory> productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>(await _wooRestApi.GetRestful(ProductCategoriesEndPoint, _params))!;
            if (productCategories.Count == 0)
            {
                return null!;
            }
            return productCategories[0];
        }

        public async Task<Product> GetProduct(string sku)
        {
            Dictionary<string, string> _params = new Dictionary<string, string> { { "sku", sku } };
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(await _wooRestApi.GetRestful(ProductsEndPoint, _params))!;
            if (products.Count == 0)
            {
                return null!;
            }
            return products[0];
        }
    }
}
