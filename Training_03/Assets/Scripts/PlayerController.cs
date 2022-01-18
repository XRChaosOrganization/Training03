using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    private Rigidbody rb;
    public float moveSpeed;
    private Vector3 moveDirection;
    private Camera mainCamera;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    public void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
         
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay,out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }


    void HandleMovement()
    {
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.transform.position,Quaternion.identity );
        bulletGO.GetComponent<BulletCommponent>().firedirection = firePoint.transform.position - transform.position;
    }
    
}
