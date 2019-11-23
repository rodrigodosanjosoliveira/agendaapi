﻿using Agenda.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Domain.Contracts.Repositories {
    public interface IRepository<T>
        where T : Entity {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(Guid id, T entity);

        Task Delete(Guid id);
    }
}
