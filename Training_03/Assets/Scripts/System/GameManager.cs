using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int score;
    
    public Camera mainCamera;
    public PlayerController player;
    public Transform obstaclesContainer;
    public List<ObstacleComponent> obstaclesList;
    public Transform bulletContainer;
    public List<PhaseSO> phaseList;
    

    [Space]
    [Header("Particles")]
    [Space]

    public Transform particlesContainer;
    public GameObject explosionParticles;



    [Space]
    [Header("Spawn")]
    [Space]
    
    public Transform spawnerContainer;
    public Transform enemyContainer;
    
    public GameObject enemyprefab;
    public float timeBetweenSpawns;
    public float timeBetweenWaves;
    
    public List<GameObject> activeSpawners;
    public List<GameObject> availableSpawners;
        
    private void Awake()
    {
        gm = this;
        
        foreach (Transform child in obstaclesContainer)
        {
             obstaclesList.Add(child.gameObject.GetComponent<ObstacleComponent>());
        }
        
        foreach (Transform child in spawnerContainer)
        {
            activeSpawners.Add(child.gameObject);
        }
    }

    public void StartGame() 
    {
        EnablePhase(0);
    }

    public void CheckScore()
    {
        switch (score)
        {
            case 1000:
                EnablePhase(1);
                break;

            case 2000:
                EnablePhase(2);
                break;

            case 3000:
                EnablePhase(3);
                break;

            case 4000:
                EnablePhase(4);
                break;

            default:
                break;

        }
    }

    public void EnablePhase(int _phasenumber)
    {
        Debug.Log("Phase " + _phasenumber + " � d�but�");
        SetArenaPattern(_phasenumber);
        AudioManager.am.Mute(phaseList[_phasenumber].track, true);
        AddPowerUp(_phasenumber);
        StartCoroutine(SpawnPhaseWaves(_phasenumber));
        
    }
    private void SetArenaPattern(int _phasenumber)
    {
        for (int i = 0; i < phaseList[_phasenumber].arenaPattern.activatedObsacles.Length ; i++)
        {
            obstaclesList[i].SetObstacleActive(phaseList[_phasenumber].arenaPattern.activatedObsacles[i]);
        }
    }
    private void AddPowerUp(int _phasenumber)
    {
        if (phaseList[_phasenumber].powerUpToAdd == PhaseSO.powerUp.None)
        {
            return;
        }
        if (phaseList[_phasenumber].powerUpToAdd == PhaseSO.powerUp.addBounce)
        {
            player.maxBulletBounces++;
        }
        else
        {
            if (player.isLeftFireEnabled)
            {
                player.isRightFireEnabled = true;
            }
            else
            {
                player.isLeftFireEnabled = true;
            }
        }
        
    }
    public IEnumerator SpawnPhaseWaves(int _phasenumber)
    {
        for (int i = 0; i < phaseList[_phasenumber].spawnProgression.Count; i++)
        {
            UpdateSpawnerList();
            StartCoroutine(SpawnRandomly(phaseList[_phasenumber].spawnProgression[i],_phasenumber));
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
    
    public void UpdateSpawnerList()
    {
        availableSpawners.Clear();
        for (int i = 0; i < activeSpawners.Count; i++)
        {
            if (activeSpawners[i].GetComponent<SpawnerComponent>().isAvailable())
            {
                availableSpawners.Add(activeSpawners[i]);
            }
        }
    }
    public IEnumerator SpawnRandomly(int _waveQty,int _phasenumber)
    {
        
        if (_waveQty<= availableSpawners.Count)
        {
            List<int> randomizator = new List<int>();
            while (randomizator.Count < _waveQty)
            {
                int r = Random.Range(0, availableSpawners.Count);
                if (randomizator.Contains(r))
                {
                    continue;
                }
                else
                {
                    randomizator.Add(r);
                }
            }
            for (int i = 0; i < _waveQty; i++)
            {
                Instantiate(enemyprefab, availableSpawners[randomizator[i]].transform.position, Quaternion.identity, enemyContainer);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }
        else
        {
            int spawnsToDelay = _waveQty - availableSpawners.Count;
            phaseList[_phasenumber].spawnProgression.Add(spawnsToDelay);
            for (int i = 0; i < availableSpawners.Count; i++)
            {
                Instantiate(enemyprefab, availableSpawners[i].transform.position, Quaternion.identity, enemyContainer);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
            
        }
        
        
    }
}
