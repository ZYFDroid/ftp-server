using System;
using System.Collections.Generic;

namespace ftp_server
{
    static class Login
    {
        static int failcount = 0;

        static int trigger = 10;

        private static SortedList<string, User> userList = new SortedList<string, User>();
        public static bool IsValidLogin(User user)
        {
            if (!UsernameExists(user.Username)) {
                return false;
            }
            User u = userList[user.Username];
            if (u.Password == user.Password)
            {
                user.Root = u.Root;
                user.CanRead = u.CanRead;
                user.CanWrite = u.CanWrite;
                user.CanDelete = u.CanDelete;
                user.CanList = u.CanList;
                return true;
            }
            else
            {
                if (user.Username.ToLower() == "anonymous")//Support anonymous account
                {
                    user.Root = u.Root;
                    user.CanRead = u.CanRead;
                    user.CanWrite = u.CanWrite;
                    user.CanDelete = u.CanDelete;
                    user.CanList = u.CanList;
                    return true;
                }
                else
                {
                    failcount++;
                    if (failcount >= trigger)//Triggle fake account
                    {
                        failcount = 0;

                        user.Root = "C:\\蔡徐坤";
                        user.CanRead = false;
                        user.CanWrite = false;
                        user.CanDelete = false;
                        user.CanList = false;
                        return true;
                    }
                    System.Threading.Thread.Sleep(3000);
                    return false;
                }
            }
        }

        public static bool UsernameExists(string username)
        {
            return userList.ContainsKey(username);
        }
        public static void AddUser(User user) {
            String un = user.Username;
            if (userList.ContainsKey(un)) { userList.Remove(un); }
            userList.Add(un, user);
        }

    }
}
