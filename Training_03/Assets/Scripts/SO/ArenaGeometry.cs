using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Disposition", menuName = "ScriptableObjects/Geometry", order = 1)]
public class ArenaGeometry : ScriptableObject
{
    public bool[] activatedObsacles = new bool[11];
}
