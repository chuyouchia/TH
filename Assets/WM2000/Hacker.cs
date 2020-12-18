using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen { MainMenu, Password, Win}

    private static string[] level1Passwords = {"books", "password", "font" ,"borrow" ,"aisle"};
    private static string[] level2Passwords = {"prisoner", "handcuffs", "holster", "uniform", "arrest"};
    private static string[] level3Passwords = {"starfield", "astronaut", "environment", "exploration", "telescope" };

    private Screen currentScreen;
    private string currentPassword;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu() 
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Enter 1 for local library");
        Terminal.WriteLine("Enter 2 for police station");
        Terminal.WriteLine("Enter 3 for NASA");

        Terminal.WriteLine("Enter your chosen number: ");
    }

    private void OnUserInput(string userInput) {
        if (userInput == "menu") {
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(userInput);
        } else if (currentScreen == Screen.Password) {
            ValidatePassword(userInput);
        } else if (currentScreen == Screen.Win) {
            ShowMainMenu();
        }


    }

    private void ValidatePassword(string userInput)
    {
        if (userInput != currentPassword)
        {
            Terminal.WriteLine("Try again! This is the wrong password.");
        } else
        {
            //return win screen
            RunWinScreen();
        }

    }

    void RunWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Yay, you have got it right!");
        Terminal.WriteLine("Press enter to return to main menu.");
    }

    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "007":
                Terminal.WriteLine("Please choose a level, Bond");
                break;
            case "1":
                currentPassword = level1Passwords[Random.Range(0, level1Passwords.Length)];
                StartGame();
                break;
            case "2":
                currentPassword = level2Passwords[Random.Range(0, level2Passwords.Length)];
                StartGame();
                break;
            case "3":
                currentPassword = level3Passwords[Random.Range(0, level3Passwords.Length)];
                StartGame();
                break;
            default:
                Terminal.WriteLine("Please choose a valid level");
                break;
        }

    }

    void StartGame ()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter the password. Hint is: " + currentPassword.Anagram());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
