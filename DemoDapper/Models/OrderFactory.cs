using Dapper;

namespace DemoDapper.Models
{
    public class OrderFactory : IFactory<Order>
    {
        private readonly DapperContext _context;
        public OrderFactory(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> Detail()
        {
            string sql = "SELECT a.OrderId,a.Quantity,a.Date AS OrderDate,b.Name,b.Price FROM Orders AS a JOIN Products AS b on a.ProductId = b.ProductId";
            IEnumerable<Order> result = null;
            using(var con = _context.CreateConnection())
            {
                result = con.Query<Order>(sql);
            }
            return result;
        }
        public void Create(Order entity)
        {

        }

        public IEnumerable<Order> GetAll()
        {
            string sql = "SELECT * FROM Orders";
            IEnumerable<Order> result = null;
            using(var con = _context.CreateConnection())
            {
                result = con.Query<Order>(sql);
            }
            return result;
        }

        public Order GetOne(int id)
        {
            string sql = $"SELECT * FROM Orders WHERE OrderId = {id}";
            Order result = null;
            using(var con = _context.CreateConnection())
            {
                result = con.Query<Order>(sql).FirstOrDefault();
            }
            return result;
        }
    }
}
