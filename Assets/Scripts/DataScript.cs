using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataScript
{
    private static float dilation_L;
    private static float dilation_R;
    private static Vector3 averageGazeDirection;  
    private static Vector3 gazeOrigin;
    private static Vector3 hitPoint;

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

    
    public static Vector3 AverageGazeDirection
    {
        get
        {
            return averageGazeDirection;
        }

        set
        {
            averageGazeDirection = value;
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
}