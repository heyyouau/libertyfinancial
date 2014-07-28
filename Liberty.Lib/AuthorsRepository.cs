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


        /// <summary>
        /// Return all authors that match the search criteria, or all authors in the database
        /// </summary>
        /// <param name="searchTerms">The list of parameters to search on</param>
        /// <returns></returns>
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


        /// <summary>
        /// return a single author based on the supplied id
        /// </summary>
        /// <param name="authorId">the database id of the author</param>
        /// <returns></returns>
        public Author GetAuthor(int authorId)
        {
            return _context.GetAuthor(authorId);
        }


        /// <summary>
        /// save the author
        /// </summary>
        /// <param name="author">the author to be saved</param>
        /// <returns></returns>
        public Author SaveAuthor(Author author)
        {
            return _context.SaveAuthor(author);
        }
    }
}
