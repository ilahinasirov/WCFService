using Entities2;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServiceApp.DataContext
{
    public class UserContext:DbContext
    {
        public UserContext() : base("name=MyDbContext")
        {
            
        }
        DbSet<User> Users { get; set; }

        public void AddUserWithStProc(User user)
        {
            Database.ExecuteSqlCommand("_spAddUser @Name, @SurName, @UserName, @Password",
                new SqlParameter("Name", user.Name),
                new SqlParameter("SurName", user.SurName),
                new SqlParameter("UserName", user.UserName),
                new SqlParameter("Password", user.Password));
        }
    }
}