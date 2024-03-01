<<<<<<< HEAD
namespace Hotel.Infrastructure;
using Hotel.Domain.Repository;
using Microsoft.EntityFrameworkCore;
=======
﻿namespace Hotel.Infrastructure;
>>>>>>> parent of 941a29d (Implemente baseRepository y su interfaz ademas de refactorizar mi el codigo)

public class BaseRepository
{
<<<<<<< HEAD
    private readonly HotelContext hotelContext;
    private readonly DbSet<TEntity> DbEntity;
  
    protected BaseRepository(HotelContext hotelContext)
    {
        this.hotelContext = hotelContext;
        this.DbEntity = hotelContext.Set<TEntity>();
    }
    public virtual void Add(TEntity entity)
    {
        DbEntity.Add(entity);
        hotelContext.SaveChangesAsync();
    }

    public virtual bool Exists(Func<TEntity, bool> filter)
    {
        return DbEntity.Any(filter);
    }

    public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
    {
        return DbEntity.Where(filter).ToList();
    }

    public virtual List<TEntity> GetEntities()
    {
        return [.. DbEntity];
    }

    public virtual TEntity GetEntity(int id)
    {
        return DbEntity.Find(id);
    }
  
    public virtual void Update(TEntity entity)
    {
        DbEntity.Update(entity);
        hotelContext.SaveChangesAsync();
    }
    public virtual void Remove(TEntity entity)
    {
        DbEntity.Remove(entity);
        hotelContext.SaveChangesAsync();
    }
=======

>>>>>>> parent of 941a29d (Implemente baseRepository y su interfaz ademas de refactorizar mi el codigo)
}
