﻿namespace SolarDR.Infrastructure.Core.Contracts
{
    public interface IRepository<T> where T : class
    { 
        Task<T> AddAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task EditAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
