using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public bool isPlayerNear;
    public bool isObstacleNear;


    public bool isAvailable()
    {
        if (isPlayerNear || isObstacleNear)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Sensor"))
        {
            isPlayerNear = true;
        }

        if (col.CompareTag("Obstacle"))
        {
            isObstacleNear = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Sensor"))
        {
            isPlayerNear = false;
        }
        if (col.CompareTag("Obstacle"))
        {
            isObstacleNear = false;
        }
    }
    
}
