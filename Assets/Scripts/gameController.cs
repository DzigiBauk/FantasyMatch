using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static Queue<GameObject> planes = new Queue<GameObject>();
    public static Queue<GameObject> objects = new Queue<GameObject>();

    public static Vector3 position;
    public GameObject starterPlane;

    public static int counter = 0;

    void Start()
    {
        //Enqueue for derendering
        planes.Enqueue(starterPlane);
    }

}
