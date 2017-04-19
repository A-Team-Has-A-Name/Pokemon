namespace PokemonDB.Data.Store
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Pokemon.Data;
    using Pokemon.Models;

    public static class UserStore
    {
        private static UserModel getUserByUsername(string username,PokemonContext context)
        {
            UserModel UM = context.Users.Where (u => u.Username == username).ToList ( ).FirstOrDefault ( );
            return UM;
        }


        public static UserModel GetUserByLoginData ( string Username, string Password )
        {
            using ( var context = new PokemonContext ( ) )
            {
                UserModel UM = context.Users.Where (u => u.Username == Username && u.Password == Password).Include("Trainers").ToList ( ).FirstOrDefault ( );
                return UM;
            }
        }

        public static void UpdateUser(string username)
        {
            using (var context = new PokemonContext())
            {
                UserModel UM = getUserByUsername (username, context);
                UM.LastOnlineDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public static UserModel GetUserById(int id)
        {
            using ( var context = new PokemonContext ( ) )
            {
                UserModel UM = context.Users.Where (u => u.Id == id).ToList ( ).FirstOrDefault ( );
                return UM;
            }
        }

        public static UserModel RegisterUser(string username, string password, string email)
        {
            using ( var context = new PokemonContext ( ) )
            {
                UserModel UM = getUserByUsername(username,context);

                if (UM == null)
                {
                    UserModel user = new UserModel();
                    user.LastOnlineDate = DateTime.Now;
                    user.Password = password;
                    user.Username = username;
                    user.Email = email;
                    user.RegistrationDate = DateTime.Now;

                    context.Users.Add(user);
                    context.SaveChanges();
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
