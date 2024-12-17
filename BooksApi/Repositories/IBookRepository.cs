using BookApi.Models;

namespace BookApi.Repositories;

public interface IBooksRepository
{
    IEnumerable<Book> GetAll(); 
    Book? GetItem(int id);
    void Add(Book toAdd); 
    void Update(Book toUpdate); 
    void Delete(int id); 

}