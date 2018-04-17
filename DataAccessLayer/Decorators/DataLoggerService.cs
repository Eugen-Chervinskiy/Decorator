using SocialNetwork.DataContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Decorators
{
   public class DataLoggerService<T> : IDataService<T> where T: class,new()
   {
      private IDataService<T> entity;
      private string path = "DataServiceLog.txt";
      

      public DataLoggerService(IDataService<T> entity)
      {
         this.entity = entity;
      }

      public void AddEntity(T entity)
      {
         string logString = string.Format("{0}({1})", nameof(this.AddEntity), typeof(T).Name);
         LogDataStart(logString);
         this.entity.AddEntity(entity);
         LogDataEnd(logString);
      }

      public void DeleteEntity(T entity)
      {
         string logString = string.Format("{0}({1})", nameof(this.DeleteEntity), typeof(T).Name);
         LogDataStart(logString);
         this.entity.DeleteEntity(entity);
         LogDataEnd(logString);
      }

      private void LogDataStart(string proccessName)
      {

         string log = string.Format("Starting proccess {0} {1} {2}",
                        proccessName,
                        DateTime.Now.ToString(),
                        Environment.NewLine);

         File.AppendAllText(path,
                           log,
                           Encoding.UTF8);

      }

      private void LogDataEnd(string proccessName)
      {
         string log = string.Format("Ending proccess {0} {1} {2}",
                        proccessName,
                        DateTime.Now.ToString(),
                        Environment.NewLine);

         File.AppendAllText(path,
                           log,
                           Encoding.UTF8);
      }
   }
}
