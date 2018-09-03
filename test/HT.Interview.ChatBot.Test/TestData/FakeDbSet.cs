using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace HT.Interview.ChatBot.Test
{
    public abstract class FakeDbSet<T> : DbSet<T>, IEnumerable where T : class, new()
    {
        readonly ObservableCollection<T> _items;
        readonly IQueryable _query;

        protected FakeDbSet()
        {
            _items = new ObservableCollection<T>();
            _query = _items.AsQueryable();
        }

        public new T Add(T entity)
        {
            _items.Add(entity);
            return entity;
        }

        public override void AddRange(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _items.Add(entity);
            }
        }

        public new T Attach(T entity)
        {
            _items.Add(entity);
            return entity;
        }
        public TDerivedEntity Create<TDerivedEntity>()
            where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }
        public T Create()
        {
            return new T();
        }

        public abstract override T Find(params object[] keyValues);

        public new ObservableCollection<T> Local => _items;

        public new T Remove(T entity)
        {
            _items.Remove(entity);
            return entity;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        public Type ElementType => _query.ElementType;

        public Expression Expression => _query.Expression;

        public IQueryProvider Provider => _query.Provider;
    }
}
