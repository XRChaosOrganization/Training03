using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public bool canSpawn = true;

    public void isPlayerNear(bool _isplayernear)
    {
        canSpawn =! _isplayernear;
    }

    //DETECTER LES WALLS ADJACENTS !!!
}
