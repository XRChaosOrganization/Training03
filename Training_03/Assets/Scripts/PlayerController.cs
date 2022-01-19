using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Space]
    [Header("Components")]
    [Space]

    public int maxBulletBounces;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    private Rigidbody rb;
    private Camera mainCamera;
    public GameObject bulletContainer;
    PlayerInput playerInput;

    [Space]
    [Header("Controls")]
    [Space]

    public float moveSpeed;
    private Vector3 moveDirection;
    Vector3 aimDirection;
    Vector3 stickAim;

    [Space]
    [Header("Controls")]
    [Space]
    public bool isShooting;
    public bool isPause;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        playerInput = GetComponent<PlayerInput>();
        
    }

    public void Update()
    {
        
        if (isShooting)
            Shoot();
        if (isPause)
            Pause();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleAim();

    }


    void HandleMovement()
    {
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    void HandleAim()
    {


            if (playerInput.currentControlScheme == "Gamepad")
            {


                if (stickAim == Vector3.zero)
                {
                    aimDirection = transform.position + transform.forward;
                    transform.LookAt(aimDirection);
                }

                else
                {
                    aimDirection = stickAim + transform.position;
                    transform.LookAt(aimDirection);
                }
                    


                

            }
            else 
            {
                aimDirection = Vector3.zero;
                Ray cameraRay = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (groundPlane.Raycast(cameraRay, out rayLength))
                {
                    aimDirection = cameraRay.GetPoint(rayLength);
                    aimDirection.y = transform.position.y;
                    transform.LookAt(aimDirection);

                }
            }




        }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity,bulletContainer.transform);
        bulletGO.transform.rotation = this.gameObject.transform.rotation;
        bulletGO.GetComponent<BulletCommponent>().currentBounces = maxBulletBounces;


        isShooting = false; //on termine l'input ici pour eviter de tirer en permanence tant qu'on reste appuyé
    }

    public void Pause()
    {
        //Faire Apparaitre le menu Pause


        isPause = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        moveDirection = moveDirection.normalized;
        

    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = true;
        if (context.canceled)
            isShooting = false;
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        stickAim.x = input.x;
        stickAim.z = input.y;
        stickAim = stickAim.normalized;

    }

    public void OnPause(InputAction.CallbackContext context)
    {
        isPause = true;
        if (context.canceled)
            isPause = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(aimDirection, 0.1f);
    }
}
