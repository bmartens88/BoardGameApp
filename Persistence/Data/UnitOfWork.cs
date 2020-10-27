using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoardGamesContext _context;
        private Hashtable _repositories;

        public UnitOfWork(BoardGamesContext context)
        {
            _context = context;
        }

        public async Task<int> Complete() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
