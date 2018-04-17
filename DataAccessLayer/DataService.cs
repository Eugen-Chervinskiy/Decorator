using SocialNetwork.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class DataService<T> : IDataService<T> where T:class,new()
   {
      public void AddEntity(T entity)
      {
         using (SocialNetworkContext context = new SocialNetworkContext())
         {
            if (entity.GetType() == typeof(User))
            {
               context.Users.Add(entity as User);
            }

            if (entity.GetType() == typeof(Post))
            {
               context.Posts.Add(entity as Post);
            }

            if (entity.GetType() == typeof(Country))
            {
               context.Countries.Add(entity as Country);
            }

            if (entity.GetType() == typeof(Friend))
            {
               context.Friends.Add(entity as Friend);
            }

            context.SaveChanges();
         }
      }

      public void DeleteEntity(T entity)
      {
         using (SocialNetworkContext context = new SocialNetworkContext())
         {
            if (entity.GetType() == typeof(User))
            {
               //context.Users.Remove(entity as User);
               //context.Entry(entity).State = EntityState.Deleted;
               //context.SaveChanges();
               
               var user = context.Users.Find((entity as User).UserId);
               context.Users.Remove(user);
               context.SaveChanges();
            }

            
         }
      }
   }
}
