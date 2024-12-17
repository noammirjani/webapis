using OrderManage.Models;

namespace OrderManage.Repositories;

public class OrderRepository : IOrderRepository
{
    private static readonly List<Order> _orders = new();
    public IEnumerable<Order> GetByCustomerId(int customerId)
    {
        return _orders.FindAll(order => order.CustomerId == customerId);
    }
    public void Add(Order order) => _orders.Add(order);
    public void Update(Order order)
    {
        int index = _orders.FindIndex(o => o.Id == order.Id);
        if (index > -1) {
            _orders[index] = order;
        }
    }
    public void Delete(int orderId)
    {
        _orders.RemoveAll(order => order.Id == orderId);
    }
    public void DeleteByCustomerId(int customerId)
    {
        _orders.RemoveAll(order => order.CustomerId == customerId);
    }

}
