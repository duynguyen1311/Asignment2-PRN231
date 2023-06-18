using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAuthorRepository
    {
        void SaveAuthor(Author p);
        Author GetAuthorById(int id);
        void DeleteAuthor(int id);
        void UpdateAuthor(Author p);
        List<Author>? GetAuthors();
    }
}
