using Core.Models;
using DatabaseProvider;
using DatabaseProvider.Repositories.Implementations;

namespace BookShop
{
    public class Program
    {
        private const string ConnectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=Shop;Pooling=true;Integrated Security=SSPI";

        private static ApplicationContext _applicationContext;
        private static Repository<Category> _categoryRepository;
        private static Repository<Manufacturer> _manufacturerRepository;
        private static ProductRepository _productRepository;

        public static void Main(string[] args)
        {
            _applicationContext = new ApplicationContext(ConnectionString);
            _categoryRepository = new Repository<Category>(_applicationContext);
            _manufacturerRepository = new Repository<Manufacturer>(_applicationContext);
            _productRepository = new ProductRepository(_applicationContext);

            ProcessCommands();
        }

        public static void ProcessCommands()
        {
            while (true)
            {
                Console.Write("Enter command: ");
                string[] commandLine = Console.ReadLine().Split(' ');
                string command = commandLine[0];
                List<string> parameters = commandLine.Skip(1).ToList();
                switch (command)
                {
                    case "exit":
                        return;
                    case "add-category":
                        AddCategory(parameters);
                        break;
                    case "add-manufacturer":
                        AddManufacturer(parameters);
                        break;
                    case "add-product":
                        AddProduct(parameters);
                        break;
                    case "delete-category":
                        DeleteCategory(parameters);
                        break;
                    case "delete-book":
                        DeleteProduct(parameters);
                        break;
                    case "list-products":
                        ListProducts();
                        break;
                    case "list-products-by-category":
                        ListProductsByCategory(parameters);
                        break;
                    case "list-products-by-manufacturer":
                        ListProductsByManufacturerId(parameters);
                        break;
                    case "list-ListCategories":
                        ListCategories();
                        break;
                    case "update-product": //example: update-product 1 Name newname
                        UpdateProduct(parameters);
                        break;
                }
            }
        }

        private static void AddProduct(List<string> parameters)
        {
            int categoryId = int.Parse(parameters[2]);
            int manufacturerId = int.Parse(parameters[3]);
            Category category = _categoryRepository.GetById(categoryId);
            Manufacturer manufacturer = _manufacturerRepository.GetById(manufacturerId);
            Product product = new Product
            {
                Name = parameters[0],
                Description = parameters[1],
                Category = category,
                Manufacturer = manufacturer,
                Price = decimal.Parse(parameters[4])
            };
            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }

        private static void AddManufacturer(List<string> parameters)
        {
            Manufacturer manufacturer = new Manufacturer
            {
                Name = parameters[0],
                Address = parameters[1]
            };
            _manufacturerRepository.Add(manufacturer);
            _manufacturerRepository.SaveChanges();
        }

        public static void AddCategory(List<string> parameters)
        {
            Category author = new Category
            {
                Name = parameters[0],
                Description = parameters[1]
            };
            _categoryRepository.Add(author);
            _categoryRepository.SaveChanges();
        }

        public static void DeleteCategory(List<string> parameters)
        {
            int categoryId = int.Parse(parameters[0]);
            Category category = _categoryRepository.GetById(categoryId);
            _categoryRepository.Remove(category);
            _categoryRepository.SaveChanges();
        }

        public static void DeleteProduct(List<string> parameters)
        {
            int productId = int.Parse(parameters[0]);
            Product product = _productRepository.GetById(productId);
            _productRepository.Remove(product);
            _productRepository.SaveChanges();
        }

        public static void ListProducts()
        {
            foreach (var product in _productRepository.GetAll())
            {
                Console.WriteLine(product);
            }
        }

        public static void ListProductsByCategory(List<string> parameters)
        {
            int categoryId = int.Parse(parameters[0]);
            foreach (var product in _productRepository.GetByCategoryId(categoryId))
            {
                Console.WriteLine(product);
            }
        }

        public static void ListProductsByManufacturerId(List<string> parameters)
        {
            int manufacturerId = int.Parse(parameters[0]);
            foreach (var product in _productRepository.GetByManufacturerId(manufacturerId))
            {
                Console.WriteLine(product);
            }
        }

        public static void ListCategories()
        {
            foreach (var category in _categoryRepository.GetAll())
            {
                Console.WriteLine(category);
            }
        }

        public static void UpdateProduct(List<string> parameters)
        {
            int productId = int.Parse(parameters[0]);
            Product product = _productRepository.GetById(productId);
            for (int i = 0; i < parameters.Count; i++)
            {
                switch (parameters[i])
                {
                    case "Name":
                        product.Name = parameters[i + 1];
                        break;
                    case "Description":
                        product.Description = parameters[i + 1];
                        break;
                    case "Manufacturer":
                        int manufacturerId = int.Parse(parameters[i + 1]);
                        product.Manufacturer = _manufacturerRepository.GetById(manufacturerId);
                        break;
                    case "Category":
                        int categoryId = int.Parse(parameters[i + 1]);
                        product.Category = _categoryRepository.GetById(categoryId);
                        break;
                    case "Price":
                        product.Price = int.Parse(parameters[i + 1]);
                        break;
                }
            }
            _productRepository.Update(product);
        }
    }
}
