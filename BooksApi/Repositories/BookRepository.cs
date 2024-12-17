using BookApi.Models;

namespace BookApi.Repositories;

public class BooksRepository : IBooksRepository
{
    public static readonly List<Book> _books = new List<Book>(); 
    
    public IEnumerable<Book> GetAll() => _books;

    public Book? GetItem(int id) {
        return _books.Find(book => book.Id == id); 
    }

    public void Add(Book toAdd) {
        if (_books.Any(book => book.Id == toAdd.Id))
        {
            throw new Exception($"taken id {toAdd.Id}");
        }
        _books.Add(toAdd); 
    }
    public void Update(Book toUpdate){
        var index = _books.FindIndex(book => book.Id == toUpdate.Id);
        if(index > -1) _books[index] = toUpdate;
    }

    public void Delete(int id) {
        _books.RemoveAll(book => book.Id == id);
    }

}