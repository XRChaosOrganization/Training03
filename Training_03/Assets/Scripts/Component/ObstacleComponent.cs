using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComponent : MonoBehaviour
{
    
    public float yOn;
    public float yOff;
    public float tranitionTime;
    public bool isActive;
    public bool targetState = true;
    public BoxCollider sensor;
    float timer = 0f;

    private void Update()
    {
        Vector3 pos = transform.position;
        if (targetState != isActive)
        {
            if (timer < tranitionTime)
            {

                pos.y = Mathf.Lerp(targetState ? yOff : yOn, targetState ? yOn : yOff, timer / tranitionTime);
                transform.position = pos;
                timer += Time.deltaTime;


                if (timer >= tranitionTime)
                {

                    timer = 0f;
                    isActive = targetState;
                    sensor.isTrigger = !targetState;
                }
                


            }
        }
        
    }

    public void SetObstacleActive(bool _b)
    {

        Vector3 pos = transform.position;

        if (!sensor.isTrigger && _b)
            sensor.isTrigger = false;

        if (isActive != _b)
        {
            targetState = _b;


        }
    }
}
