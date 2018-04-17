namespace DataModel
{
   using System;
   using System.Data.Entity;
   using System.Linq;

   public class ShopDatabaseContext : DbContext
   {
     
      public ShopDatabaseContext()
          : base("name=ShopDatabaseContext")
      {
      }

     
   }

   
}