using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhaseX",menuName = "ScriptableObjects/Phase", order = 0)]
public class PhaseSO : ScriptableObject
{
    public int number;
    public AudioManager.Track track;
    public ArenaGeometry arenaPattern;
    public enum powerUp { None,addBounce, addBlaster }
    public powerUp powerUpToAdd;
    // Ajouter types d'ennemis en enum ici
    public int enemyQty;
    public List<int> spawnProgression;

    
}
