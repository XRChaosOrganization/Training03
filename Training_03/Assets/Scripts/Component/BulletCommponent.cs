using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCommponent : MonoBehaviour
{
    public bool isShot;
    private Rigidbody bulletRb;
    public float bulletSpeed;
    public int currentBounces;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
        StartCoroutine(EnableDamage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
       
        if (col.collider.CompareTag("Obstacle"))
      {
            currentBounces--;
            if (currentBounces <0)
            {
                //Anim destruction bullet?
                Destroy(this.gameObject);
            }
      }
        if (col.collider.CompareTag("Player") && isShot ==false)
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
