using OrderManage.Models;

namespace OrderManage.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private static readonly List<Customer> _costumers = new();

    public IEnumerable<Customer> GetAll() => _costumers;
    public Customer? GetById(int id) => _costumers.Find(c => c.Id == id);
    public void Add(Customer customer) =>  _costumers.Add(customer);
    
    public void Update(Customer customer){
        var index =_costumers.FindIndex(c => c.Id == customer.Id);
        if(index != -1) _costumers[index] = customer;
    }   
    public void Delete(int id) => _costumers.RemoveAll(c => c.Id == id);
}