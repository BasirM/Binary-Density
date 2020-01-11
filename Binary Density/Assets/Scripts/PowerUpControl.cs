using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpControl : MonoBehaviour
{
    [SerializeField] float pickUpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * pickUpSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Laser Pickup"))
            {
                PlayerController.shootingType = 1;
            }
            else if(gameObject.CompareTag("Cannon Pickup"))
            {
                PlayerController.shootingType = 2;
            }
            else if(gameObject.CompareTag("Rocket Pickup"))
            {
                PlayerController.shootingType = 3;
            }

            Destroy(gameObject);
        }
    }
}
