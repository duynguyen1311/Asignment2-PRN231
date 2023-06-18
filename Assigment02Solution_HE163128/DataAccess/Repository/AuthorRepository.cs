using BusinessObject.Model;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorDAO _dao;

        public AuthorRepository(AuthorDAO dao) { _dao = dao; }
        public void DeleteAuthor(int id) => _dao.DeleteAuthor(id);
        public void SaveAuthor(Author p) => _dao.SaveAuthor(p);
        public void UpdateAuthor(Author p) => _dao.UpdateAuthor(p);
        public List<Author>? GetAuthors() => _dao.GetAuthors();
        public Author GetAuthorById(int id) => _dao.FindAuthorById(id);
    }
}
