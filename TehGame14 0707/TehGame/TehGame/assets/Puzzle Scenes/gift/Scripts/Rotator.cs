using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public static bool Stopped = false;

    public static void Start()
    {
        Stopped = false;
    }

    public static void Stop()
    {
        Stopped = true;
    }

    void Update ()
    {
        if (Stopped == false)
        {
            transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime); //Määritellään objekti pyörimään akselin ympäri
        }
        else if (Stopped == true)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
    }    
}
