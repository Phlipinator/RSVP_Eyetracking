using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class EnvironmentChanger : MonoBehaviour
{
    public GameObject BG;
    public TMP_Text RSVP;
    public Material whiteBG;
    public Material greyBG;
    public Material blackBG;


    // Start is called before the first frame update
    void Start()
    {
        Color32 grey = new Color32(128, 128, 128, 255);
        Color32 black = new Color32(0, 0, 0, 255);

        switch (DataScript.BackgroundColor)
        {
            case "W":
                BG.GetComponent<MeshRenderer>().material = whiteBG;
                RSVP.color = grey;
                break;
            case "G":
                BG.GetComponent<MeshRenderer>().material = greyBG;
                RSVP.color = black;
                break;
            case "B":
                BG.GetComponent<MeshRenderer>().material = blackBG;
                RSVP.color = grey;
                break;
            default:
                Debug.Log("Error: Invalid Selection");
                break;
        }
    }
}
