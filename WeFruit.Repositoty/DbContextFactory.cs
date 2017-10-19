using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WeFruit.EFModels;

namespace WeFruit.Repository
{
    public class DbContextFactory
    {
        public static WeShop GetIntance()
        {
            //CallContext是一个线程槽，一个请求就是一个线程，如果数据上下文存在，就直接从线程槽里拿出来用
            var _dbContext = CallContext.GetData("dbContext") as WeShop;

            //如果数据存在，就创建一个，放进线程槽，供线程的下次操作使用
            if (_dbContext == null)
            {
                _dbContext=new WeShop();
                CallContext.SetData("dbContext",_dbContext);
            }

            return _dbContext;
        }
    }
}
