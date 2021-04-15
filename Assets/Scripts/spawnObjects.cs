using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    public List<GameObject> spawnables = new List<GameObject>();
    GameObject posObj;

    void Start()
    {
        //Spawn random objects at set positions, and enqueue for destruction
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        int random = Random.Range(0, spawnables.Count);

        GameObject spawnable = Instantiate(spawnables[random], position, Quaternion.Euler(new Vector3(0, 0, 0)));
        gameController.objects.Enqueue(spawnable);
    }
}
