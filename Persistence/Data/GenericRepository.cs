using Application.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly BoardGamesContext _context;

        public GenericRepository(BoardGamesContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            //await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();

        public /*async Task*/ void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            //await _context.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> spec) => await ApplySpecification(spec).FirstAsync();

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec) => await ApplySpecification(spec).FirstOrDefaultAsync();

        public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec) => await ApplySpecification(spec).ToListAsync();

        public /*async Task*/ void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
