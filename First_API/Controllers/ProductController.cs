using Microsoft.AspNetCore.Mvc;
using First_API.Model;
using First_API.DbConfig;
using First_API.JwtToken;
using Azure.Core;

namespace First_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;

        List<ProductModel> products = new List<ProductModel>
        {
            new ProductModel
            {
                Id = Guid.Parse("ba98fc30-cf11-445b-9351-e8d6011dff57"),
                Name = "Laptop",
                Price = 50000,
                Category = "Electronics"
            },
            new ProductModel
            {
                Id = Guid.Parse("a1701a06-9f24-47b3-9780-eb764957f77f"),
                Name = "Mobile",
                Price = 35000,
                Category = "Electronics"
            },
            new ProductModel
            {
                Id = Guid.Parse("e056ad13-0b4f-4bda-9d0e-ba3a3f44e228"),
                Name = "Jeans",
                Price = 2000,
                Category = "Clothes"
            },
            new ProductModel
            {
                Id = Guid.Parse("ba98fc30-cf11-445b-9351-e8d6011dff57"),
                Name = "Shoes",
                Price = 3000,
                Category = "Footwear"
            },
            new ProductModel
            {
                Id = Guid.Parse("a0ff9efc-90b8-44b2-b645-dc07fdf2f490"),
                Name = "Shirt",
                Price = 1500,
                Category = "Clothes"
            }
        };

        private readonly EcommerceContext _context;

        public ProductController(EcommerceContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("products")]
        public IEnumerable<Product> GetAllProduct()
        {
            var jwt = new JwtService(_configuration);
            var token = jwt.GenerateSecurityToken("marcsiddiqui@gmail.com", 1, 55, true);

            return _context.Products.OrderByDescending(x => x.Id).ToList();
        }

        [HttpGet]
        [Route("product/{id}")]
        public ProductModel GetProductById(string id)
        {
            var product = products.FirstOrDefault(x => x.Id == Guid.Parse(id));

            return product;
        }

        [HttpPost]
        [Route("addproduct")]
        public IEnumerable<ProductModel> SaveAndReturnAllProduct(ProductModel productModel)
        {
            products.Add(productModel);

            return products.ToArray();
        }

        [HttpPost]
        [Route("saveproduct")]
        public int SaveProduct(ProductModel productModel)
        {
            var product = new Product();
            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.Price = productModel.Price;
            product.StockQuantity = productModel.StockQuantity;
            product.CategoryId = productModel.CategoryId;
            product.Deleted = productModel.Deleted;
            product.ImagePath = productModel.ImagePath;
            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }
    }
}
