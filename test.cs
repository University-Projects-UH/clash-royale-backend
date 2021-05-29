using CR_Backend.Controllers;
using CR_Backend.Models;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args){
            LoginRequest Log = new LoginRequest(Username : 'alurquiza', Password : 'password');
            Log.Username = 'alurquiza';
            Log.Password = 'password';

            LoginController aux = new LoginController();

            Console.Write(aux.Authenticate(Log));

            
        }
    }
}
