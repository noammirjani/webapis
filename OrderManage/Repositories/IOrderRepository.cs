using OrderManage.Models;

namespace OrderManage.Repositories;

public interface IOrderRepository
{
    IEnumerable<Order> GetByCustomerId(int customerId);
    void Add(Order order);
    void Update(Order order);
    void Delete(int orderId);
    void DeleteByCustomerId(int customerId); // To delete all orders for a customer
}
