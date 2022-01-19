using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCommponent : MonoBehaviour
{
    //public Vector3 firedirection;
    private Rigidbody bulletRb;
    public float bulletSpeed;
    public int currentBounces;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
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
    }
}
