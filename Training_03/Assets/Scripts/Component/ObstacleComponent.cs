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
    //bool isMoving;
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
                    //isMoving = false;
                    timer = 0f;
                    isActive = targetState;
                    sensor.isTrigger = !targetState;
                }
                


            }
        }
        
    }

    public void SetObstacleActive(bool _b)
    {
        //float timer = 0f;
        Vector3 pos = transform.position;

        if (!sensor.isTrigger && _b)
            sensor.isTrigger = false;

        if (isActive != _b)
        {
            targetState = _b;


            //while (timer < tranitionTime)
            //{
            //    pos.y = Mathf.Lerp(_b ? yOff : yOn, _b ? yOn : yOff, timer / tranitionTime);
            //    transform.position = pos;
            //    timer += Time.deltaTime;


            //}

            //isActive = _b;
            //sensor.isTrigger = !_b;


            //}



        }
    }
}
