using OrderManage.Repositories;
using OrderManage.Models;
using System.Reflection;

namespace OrderManage.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository; 
    private readonly ICustomerRepository _customerRepository;

    public OrderService(IOrderRepository orders, ICustomerRepository customers)
    {
        _orderRepository = orders;
        _customerRepository = customers; 
    }

    public IEnumerable<Order> GetAllOrdersById(int customerId) => _orderRepository.GetByCustomerId(customerId);

    public void AddOrder(int customerId, Order newOrder)
    {  
        var customer = _customerRepository.GetById(customerId);
       if (customer == null)
       {
           throw new InvalidDataException("no costumer");
       }
        if (newOrder.Price <= 0 || newOrder.Quantity <= 0) 
        {
            throw new InvalidDataException("price and quantaty should be positive");
        }
        if (string.IsNullOrWhiteSpace(newOrder.ProductName))
        {
            throw new InvalidDataException("Product name cannot be empty.");
        }

       _orderRepository.Add(newOrder);
       customer.Orders.Add(newOrder);
    }
   
    public void UpdateOrder(Order newOrder)
    {
        Customer? customer = _customerRepository.GetById(newOrder.CustomerId);
        if (customer == null)
        {
            throw new InvalidDataException($"the customer id was not found!");
        }
        int orderIndex = customer.Orders.FindIndex(order => order.Id == newOrder.Id);
        if (orderIndex == -1)
        {
            throw new InvalidDataException($"order was not found in customer list!");
        }
        _orderRepository.Update(newOrder);
        // customer.Orders[orderIndex] = newOrder;
        // _customerRepository.Update(customer);
    }


     public void DeleteOrder(int customerId, int OrderId)
    {
        Customer? customer = _customerRepository.GetById(customerId);
        if (customer == null)
        {
            throw new InvalidDataException($"the customer id was not found!");
        }

        _orderRepository.Delete(OrderId);
        customer.Orders.RemoveAll(order => order.Id == OrderId);
        _customerRepository.Update(customer);
    }
}