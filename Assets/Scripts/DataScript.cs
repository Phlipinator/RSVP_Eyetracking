using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataScript
{
    private static float dilation_L;
    private static float dilation_R;
    private static Vector3 gazeDirection;
    private static Vector3 gazeOrigin;
    private static Vector3 hitPoint;
    private static string calculationMethod;
    private static int wpm;
    private static string phase;
    private static string backgroundColor;

    public static float Dilation_L
    {
        get
        {
            return dilation_L;
        }

        set
        {
            dilation_L = value;
        }
    }

    public static float Dilation_R
    {
        get
        {
            return dilation_R;
        }

        set
        {
            dilation_R = value;
        }
    }

    public static Vector3 GazeDirection
    {
        get
        {
            return gazeDirection;
        }

        set
        {
            gazeDirection = value;
        }
    }

    public static Vector3 GazeOrigin
    {
        get
        {
            return gazeOrigin;
        }

        set
        {
            gazeOrigin = value;
        }
    }

    // Store the gaze Position
    public static Vector3 HitPoint
    {
        get
        {
            return hitPoint;
        }

        set
        {
            hitPoint = value;
        }
    }

    // Can be either A vor average or L/R for left and right
    public static string CalculationMethod
    {
        get
        {
            return calculationMethod;
        }

        set
        {
            calculationMethod = value;
        }
    }

    // Stores the spped in words per minute
    public static int Wpm
    {
        get
        {
            return wpm;
        }

        set
        {
            wpm = value;
        }
    }

    // Stores the active phase
    // Can either be calibration or test
    public static string Phase
    {
        get
        {
            return phase;
        }

        set
        {
            phase = value;
        }
    }

    // Stores the active Background color
    //can either be W for White, G for Grey or B for Black
    public static string BackgroundColor
    {
        get
        {
            return backgroundColor;
        }

        set
        {
            backgroundColor = value;
        }
    }

}