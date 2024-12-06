using System;

namespace project_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
             AdminControl admin = new AdminControl ();
             admin.AdminMenu();
             PlayerControl player = new PlayerControl();
             player.PlayerMenu();

        }
       


    }
}