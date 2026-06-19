using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class BookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public bool Update(Book book)
        {
            var existing = _context.Books.Find(book.Id);
            if (existing == null)
                return false;

            existing.Name = book.Name;
            existing.Price = book.Price;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return false;

            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }
    }
}
