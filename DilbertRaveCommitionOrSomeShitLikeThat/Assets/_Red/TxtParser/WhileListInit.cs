
using UnityEngine;
using System.IO;
//using UdonSharp;
//using VRC.SDKBase;
//using VRC.Udon;

//public class WhileListInit : UdonSharpBehaviour
//{
//    void Start()
//    {
//        
//    }
//}

public class TextFileReader : MonoBehaviour
{
    public string textFilePath; // Path to the text document
    private string[] usernames; // Array to store the usernames

    private void Start()
    {
        ReadTextFile();
    }

    private void ReadTextFile()
    {
        // Check if the text file exists
        if (File.Exists(textFilePath))
        {
            // Read all lines from the text file
            string[] lines = File.ReadAllLines(textFilePath);

            // Initialize the usernames array with the same size as the lines array
            usernames = new string[lines.Length];

            // Loop through each line and store the username in the array
            for (int i = 0; i < lines.Length; i++)
            {
                usernames[i] = lines[i];
            }

            // Output the usernames to the console
            foreach (string username in usernames)
            {
                Debug.Log("Username: " + username);
            }
        }
        else
        {
            Debug.LogError("Text file not found: " + textFilePath);
        }
    }
}