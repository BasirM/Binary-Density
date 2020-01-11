using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class BossEnemyControl : MonoBehaviour
{
    public static int bossHealth = 20;
    [SerializeField] ParticleSystem explosion;

    public Boundary boundary;
    [SerializeField] float movementDuration;
    [SerializeField] float waitBeforeMoving;
    private bool bossReachedRandom;
    private float randomXPos, randomYPos;

    [SerializeField] Transform bossShotSpawn1;
    [SerializeField] Transform bossShotSpawn2;
    [SerializeField] Transform bossShotSpawn3;
    [SerializeField] GameObject bossShot1;
    [SerializeField] GameObject bossShot2;
    private float shot1Timer, shot2Timer;
    [SerializeField] float shot1FireRate;
    [SerializeField] float shot2FireRate;


    // Start is called before the first frame update
    void Start()
    {
        bossReachedRandom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameEnabled)
        {
            #region Boss Movement

            if (!bossReachedRandom)
            {
                bossReachedRandom = true;
                randomXPos = Random.Range(boundary.xMin, boundary.xMax);
                randomYPos = Random.Range(boundary.yMin, boundary.yMax);
                StartCoroutine(MoveToPoint(new Vector3(randomXPos, randomYPos, -.5f)));
            }
            #endregion

            #region Boss Shooting

            shot1Timer += Time.deltaTime;
            shot2Timer += Time.deltaTime;

            if (shot1Timer > shot1FireRate)
            {
                GameObject shoot1 = Instantiate(bossShot1, bossShotSpawn1.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                Destroy(shoot1, 310f);

                GameObject shoot2 = Instantiate(bossShot1, bossShotSpawn2.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                Destroy(shoot2, 10f);

                shot1Timer = 0;
            }

            if (shot2Timer > shot2FireRate)
            {
                GameObject shoot3 = Instantiate(bossShot2, bossShotSpawn3.position, Quaternion.identity);
                Destroy(shoot3, 10f);

                shot2Timer = 0;
            }
            #endregion

            if (bossHealth <= 0)
            {
                GameController.level2Done = true;
                Destroy(gameObject);
                ParticleSystem boom = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(boom, 2);
            }
        }

    }

    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeMoving);
        bossReachedRandom = false;
    }
}
