using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject spawnerContainer;
    public GameObject enemyContainer;
    public GameObject enemyprefab;
    public Transform player;
    // Sera un vector 3 contenant (nb crasher,nb fly, nb blindés par ex) OU SO (mieux)!!!
    //Pour l'instant , une seule wave test avec uniquement l'ennemi crasher ;
    public int firstwaveamount = 8;
    public List<GameObject> activeSpawners;
    public List<GameObject> availableSpawners;
        
    private void Awake()
    {
        gm = this;
        
        foreach (Transform child in spawnerContainer.transform)
        {
            activeSpawners.Add(child.gameObject);
        }
    }

    private void Start() // SERA REMPLACEE AVEC LE SCORING DU JEU / CORRDINATION DES PHASES DE JEU ===> TEST PURPOSE
    {
        StartCoroutine(SpawnWave(firstwaveamount));
    }
    public IEnumerator SpawnWave(int _crasheramount)
    {
        for (int i = 0; i < _crasheramount; i++)
        {
            UpdateSpawnerList();
            SpawnRandomly();
            yield return new WaitForSeconds(2f);
        }
        
        
    }
    public void UpdateSpawnerList()
    {
        for (int i = 0; i < activeSpawners.Count; i++)
        {
            if (activeSpawners[i].GetComponent<SpawnerComponent>().canSpawn == true)
            {
                availableSpawners.Add(activeSpawners[i]);
            }
        }
    }
    public void SpawnRandomly()
    {
        Instantiate(enemyprefab,availableSpawners[Random.Range(0,availableSpawners.Count)].transform.position, Quaternion.identity, enemyContainer.transform);
        
    }
}
