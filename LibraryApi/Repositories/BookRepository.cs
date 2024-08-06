using LibraryApi.Models;

namespace LibraryApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _books;
        public BookRepository()
        {
            _books = new List<Book>() {
            new Book(){ Id = 1, Title = "Pride and Prejudice",  Author = "Jane Austen", Isbn="978-1-85326-000-1", PublishedDate = Convert.ToDateTime("1813-01-28T00:00:00"), Summary ="Set in the early 19th century, \"Pride and Prejudice\" explores the turbulent relationship between Elizabeth Bennet and Mr. Darcy. As Elizabeth navigates societal pressures and family expectations, she comes to understand Mr. Darcy's true character and the value of love and respect in relationships. The novel is renowned for its keen observations on social class and gender dynamics."  },
             new Book(){ Id = 2, Title = "1984",  Author = "George Orwell", Isbn="978-0-452-28423-4", PublishedDate = Convert.ToDateTime("1949-06-08T00:00:00"), Summary="\"1984\" is a dystopian novel set in a totalitarian future where the Party, led by Big Brother, exercises total control over every aspect of life. Winston Smith, the protagonist, works for the Party but secretly rebels against its oppressive regime. Through Winston's struggle for truth and individuality, Orwell delves into themes of surveillance, censorship, and the loss of personal freedoms." },
             new Book(){ Id = 3, Title = "Harry Potter and the Deathly Hallows",  Author = "J.K. Rowling", Isbn="978-0-545-01022-1", PublishedDate = Convert.ToDateTime("2007-07-21T00:00:00"), Summary="The final installment in the Harry Potter series follows Harry, Hermione, and Ron as they embark on a quest to defeat the dark wizard Voldemort. As they uncover the secrets of the Deathly Hallows, they face numerous challenges and uncover deep truths about their pasts. The novel concludes with an epic battle between good and evil, bringing resolution to the saga of the young wizard and his friends." }
            };
        }
        public Book AddBook(Book book)
        {
            book.Id = _books.Max(x => x.Id) + 1;
            _books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
           return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public Book UpdateBook(Book book)
        {
            Book updateBook = _books.FirstOrDefault(x => x.Id == book.Id);
            if (updateBook != null)
            { 
                updateBook.Title = book.Title;
                updateBook.Author = book.Author;
                updateBook.Isbn = book.Isbn;
                updateBook.PublishedDate = book.PublishedDate;
                updateBook.Summary = book.Summary;
            }
            return updateBook;
        }
    }
}
