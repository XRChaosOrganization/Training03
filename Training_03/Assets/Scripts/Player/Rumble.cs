using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rumble : MonoBehaviour
{

    public Vector2 amplitude;
    public float duration;
    Gamepad gamepad;




    public void Play()
    {
        gamepad = Gamepad.current;
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(amplitude.x, amplitude.y);
            StartCoroutine(Stop());
        }
    }

    IEnumerator Stop()
    {
        if (gamepad != null)
        {
            yield return new WaitForSecondsRealtime(duration);
            gamepad.SetMotorSpeeds(0,0);
        }
    }


}
