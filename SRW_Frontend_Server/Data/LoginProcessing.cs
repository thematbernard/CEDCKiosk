using SRW_Frontend_Server.DTOs;
using SRW_Frontend_Server.Models;
using BCrypt.Net;

namespace SRW_Frontend_Server.Data
{
    public static class LoginProcessing
    {
        public static bool loggedIn = false;
        public static string Username { get; set; } = "Guest";
        public static int UserID { get; set; } = -1;
        public static string UserRole { get; set; } = "General User";


        public static bool VerifyLogin(List<UserRoleDTO> userRoles, string username, string password)
        {
            foreach (var userRole in userRoles)
            {
                if (string.Compare(userRole.User.User_Email, username) == 0)
                {
                    var result = BCrypt.Net.BCrypt.EnhancedVerify(password, userRole.User.User_Password);
                    if (result)
                    {
                        loggedIn = true;
                        Username = userRole.User.User_First_Name;
                        UserID = userRole.User.User_ID;
                        UserRole = userRole.Role.Role_Name;
                        return true;
                    }
                }
            }
            return false;
        }

        public static void LogOut()
        {
            Username = "Guest";
            UserID = -1;
            loggedIn = false;
            UserRole = "General User";
        }
    }
}