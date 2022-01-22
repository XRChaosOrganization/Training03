using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCommponent : MonoBehaviour
{
    public bool isShot;
    private Rigidbody bulletRb;
    public float bulletSpeed;
    public int currentBounces;

    Vector3 reflect;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
        StartCoroutine(EnableDamage());
    }

    void Update()
    {
        
        DetectObstacle();
        bulletRb.velocity = transform.forward * bulletSpeed;
    }

    private void DetectObstacle()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, 1 << 8))
        {
            ObstacleComponent obstacle = hit.transform.gameObject.GetComponent<ObstacleComponent>();
            if (obstacle != null && !obstacle.isActive)
            {
                return;
            }
            else
            {
                Vector3 reflect = Vector3.Reflect(bulletRb.velocity, hit.normal);
                Debug.DrawRay(transform.position, reflect);
                transform.LookAt(reflect);
                bulletRb.velocity = transform.forward * bulletSpeed;
                currentBounces--;
                if (currentBounces < 0)
                {
                    //Anim destruction bullet?
                    Destroy(this.gameObject);
                }
            }
            
        }
    }
    private void OnCollisionEnter(Collision col)
    {
       
        if (col.collider.CompareTag("Player") && isShot ==false && col.gameObject.GetComponent<PlayerController>() != null)
        {
            //Anim destruction bullet?
            col.gameObject.GetComponent<PlayerController>().TakeDamage();
            Destroy(this.gameObject);
        }
        

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = col.gameObject.GetComponent<EnemyBehaviour>();
            StartCoroutine(enemy.Kill());
        }
            
    }

    IEnumerator EnableDamage()
    {
        yield return new WaitForSeconds(.1f);
        isShot = false;
    }
}
