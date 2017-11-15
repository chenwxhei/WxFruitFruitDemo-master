using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeFruit.EFModels;

namespace WeFruit.IService
{
    public  interface IBaseService<TEntity> where TEntity:class ,new()
    {
        bool Add(TEntity tEntity);

        bool Romove(TEntity tEntity);

        bool Modity(TEntity tEntity);

        int GetCount(Func<TEntity, bool> whereLambda);

        TEntity GetEntity(Func<TEntity, bool> whereLambda);

        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);

        IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orederByLambda);
    }
}
