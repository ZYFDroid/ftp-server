﻿using System;
using System.Collections.Generic;

namespace ftp_server
{
    static class Login
    {
        static int failcount = 0;

        public static int FakeUserTrigger = 10;

        public static bool AllowFakeUser=true;

        public static bool CheckUser = false;

        public static int AuthDelayTime = 3000;

        public static SortedList<string, User> userList = new SortedList<string, User>();
        public static bool IsValidLogin(User user)
        {
            if (!userList.ContainsKey(user.Username)) {
                failcount++;
                failcount++;
                if (AllowFakeUser && failcount >= FakeUserTrigger)//Triggle fake account
                {
                    failcount = 0;
                    user.Username = "蔡徐坤";
                    user.Root = "C:\\蔡徐坤";
                    user.CanRead = false;
                    user.IsFake = true;
                    user.CanWrite = false;
                    user.CanDelete = false;
                    user.CanList = false;
                    return true;
                }
                System.Threading.Thread.Sleep(AuthDelayTime);
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
                    if (AllowFakeUser && failcount >= FakeUserTrigger)//Triggle fake account
                    {
                        failcount = 0;
                        user.Username = "蔡徐坤";
                        user.Root = "C:\\蔡徐坤";
                        user.CanRead = false;
                        user.CanWrite = false;
                        user.IsFake = true;
                        user.CanDelete = false;
                        user.CanList = false;
                        return true;
                    }
                    System.Threading.Thread.Sleep(AuthDelayTime);
                    return false;
                }
            }
        }

        public static bool UsernameExists(string username)
        {
            if (CheckUser)
            {
                return userList.ContainsKey(username);
            }
            return true;
        }
        public static void AddUser(User user) {
            String un = user.Username;
            if (userList.ContainsKey(un)) { userList.Remove(un); }
            userList.Add(un, user);
        }

    }
}
