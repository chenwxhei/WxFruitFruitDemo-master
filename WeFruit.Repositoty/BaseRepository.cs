using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeFruit.EFModels;
using WeFruit.IRepository;
using WeFruit.Repository;

namespace WeFruit.Repository
{
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class ,new()
    {
        private WeShop _dbContext = DbContextFactory.GetIntance();
        private DbSet<TEntity> _dbSet;

        public BaseRepository()
        {
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Insert(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }

        public void Delete(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }

        public void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            //更改实体的状态为已修改
            _dbContext.Entry(tEntity).State = EntityState.Modified;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public int QueryCount(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Count(whereLambda);
        }

        public TEntity QueryEntity(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.FirstOrDefault(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,Expression< Func<TEntity, bool>> whereLambda,Expression< Func<TEntity, TType>> orederByLambda)
        {
            //生成查询语句
            var result = _dbSet.Where(whereLambda);
            //附加排序
            result = isAsc ? result.OrderBy(orederByLambda) : result.OrderByDescending(orederByLambda);
            //附加分页
            var offset = (pageIndex - 1) * pageSize;
            result = result.Skip(offset).Take(pageSize);
            return result;
        }
    }
}
