using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCommponent : MonoBehaviour
{
    public Vector3 firedirection;
    private Rigidbody bulletRb;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.velocity = firedirection *bulletSpeed;
    }
    private void OnCollisionEnter(Collision col)
    {
      // if (col.collider.name == "Walls")
      // {
      //     firedirection = Vector3.Reflect(transform.position, col.transform.position);
      // }
    }
}
