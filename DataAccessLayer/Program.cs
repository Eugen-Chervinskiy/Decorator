using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Decorators;
using SocialNetwork;
using SocialNetwork.DataContext;

namespace DataAccessLayer
{
   class Program
   {
      static void Main(string[] args)
      {
        
         using (SocialNetworkContext context = new SocialNetworkContext())
         {
            var friends = context.Friends.Where(_ => String.Equals(_.UserId.ToString(),
                                      "44E6D4F9-5603-4793-8F7E-AB027FADB7F3")).ToList();

            foreach (var item in friends)
            {
               var service2 = new DataService<Friend>();
               var userLoggerService2 = new DataLoggerService<Friend>(service2);
               userLoggerService2.DeleteEntity(item);
            }

            var currentUser = context.Users
                                     .Where(_ => String.Equals(_.UserId.ToString(),
                                      "44E6D4F9-5603-4793-8F7E-AB027FADB7F3"))
                                     .First();


            var service = new DataService<User>();
            var userLoggerService = new DataLoggerService<User>(service);

            userLoggerService.DeleteEntity(currentUser);

         }
      }

      private static void AddUsers()
      {
         var user1 = new User
         {
            FName = "IGOR",
            LName = "IGOREVICH",
            BirthDate = new DateTime(1996, 10, 5),
            Login = "nagibator228",
            Password = ":KWEhfrgfg"
         };

         var user2 = new User
         {
            FName = "Vasiliy",
            LName = "IGOREVICH",
            BirthDate = new DateTime(1996, 10, 5),
            Login = "nagibator228",
            Password = ":KWEhfrgfg"
         };


         var friend1 = new Friend()
         {
            FriendId = user1.UserId,
            UserId = user2.UserId
         };



         var service = new DataService<User>();
         var userLoggerService = new DataLoggerService<User>(service);

         var friend = new DataService<Friend>();
         var friendLoggerService = new DataLoggerService<Friend>(friend);

         userLoggerService.AddEntity(user1);
         userLoggerService.AddEntity(user2);
         friendLoggerService.AddEntity(friend1);
      }

      
   }
}
