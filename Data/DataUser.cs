using System.Collections.Generic;
using System.IO;
using System.Linq;
using ATM.Users;
using Newtonsoft.Json;

namespace ATM.Data
{
    class DataUser
    {
        public static List<User> Users = new List<User>();

        public static void UpdateUsersOldData()
        {
            var copyOldData = ReadUserData();
            if (copyOldData != null)
            {
                if (copyOldData.Count > 0)
                {
                    foreach (var User in copyOldData)
                    {
                        Users.Add(User);
                    }
                }
            }
        }

        public static void SaveUserData(User user)
        {
            if(IsUserExist(user)) return;
            Users.Add(user);
        }

        public static void CreateJsonFile()
        {
            var userSerialized = JsonConvert.SerializeObject(Users);
            File.WriteAllText("D:\\C#_ATM\\ATM\\Data\\userData.json", userSerialized);
        }

        public static List<User> ReadUserData()
        {
            var userSerialized = File.ReadAllText("D:\\C#_ATM\\ATM\\Data\\userData.json");
            var list = JsonConvert.DeserializeObject<List<User>>(userSerialized);
            return list;
        }

        public static bool IsUserExist(User user)
        {
            if (Users.Count > 0)
            {
                foreach (var User in Users)
                {
                    if (User.Login.Equals(user.Login) || User.Mail.Equals(user.Mail))
                        return true;
                }
            }
            return false;
        }
    }
}
