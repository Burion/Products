using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDbAccesser<T>
    {
        void AddItem(T item);
        void DeleteItem(T item);
        T GetItem(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetItems(Predicate<T> predicate);
        IEnumerable<T> GetItems();
        void EditItem(T item);
    }
}
