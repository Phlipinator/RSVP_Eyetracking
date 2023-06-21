using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using TMPro;

public class Simple_RSVP : MonoBehaviour
{
    public TMP_Text display;
    public int speed;
    public int startPause;

    private string[] inputArray;
    private float pauseInterval;

    private void Start()
    {
        readTextFile("test.txt");

        // Convert words per minute into seconds between words
        pauseInterval = 1/(speed/60f);
        Debug.Log("Current Pause Interval: " + pauseInterval);

        DataScript.Wpm = speed;

        StartCoroutine(RSVP_Display());

    }

    IEnumerator  RSVP_Display(){
        DataScript.Phase = "calibration";
        // Wait before start
        yield return new WaitForSeconds(startPause);

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
