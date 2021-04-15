using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePL : MonoBehaviour
{
    public GameObject plane;
    public GameObject pitStop;

    public static Vector3 position;
    public int howMany;

    public static Vector3 getPosition()
    {
        return position;
    }
    void OnTriggerEnter(Collider col)
    {
        //Control the number of planes and spawnables
        //Not as dynamic as I'd like it to be. To be altered.
        if (gameController.planes.Count > 5)
        {
            for (int i = 0; i < howMany; i++)
            {
                Destroy(gameController.planes.Dequeue());

                for (int j = 0; j < 3; j++)
                {
                    Destroy(gameController.objects.Dequeue());
                }
            }
        }

        if (gameController.counter == 3)
        {
            gameController.counter = 0;

            position.z += plane.transform.localScale.z * 10;
            GameObject newPlane = Instantiate(pitStop, position, Quaternion.identity);
            gameController.planes.Enqueue(newPlane);
        }
        else if (gameController.planes.Count < 3)
        {
            for (int i = 0; i < howMany; i++)
            {
                position.z += plane.transform.localScale.z * 10;
                GameObject newPlane = Instantiate(plane, position, Quaternion.identity);
                gameController.planes.Enqueue(newPlane);

                gameController.counter++;
            }
        } else
        {
            position.z += plane.transform.localScale.z * 10;
            GameObject newPlane = Instantiate(plane, position, Quaternion.identity);
            gameController.planes.Enqueue(newPlane);

            gameController.counter++;
        }
        
    }
}
