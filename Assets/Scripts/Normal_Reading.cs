using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using System.IO;

public class Normal_Reading : MonoBehaviour
{
    public TMP_Text display;
    public int startPause;
    public bool generateNewRandomOrder;

    private string activeTextFile;
    private string directory;

    // Start is called before the first frame update
    void Start()
    {
        DataScript.StartPause = startPause;

        directory = "Assets/TextFiles/";
        string randomOrderFile = directory + "RandomOrder.txt";

        if (generateNewRandomOrder)
        {
            string[] textFiles = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };

            ShuffleArray(textFiles);

            Debug.Log("Random Order generated! Starting with file " + textFiles[0]);
            activeTextFile = textFiles[0];
            DataScript.ActiveTextFile = activeTextFile;

            // Delete the first Item that has already been used
            DeleteFirstItem(ref textFiles);

            // Clear the txt file from previous uses
            using (FileStream fileStream = new FileStream(randomOrderFile, FileMode.Truncate))
            {
                // Set the length of the file stream to 0 to clear its contents
                fileStream.SetLength(0);
            }

            // Write the randomly generated order into a txt file for use in the RSVP scene
            foreach (var file in textFiles)
            {
                using (StreamWriter writer = new StreamWriter(randomOrderFile, true))
                {
                    writer.WriteLine(file);
                }
            }
        }
        else
        {
            // Get the random Order from the txt file and convert it to an array while removing initial linebreaks or whitespaces
            string randomOrder = readFile(randomOrderFile).Trim();
            char[] randomOrderArray = randomOrder.ToCharArray();

            if (randomOrderArray.Length != 0)
            {
                // Specify the used thext file for CSV export
                activeTextFile = randomOrderArray[0].ToString();
                DataScript.ActiveTextFile = activeTextFile;

                string[] inputArray = readFile(directory + activeTextFile + ".txt").Split(' ');
                Debug.Log("Using File " + activeTextFile);

                // Delete the first item in the array that has just been "used"
                DeleteFirstItem(ref randomOrderArray);

                // Clear the txt file from previous uses
                using (FileStream fileStream = new FileStream(randomOrderFile, FileMode.Truncate))
                {
                    // Set the length of the file stream to 0 to clear its contents
                    fileStream.SetLength(0);
                }

                // Write the randomly generated order into a text file with one less file name
                using (StreamWriter writer = new StreamWriter(randomOrderFile))
                {
                    foreach (var file in randomOrderArray)
                    {
                        writer.Write(file);
                    }
                }

                StartCoroutine(Display());
            }
            else
            {
                Debug.Log("No more files left!");
            }
        }
        StartCoroutine(Display());
    }

    // Shuffles the array using the Fisher-Yates algorithm
    static void ShuffleArray<T>(T[] array)
    {
        System.Random random = new System.Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            SwapElements(array, i, j);
        }
    }

    static void SwapElements<T>(T[] array, int i, int j)
    {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static void DeleteFirstItem<T>(ref T[] array)
    {
        T[] newArray = new T[array.Length - 1];
        Array.Copy(array, 1, newArray, 0, newArray.Length);
        array = newArray;
    }

    string readFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string content = reader.ReadToEnd();
            return content;
        }
    }
    

    IEnumerator Display()
    {
        // Specify active phase before starting wait-timer
        DataScript.Phase = "calibration";
        // Wait before start
        yield return new WaitForSeconds(startPause);

        // Specify active phase before starting RSVP
        DataScript.Phase = "test";

        display.text = readFile(directory + activeTextFile + ".txt");

    }
}
