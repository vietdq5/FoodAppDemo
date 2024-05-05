namespace WavesOfFoodDemo.Server.Infrastructures;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WavesOfFoodDemo.Server.DataContext;
using WavesOfFoodDemo.Server.Entities;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntities
{
    protected readonly FoodDbContext _foodDbContext;

    public GenericRepository(FoodDbContext foodDbContext)
    {
        _foodDbContext = foodDbContext;
    }

    public T? GetById(Guid id)
    {
        return _foodDbContext.Set<T>().Find(id);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _foodDbContext.Set<T>().FindAsync(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _foodDbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _foodDbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
    {
        return _foodDbContext.Set<T>().Where(expression);
    }

    public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
    {
        var resultData = await _foodDbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        return resultData;
    }

    public T? GetObject(Expression<Func<T, bool>> expression)
    {
        return _foodDbContext.Set<T>().Find(expression);
    }

    public async Task<T?> GetObjectAsync(Expression<Func<T, bool>> expression)
    {
        return await _foodDbContext.Set<T>().FindAsync(expression);
    }

    private bool Insert(T pObj)
    {
        try
        {
            _foodDbContext.Entry(pObj).State = EntityState.Added;
            return true;
        }
        catch
        {
            throw;
        }
    }

    public async Task<T> AddReturnModelAsync(T entity)
    {
        await using var transaction = await _foodDbContext.Database.BeginTransactionAsync();
        try
        {
            bool isOk = Insert(entity);
            if (!isOk)
            {
                return entity;
            }
            await _foodDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return entity;
        }
        catch
        {
            await _foodDbContext.Database.RollbackTransactionAsync();
            throw;
        }
    }

    public bool Add(T entity)
    {
        using var transaction = _foodDbContext.Database.BeginTransaction();
        try
        {
            bool isOk = Insert(entity);
            if (!isOk)
            {
                return false;
            }
            _foodDbContext.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            _foodDbContext.Database.RollbackTransaction();
            throw;
        }
    }

    public async Task<bool> AddAsync(T entity)
    {
        await using var transaction = await _foodDbContext.Database.BeginTransactionAsync();
        try
        {
            bool isOk = Insert(entity);
            if (!isOk)
            {
                return false;
            }
            await _foodDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await _foodDbContext.Database.RollbackTransactionAsync();
            throw;
        }
    }

    public bool AddMany(IEnumerable<T> entity)
    {
        using var transaction = _foodDbContext.Database.BeginTransaction();
        try
        {
            _foodDbContext.Set<T>().AddRange(entity);
            _foodDbContext.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            _foodDbContext.Database.RollbackTransaction();
            throw;
        }
    }

    public async Task<bool> AddManyAsync(IEnumerable<T> entity)
    {
        await using var transaction = await _foodDbContext.Database.BeginTransactionAsync();
        try
        {
            await _foodDbContext.Set<T>().AddRangeAsync(entity);
            await _foodDbContext.SaveChangesAsync();

            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await _foodDbContext.Database.RollbackTransactionAsync();
            throw;
        }
    }

    public T? GetObject(params object[] pKeys)
    {
        return _foodDbContext.Set<T>().Find(pKeys);
    }

    public async Task<T?> GetObjectAsync(params object[] pKeys)
    {
        return await _foodDbContext.Set<T>().FindAsync(pKeys);
    }

    private bool UpdateWithObject(T pObj, params string[] pNotUpdatedProperties)
    {
        try
        {
            var keyNames = GetPrimaryKey();
            var keyValues = keyNames.Select(p => pObj.GetType().GetProperty(p)?.GetValue(pObj, null)).ToArray();
            if (keyValues != null)
            {
                T exist = GetObject(keyValues!)!;
                if (exist != null)
                {
                    _foodDbContext.Entry(exist).State = EntityState.Detached;
                    _foodDbContext.Attach(pObj);
                    var entry = _foodDbContext.Entry(pObj);
                    entry.State = EntityState.Modified;

                    if (pNotUpdatedProperties.Any())
                    {
                        foreach (string prop in pNotUpdatedProperties)
                        {
                            entry.Property(prop).IsModified = false;
                        }
                    }

                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        catch
        {
            throw;
        }
    }

    public bool Update(T pObj)
    {
        return UpdateWithTransaction(pObj, "CreateDate", "CreateBy");
    }

    public async Task<bool> UpdateAsync(T pObj)
    {
        return await UpdateWithTransactionAsync(pObj, "CreateDate", "CreateBy");
    }

    public async Task<bool> UpdateStatusAsync(T pObj)
    {
        return await UpdateWithTransactionAsync(pObj, "CreateDate", "CreateBy");
    }

    private bool UpdateWithTransaction(T pObj, params string[] pNotUpdatedProperties)
    {
        using var transaction = _foodDbContext.Database.BeginTransaction();
        try
        {
            bool isOk = UpdateWithObject(pObj, pNotUpdatedProperties);
            if (isOk)
            {
                _foodDbContext.SaveChanges();
                transaction.Commit();
            }

            return isOk;
        }
        catch (Exception ex)
        {
            _foodDbContext.Database.RollbackTransaction();
            throw;
        }
    }

    private async Task<bool> UpdateWithTransactionAsync(T pObj, params string[] pNotUpdatedProperties)
    {
        await using var transaction = await _foodDbContext.Database.BeginTransactionAsync();
        try
        {
            bool isOk = UpdateWithObject(pObj, pNotUpdatedProperties);
            if (isOk)
            {
                await _foodDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return isOk;
        }
        catch
        {
            await _foodDbContext.Database.RollbackTransactionAsync();
            throw;
        }
    }

    public bool UpdateMany(IEnumerable<T> entity)
    {
        using var transaction = _foodDbContext.Database.BeginTransaction();
        try
        {
            _foodDbContext.Set<T>().UpdateRange(entity);
            _foodDbContext.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            _foodDbContext.Database.RollbackTransaction();
            throw;
        }
    }

    public async Task<bool?> DeleteByKey(Guid pKey)
    {
        await using var transaction = _foodDbContext.Database.BeginTransaction();
        try
        {
            var obj = GetById(pKey);
            if (obj == null)
            {
                return null;
            }
            _ = _foodDbContext.Remove(obj);
            await _foodDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await _foodDbContext.Database.RollbackTransactionAsync();
            throw;
        }
    }

    private string[] GetPrimaryKey()
    {
        return _foodDbContext.Model?.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.Select(x => x.Name)?.ToArray() ?? [];
    }
}