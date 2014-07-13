using Liberty.Data;
using Liberty.Data.Interfaces;
using Liberty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Lib
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private CultureInfo _culture = new CultureInfo("en-AU");
        private IDataContext _context;
        public AuthorsRepository(IDataContext context)
        {
			_context = context;
        }
  

        public List<Author> GetAuthors(IAuthorSearchParams searchTerms)
        {
            return _context.GetAuthors().Where(e => (e.AuthorFirstName.ToLower().Contains(searchTerms.AuthorFirstName.ToLower()) 
                                                        || string.IsNullOrEmpty(searchTerms.AuthorFirstName))
                                                    && (e.AuthorLastName.ToLower().Contains(searchTerms.AuthorLastName.ToLower()) 
                                                        || string.IsNullOrEmpty(searchTerms.AuthorLastName))).ToList();

        }

        public Author GetAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public Author SaveAuthor(Author author)
        {
            return _context.SaveAuthor(author);
        }
    }
}
