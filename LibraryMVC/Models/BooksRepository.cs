using System.ComponentModel.DataAnnotations;
using LibraryMVC.Models.Patterns;

namespace LibraryMVC.Models
{

	public class Book
	{
		public int Id { get; set; }
		public string Author { get; set; }
		public string Title { get; set; }
		public int Date { get; set; }
		public string Publisher { get; set; }
		public string User { get; set; }
		public string Reserved { get; set; }
		public string Leased { get; set; }
	}
	
	public class BooksRepository: JsonRepository<Book>, SingletonRepository<Book> {
        private static readonly String BOOKS_FILE_PATH = "books.json";
        private static BooksRepository? instance;

        protected BooksRepository()
		{
			base.default_path = BOOKS_FILE_PATH;
		}

		protected BooksRepository(String newFilePath):base(newFilePath)
		{

        }

        public override bool exists(Book target)
        {
            Book? found = base.find(findBookById(target.Id));
            return found == null;
        }

        public JsonRepository<Book> GetInstance()
        {
			return null;
   
        }

        public bool reserve(int bookId)
		{
			Book? foundBook = find(findBookById(bookId));

			if (foundBook == null)
			{
				return false;
			}

			return true;

		}

        public static BooksRepository getInstance()
        {
            if (instance == null)
            {
                instance = new BooksRepository();
            }
            return instance;
        }



        private Predicate<Book> findBookById(int bookId) {
			return delegate (Book currentBook)
			{
				if (currentBook.Id == bookId)
				{
					return true;
				}
				return false;
			};
		}

    }
}
