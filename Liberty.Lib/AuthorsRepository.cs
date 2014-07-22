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
        private IDataContext _context;
        public AuthorsRepository(IDataContext context)
        {
			_context = context;
        }
  

        public List<Author> GetAuthors(IAuthorSearchParams searchTerms)
        {
            if (searchTerms == null)
                return _context.GetAuthors().ToList();
            else
                return _context.GetAuthors().Where(e => (e.AuthorFirstName.ToLower().Contains(searchTerms.AuthorFirstName.ToLower()) 
                                                        || string.IsNullOrEmpty(searchTerms.AuthorFirstName))
                                                    && (e.AuthorLastName.ToLower().Contains(searchTerms.AuthorLastName.ToLower()) 
                                                        || string.IsNullOrEmpty(searchTerms.AuthorLastName))).ToList();
        }

        public Author GetAuthor(int authorId)
        {
            return _context.GetAuthor(authorId);
        }

        //public Author GetAuthor(string firstname, string lastname)
        //{
        //    throw new NotImplementedException();
        //}

        public Author SaveAuthor(Author author)
        {
            return _context.SaveAuthor(author);
        }

        
    }
}
