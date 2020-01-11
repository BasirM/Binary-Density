using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float shotSpeed;
    [SerializeField] ParticleSystem explosion;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip explosionSound;

    //[SerializeField] GameObject scoreFloatingText;
    //TextMeshProUGUI floatingScoreTextMesh;
    //GameObject canvas;

    const float dropChance = 1f / 10f;

    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.FindGameObjectWithTag("Canvas");
        explosion.playOnAwake = true;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * shotSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy1"))
        {
            Destroy(other.gameObject);
            EnemyHit(5);

        }

        if (other.gameObject.CompareTag("Enemy2"))
        {
            Destroy(other.gameObject);
            EnemyHit(10);
        }

        if(other.gameObject.CompareTag("Enemy Boss"))
        {
            BossEnemyControl.bossHealth--;
            Destroy(gameObject);//has to be last
        }
    }

    public void EnemyHit(int pointsToAdd)
    {
        audioSource.PlayOneShot(explosionSound, .15f);

        GameController.enemiesDefeated++;
        GameController.score += pointsToAdd;

        ParticleSystem boom = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(boom, 2);

        //GameObject floatingScore = Instantiate(scoreFloatingText, transform.position, Quaternion.identity, canvas.transform) as GameObject;
        //floatingScoreTextMesh = floatingScore.GetComponent<TextMeshProUGUI>();
        //floatingScoreTextMesh.SetText("+5");
        //Destroy(floatingScore, .5f);

        if (Random.Range(0f, 1f) <= dropChance)
        {
            int num = Random.Range(0, GameController.pickups.Count);
            GameObject pickup = Instantiate(GameController.pickups[num], transform.position, Quaternion.identity) as GameObject;
        }

        Destroy(gameObject);//has to be last
    }
}
