using Dapper;

namespace DemoDapper.Models
{
    public class ProductFactory : IFactory<Product>
    {
        private readonly DapperContext _context;
        public ProductFactory(DapperContext context)
        {
            _context = context;
        }
        public Product GetOne(int id)
        {
            string sql = $"SELECT * FROM Products WHERE ProductId = {id}";
            Product result = null;
            using(var connection = _context.CreateConnection())
            {
                result = connection.Query<Product>(sql).FirstOrDefault();
            }
            return result;
        }
        public IEnumerable<Product> GetAll()
        {
            string sql = "SELECT * FROM Products";
            IEnumerable<Product> result = null;
            using(var con = _context.CreateConnection())
            {
                result = con.Query<Product>(sql);
            }
            return result;
        }

        public void Create(Product entity)
        {
            string sql = $"INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
            using (var con = _context.CreateConnection())
            {
                DynamicParameters paras = new DynamicParameters();
                paras.Add("@Name", entity.Name);
                paras.Add("@Price", entity.Price);
                con.Execute(sql, paras);
            }
            return;
        }
    }
}
