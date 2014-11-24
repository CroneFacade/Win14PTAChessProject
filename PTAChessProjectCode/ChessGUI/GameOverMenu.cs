using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGUI
{
    static class GameOverMenu
    {
        public static void EnterGameOverMenu()
        {
            //We want to stay in the menu until we choose
            //a menu option which is to exit the menu
            bool leaveMenu = false;
            while (!leaveMenu)
            {
                //This simply displays the Menu
                PrintGUI.GameOverMenu();
                //This collects your menu choice.
                var pressedKey = Console.ReadKey();
                //This method fetches a bool from the method and lets us know
                //if we should exit the menu or not
                leaveMenu = PerformChosenMenuOption(pressedKey, leaveMenu);
            }

        }

        //This method handles all of our Game Over Menu options
        public static bool PerformChosenMenuOption(ConsoleKeyInfo pressedKey, bool leaveMenu)
        {
            //If the player chose Option 1
            if (pressedKey.KeyChar == 49)
            {
                //we simply leave the menu, and the game will play again.
                leaveMenu = true;
            }
            //If we choose Option 2
            else if (pressedKey.KeyChar == 50)
            {
                //Call a method which prints out our complete move log.
                PrintGUI.PrintCompleteLog();
                //We wont leave the menu after this
                leaveMenu = false;
            }
            //If we choose option 3
            else if (pressedKey.KeyChar == 51)
            {
                //Quit the program
                Environment.Exit(404);
            }
            //Return if we should leave the menu or not
            return leaveMenu;
        }
    }
}
