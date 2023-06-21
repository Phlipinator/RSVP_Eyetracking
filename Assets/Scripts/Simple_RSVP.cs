using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using TMPro;

public class Simple_RSVP : MonoBehaviour
{
    public TMP_Text display;
    public int speed;
    public int startPause;
    public string textFile;
    public bool useRandomTextfile;

    private string[] inputArray;
    private float pauseInterval;

    private void Start()
    {
        // Handle file selection either using a random file or a specific one
        string directory = "Assets/TextFiles/";
        string[] textFiles = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        if(useRandomTextfile){
            System.Random rnd = new System.Random();
            int randomFile = rnd.Next(0, 9);
            readTextFile(directory + textFiles[randomFile].ToString() + ".txt");

            Debug.Log("Using random File " + textFiles[randomFile].ToString());

        }else{
            readTextFile(directory + textFile + ".txt");
            
            Debug.Log("Using File " + textFile);
        }

        // Convert words per minute into seconds between words
        pauseInterval = 1/(speed/60f);
        Debug.Log("Current Pause Interval: " + pauseInterval);

        DataScript.Wpm = speed;

        StartCoroutine(RSVP_Display());

    }

    IEnumerator  RSVP_Display(){
        // Specify active phase before starting wait-timer
        DataScript.Phase = "calibration";
        // Wait before start
        yield return new WaitForSeconds(startPause);

        // Specify active phase before starting RSVP
        DataScript.Phase = "test";

        foreach (var word in inputArray)
        {
            display.text = word;
            yield return new WaitForSeconds(pauseInterval);

        }
    }

    // Inspiration for this was found here:
    // https://gamedev.stackexchange.com/questions/85807/how-to-read-a-data-from-text-file-in-unity
    void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            string inputPhrase = inp_stm.ReadLine(); 
            
            inputArray = inputPhrase.Split(' ');
        }

        inp_stm.Close();
    }
}
