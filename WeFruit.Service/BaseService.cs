using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeFruit.IRepository;
using WeFruit.IService;

namespace WeFruit.Service
{
    public class BaseService<TEntity>:IBaseService<TEntity> where TEntity:class ,new()
    {
        public IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepositoty)
        {
            _baseRepository = baseRepositoty;
        }
        public bool Add(TEntity tEntity)
        {
            _baseRepository.Insert(tEntity);
            return _baseRepository.SaveChanges();
        }

        public bool Romove(TEntity tEntity)
        {
            _baseRepository.Delete(tEntity);
            return _baseRepository.SaveChanges();
        }

        public bool Modity(TEntity tEntity)
        {
            _baseRepository.Update(tEntity);
            return _baseRepository.SaveChanges();
        }

        public int GetCount(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryCount(whereLambda);
        }

        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntity(whereLambda);
        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntities(whereLambda);
        }


        public IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orederByLambda)
        {
            return _baseRepository.QueryEntitiesByPage(pageSize, pageIndex, isAsc, whereLambda, orederByLambda);
        }
    }
}
