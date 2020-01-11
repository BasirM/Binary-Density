using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    private Vector3 touchPosition;
    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] float moveSpeed;

    [SerializeField] GameObject laserShot;
    [SerializeField] GameObject autoCannonShot;
    [SerializeField] GameObject missileShot;
    [SerializeField] Transform shotSpawn;
    [SerializeField] float laserFireRate;
    [SerializeField] float autoCannonFireRate;
    [SerializeField] float missleFireRate;

    private float nextFire = 0.0f;
    public static int shootingType;

    [SerializeField] GameObject playerShipVFX;
    [SerializeField] Material regularShipMaterial;
    [SerializeField] Material transparentShipMaterial;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip laserSound, rocketSound, cannonSound;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootingType = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.sceneName != "Main Menu")
        {
            if (GameController.gameEnabled)
            {
                #region Player Movement



                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = -.5f;

                    Vector3 touchPosWorld = new Vector3(touchPosition.x, touchPosition.y, touchPosition.z);

                    if(touchPosition.x >= -5.9 && (touchPosition.y >= 2 || touchPosition.y <=0))
                    {
                        if(touchPosition.x <= 5.5 &&(touchPosition.y <= 4 || touchPosition.y >= 5.9))
                        direction = (touchPosition - transform.position);
                        rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        rb.velocity = Vector2.zero;
                    }
                }
           

                #endregion Player Movement

                #region Projectile Control

                //instantites shots
                if (Time.time > nextFire)
                {
                    if (shootingType == 1)
                    {
                        nextFire = Time.time + laserFireRate;
                        GameObject shot = Instantiate(laserShot, shotSpawn.position, shotSpawn.rotation) as GameObject;
                        audioSource.PlayOneShot(laserSound, .3f);
                        Destroy(shot, 3f);
                    }
                    else if (shootingType == 2)
                    {
                        nextFire = Time.time + autoCannonFireRate;
                        GameObject shot = Instantiate(autoCannonShot, shotSpawn.position, shotSpawn.rotation) as GameObject;
                        audioSource.PlayOneShot(cannonSound, .3f);
                        Destroy(shot, 3f);
                    }
                    else if (shootingType == 3)
                    {
                        nextFire = Time.time + missleFireRate;
                        GameObject shot = Instantiate(missileShot, shotSpawn.position, shotSpawn.rotation) as GameObject;
                        audioSource.PlayOneShot(rocketSound, .3f);
                        Destroy(shot, 3f);
                    }

                }

                #endregion Projectile Control

                #region Binary Shifter
                if (GameController.binaryShifterActive)
                {
                    playerShipVFX.GetComponent<MeshRenderer>().material = transparentShipMaterial;
                    GetComponent<BoxCollider>().enabled = false;
                }
                else if (!GameController.binaryShifterActive)
                {
                    GetComponent<BoxCollider>().enabled = true;
                    playerShipVFX.GetComponent<MeshRenderer>().material = regularShipMaterial;
                }
                #endregion Binary Shifter
            }
        }
        
    }
}
