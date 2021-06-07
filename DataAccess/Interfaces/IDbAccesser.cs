using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    interface IDbAccesser<T>
    {
        void AddItem(T item);
        void DeleteItem(T item);

        T GetItem(Predicate<T> predicate);

        IEnumerable<T> GetItems(Predicate<T> predicate);

        void EditItem(T original, T toSet);
    }
}
