using SocialNetwork.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public interface IDataService<T> where T:class,new()
   {
      void AddEntity(T entity);
      void DeleteEntity(T entity);
   }
}
