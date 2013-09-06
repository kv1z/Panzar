namespace Panzar.DAL
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Panzar.Models;
    using System;

    public class UserInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {       
        protected override void Seed(UserContext context)
        {
            FillDb(context);
        }
         
        [System.Diagnostics.Conditional("DEBUG")]
        private void FillDb(UserContext context) 
        {
            for (int i = 0; i < 5000; i++)
            {
                context.Users.Add(new User { Name = Guid.NewGuid().ToString() });
            }

            context.SaveChanges();
        }
    }
}