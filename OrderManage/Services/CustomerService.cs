using OrderManage.Repositories;
using OrderManage.Models;

namespace OrderManage.Services;

public class CustomerService
{   
    private readonly IOrderRepository _orderRepository; 
    private readonly ICustomerRepository _costumerRepository;

    public CustomerService(IOrderRepository orders, ICustomerRepository customers)
    {
        _orderRepository = orders;
        _costumerRepository = customers; 
    }
    public IEnumerable<Customer> GetAllCostumers() => _costumerRepository.GetAll();

    public Customer GetCustomerById(int id)
    {
        var customer = _costumerRepository.GetById(id);
        if (customer == null)
        {
            throw new InvalidDataException($"No costumer with {id} id");
        }
        return customer;
    }
   
    public void AddCustomer(Customer newCustomer)
    {
        if (_costumerRepository.GetAll().Any(c => c.Id == newCustomer.Id))
        {
            throw new InvalidDataException($"Taken id - {newCustomer.Id} ");
        }
        if (string.IsNullOrWhiteSpace(newCustomer.Email) || string.IsNullOrWhiteSpace(newCustomer.Name))
        {
            throw new InvalidDataException($"Name/email can not be empty ");
        }
        if (_costumerRepository.GetAll().Any(c => c.Email.Equals(newCustomer.Email, StringComparison.CurrentCultureIgnoreCase)))
        _costumerRepository.Add(newCustomer);
    }

     public void UpdateCustomer(Customer updateCustomer)
    {
        if (_costumerRepository.GetAll().Any(c => c.Id == updateCustomer.Id))
        {
            throw new InvalidDataException($"No costumer with {updateCustomer.Id} id");
        }
        _costumerRepository.Update(updateCustomer);
    }

     public void DeleteCustomer(int id)
    {
        _costumerRepository.Delete(id);
        _orderRepository.DeleteByCustomerId(id);
    }
}