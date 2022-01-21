using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComponent : MonoBehaviour
{
    
    public float yOn;
    public float yOff;
    public float tranitionTime;
    public bool isActive;
    public BoxCollider sensor;

    

    public void SetObstacleActive(bool _b)
    {
        float timer = 0f;
        Vector3 pos = transform.position;
        if (!sensor.isTrigger && _b)
            sensor.isTrigger = false;

        if (isActive != _b)
        {
            while (timer < tranitionTime)
            {
                timer += Time.deltaTime;
                pos.y = Mathf.Lerp(_b ? yOff : yOn, _b? yOn : yOff, timer / tranitionTime);
                transform.position = pos;
            }

            isActive = _b;
            sensor.isTrigger = !_b;

            
        }

       
            
    }
}
