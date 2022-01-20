using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChargerBehavior : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;

    private void Start()
    {
        player = GameManager.gm.player.transform;
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nav.SetDestination(player.position);
    }
}
