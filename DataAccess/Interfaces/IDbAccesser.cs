﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IDbAccesser<T>
    {
        void AddItem(T item);
        void DeleteItem(T item);

        T GetItem(Predicate<T> predicate);

        IEnumerable<T> GetItems(Predicate<T> predicate);
        IEnumerable<T> GetItems();

        void EditItem(T original, T toSet);
        void EditItem(T item);
    }
}
