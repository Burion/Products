using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Infrastructure
{
    public class DbAccesserEF<T> : IDbAccesser<T> where T : class
    {
        readonly ProductsContext _context;
        public DbAccesserEF()
        {
            _context = new ProductsContext();
        }
        public void AddItem(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        public void DeleteItem(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public T GetItem(Predicate<T> predicate)
        {
            return _context.Set<T>().SingleOrDefault(i => predicate(i));
        }

        public IEnumerable<T> GetItems(Predicate<T> predicate)
        {
            return _context.Set<T>().Where(i => predicate(i));
        }

        public void EditItem(T original, T toSet)
        {
            //TOTO logic editing
        }
    }
}
