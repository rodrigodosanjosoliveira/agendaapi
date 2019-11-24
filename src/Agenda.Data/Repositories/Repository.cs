using Agenda.Data.Context;
using Agenda.Domain.Contracts.Repositories;
using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Data.Repositories {
    public class Repository<T> : IRepository<T>
        where T : Entity {
        private readonly AgendaContext _context;

        public Repository(AgendaContext context) {
            _context = context;
        }

        public async Task<T> Create(T entity) {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Guid id) {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll() {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Guid id) {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Update(Guid id, T entity) {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
