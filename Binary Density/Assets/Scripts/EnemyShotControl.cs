using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float enemyShotSpeed;
    [SerializeField] ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        explosion.playOnAwake = true;
        rb = GetComponent<Rigidbody>();
        if(gameObject.CompareTag("Enemy Shot 1"))
        {
            rb.velocity = transform.up * enemyShotSpeed;

        }
        else if(gameObject.CompareTag("Enemy Shot 2"))
        {
            rb.velocity = -transform.up * enemyShotSpeed;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            ParticleSystem boom = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(boom, 2);

            GameController.playerDead = true;

            Destroy(gameObject);
        }
    }
}
