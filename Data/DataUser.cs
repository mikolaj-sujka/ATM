using System.IO;
using ATM.Users;
using Newtonsoft.Json;

namespace ATM.Data
{
    class DataUser
    {
        public static void SaveUserData(User user)
        {
            var userSerialized = JsonConvert.SerializeObject(user);
            File.WriteAllText("D:\\C#_ATM\\ATM\\Data\\userData.json", userSerialized);
        }

        public static User ReadUserData()
        {
            var userSerialized = File.ReadAllText("D:\\C#_ATM\\ATM\\Data\\userData.json");
            return JsonConvert.DeserializeObject<User>(userSerialized);
        }
    }
}
