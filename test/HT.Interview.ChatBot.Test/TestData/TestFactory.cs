using HT.Framework;
using HT.Interview.ChatBot.Common;
using HT.Interview.ChatBot.Common.Contracts;
using HT.Interview.ChatBot.Common.Entities;
using HT.Interview.ChatBot.Data;
using HT.Interview.ChatBot.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HT.Interview.ChatBot.Test
{
    public class TestFactory
    {
        public IQueryable<User> User { get; }

        public Mock<ILogger<UserService>> MockUserClaimLogger;

        public Mock<IChatBotDataFactory> MockFactory;

        public TestFactory()
        {
            User = new TestData().User;  
            MockFactory = CreateMockSecurityFactory();
        }
         
        internal (Mock<UserService> mockService, Mock<DbSet<User>> mockDbSet) CreateMockUserClaimQueryService()
        {
            MockFactory.Setup(x => x.GetResourceService(Constants.ResourceComponent)).Returns(new ResourceService<Resources.Resources>()); 
            Mock<DbSet<User>> mockDbSet = MockDbSet(User);
            var mockContext = CreateMockContext();
            mockContext.Setup(m => m.User).Returns(mockDbSet.Object);
            return (new Mock<UserService>(MockFactory.Object, mockContext.Object), mockDbSet);
        }
         
        private Mock<IChatBotDataContext> CreateMockContext()
        {
            var mockRepository = new MockRepository(MockBehavior.Default);
            var mockContext = mockRepository.Create<IChatBotDataContext>(); 
            return mockContext;
        }

        public Mock<IChatBotDataFactory> CreateMockSecurityFactory()
        {
            var mockFactory = new MockRepository(MockBehavior.Default);
            return mockFactory.Create<IChatBotDataFactory>();
        }

        private Mock<DbSet<T>> MockDbSet<T>(IEnumerable<T> data = null) where T : class
        {
            if (data == null) data = new List<T>();
            IQueryable<T> queryable = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IAsyncEnumerable<T>>()
                .Setup(c => c.GetEnumerator())
                .Returns(new TestAsyncEnumerator<T>(queryable.GetEnumerator()));
            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(queryable.Provider));

            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Expression)
                .Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>()
                .Setup(m => m.ElementType)
                .Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>()
                .Setup(m => m.GetEnumerator())
                .Returns(() => queryable.GetEnumerator());
            return mockSet;
        }
    }


    internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal TestAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return new TestAsyncEnumerable<TResult>(expression);
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }
    }

    internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
    }

    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public T Current => _inner.Current;

        public Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }
    }
}
