using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazePositionCalculator : MonoBehaviour
{
    public GameObject gazeTarget;
    public GameObject pointerCube;

    private Plane targetPlane;
    private Vector3 distanceFromCamera;

    // Start is called before the first frame update
    void Start()
    {
        //This is how far away from the Camera the plane is placed
        distanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - gazeTarget.transform.position.z);

        //Create a new plane with normal (0,0,1) at the position away from the camera you define in the Inspector. This is the plane that you can click so make sure it is reachable.
        targetPlane = new Plane(Vector3.forward, distanceFromCamera);
    }

    void Update()
    {
        //Create a ray from the Mouse click position
        Ray ray = Camera.main.ScreenPointToRay(DataScript.AverageGazeDirection);

        //Initialise the enter variable
        float enter = 0.0f;

        if (targetPlane.Raycast(ray, out enter))
        {
            //Get the point that is clicked
            Vector3 hitPoint = ray.GetPoint(enter);

            //Move your cube GameObject to the point where you clicked
            pointerCube.transform.position = hitPoint;
        }
    }
}