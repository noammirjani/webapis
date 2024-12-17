using BookApi.Models;
using BookApi.Repositories;

namespace BookApi.Services;


public class BookService
{
    private readonly IBooksRepository _repository; 

    public BookService(IBooksRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Book> GetAll() => _repository.GetAll(); 

    public void Add(Book book) => _repository.Add(book); 

    public void Update(Book toUpdate) => _repository.Update(toUpdate);

    public void Delete(int id) => _repository.Delete(id);

}