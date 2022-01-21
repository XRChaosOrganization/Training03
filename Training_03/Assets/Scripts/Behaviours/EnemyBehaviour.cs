using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    
    public Transform player;
    public NavMeshAgent nav;
    public bool isFollow;
    public Material glowMaterial;
    public Vector2 particleLifetime;
    public int scoreWorthPoints;
    AudioSource audioSource;
    SphereCollider col;
    Renderer rd;
    Light lightsource;
    public bool doDestroy;

    private void Awake()
    {
        player = GameManager.gm.player.transform;
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        rd = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        lightsource = GetComponentInChildren<Light>();
    }

    public virtual IEnumerator Kill()
    {
        //col.enabled = false;
        GameObject particle = (GameObject)Instantiate(GameManager.gm.explosionParticles, transform.position, Quaternion.identity, GameManager.gm.particlesContainer);
        particle.GetComponent<ExplosionFXComponent>().Init(glowMaterial.GetColor("_ColorGlow"), particleLifetime);

        isFollow = false;
        rd.enabled = false;
        if (lightsource != null)
            lightsource.intensity = 0f;

        audioSource.Play();
        
        GameManager.gm.score += scoreWorthPoints;
        
        yield return new WaitForSeconds(audioSource.clip.length);
        yield return new WaitForEndOfFrame();
        doDestroy = true;
        //Destroy(this.gameObject);
    }
}
