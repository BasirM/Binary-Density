using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] GameObject[] enemyTargetPoints;
    [SerializeField] float enemySpeed;
    private float moveStep;
    private bool reachedMiddle;
    private Vector3 lineUpPoint;

    [SerializeField] Transform enemyShotSpawn;
    [SerializeField] GameObject enemyShot1;
    [SerializeField] GameObject enemyShot2;
    [SerializeField] float shot1FireRateMin;
    [SerializeField] float shot1FireRateMax;
    [SerializeField] float shot2FireRateMin;
    [SerializeField] float shot2FireRateMax;
    private float nextFire;

    private int enemyType;

    int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        reachedMiddle = false;
        GameController.currentEnemies++;

        System.Random random = new System.Random();
        randomInt = random.Next(0, enemyTargetPoints.Length);

        if(gameObject.CompareTag("Enemy1"))
        {
            enemyType = 1;
        }
        else if(gameObject.CompareTag("Enemy2"))
        {
            enemyType = 2;

        }

        if(enemyType == 1)
        {
            nextFire = nextFire + Random.Range(shot1FireRateMin, shot1FireRateMax);
        }

        if(enemyType == 2)
        {
            nextFire = nextFire + Random.Range(shot2FireRateMin, shot2FireRateMax);

        }

        #region Enemy Line Up Wave Points
        if (SpawnControl.waveNumber == 1)
        {
            switch (GameController.currentEnemies)
            {

                case 1:
                    lineUpPoint = EnemyLocationStructs.Wave1.e1Pos;
                    break;
                case 2:
                    lineUpPoint = EnemyLocationStructs.Wave1.e2Pos;
                    break;
                case 3:
                    lineUpPoint = EnemyLocationStructs.Wave1.e3Pos;
                    break;
                case 4:
                    lineUpPoint = EnemyLocationStructs.Wave1.e4Pos;
                    break;
                case 5:
                    lineUpPoint = EnemyLocationStructs.Wave1.e5Pos;
                    break;
                case 6:
                    lineUpPoint = EnemyLocationStructs.Wave1.e6Pos;
                    break;
                case 7:
                    lineUpPoint = EnemyLocationStructs.Wave1.e7Pos;
                    break;
                case 8:
                    lineUpPoint = EnemyLocationStructs.Wave1.e8Pos;
                    break;
                case 9:
                    lineUpPoint = EnemyLocationStructs.Wave1.e9Pos;
                    break;
                case 10:
                    lineUpPoint = EnemyLocationStructs.Wave1.e10Pos;
                    break;
                case 11:
                    lineUpPoint = EnemyLocationStructs.Wave1.e11Pos;
                    break;
                case 12:
                    lineUpPoint = EnemyLocationStructs.Wave1.e12Pos;
                    break;
                case 13:
                    lineUpPoint = EnemyLocationStructs.Wave1.e13Pos;
                    break;
                case 14:
                    lineUpPoint = EnemyLocationStructs.Wave1.e14Pos;
                    break;
                case 15:
                    lineUpPoint = EnemyLocationStructs.Wave1.e15Pos;
                    break;
                case 16:
                    lineUpPoint = EnemyLocationStructs.Wave1.e16Pos;
                    break;
                case 17:
                    lineUpPoint = EnemyLocationStructs.Wave1.e17Pos;
                    break;
            }
        }

        else if (SpawnControl.waveNumber == 2)
        {
            switch (GameController.currentEnemies)
            {
                case 1:
                    lineUpPoint = EnemyLocationStructs.Wave2.e1Pos;
                    break;
                case 2:
                    lineUpPoint = EnemyLocationStructs.Wave2.e2Pos;
                    break;
                case 3:
                    lineUpPoint = EnemyLocationStructs.Wave2.e3Pos;
                    break;
                case 4:
                    lineUpPoint = EnemyLocationStructs.Wave2.e4Pos;
                    break;
                case 5:
                    lineUpPoint = EnemyLocationStructs.Wave2.e5Pos;
                    break;
                case 6:
                    lineUpPoint = EnemyLocationStructs.Wave2.e6Pos;
                    break;
                case 7:
                    lineUpPoint = EnemyLocationStructs.Wave2.e7Pos;
                    break;
                case 8:
                    lineUpPoint = EnemyLocationStructs.Wave2.e8Pos;
                    break;
                case 9:
                    lineUpPoint = EnemyLocationStructs.Wave2.e9Pos;
                    break;
                case 10:
                    lineUpPoint = EnemyLocationStructs.Wave2.e10Pos;
                    break;
                case 11:
                    lineUpPoint = EnemyLocationStructs.Wave2.e11Pos;
                    break;
                case 12:
                    lineUpPoint = EnemyLocationStructs.Wave2.e12Pos;
                    break;
                case 13:
                    lineUpPoint = EnemyLocationStructs.Wave2.e13Pos;
                    break;
                case 14:
                    lineUpPoint = EnemyLocationStructs.Wave2.e14Pos;
                    break;
                case 15:
                    lineUpPoint = EnemyLocationStructs.Wave2.e15Pos;
                    break;
                case 16:
                    lineUpPoint = EnemyLocationStructs.Wave2.e16Pos;
                    break;
                case 17:
                    lineUpPoint = EnemyLocationStructs.Wave2.e17Pos;
                    break;
                case 18:
                    lineUpPoint = EnemyLocationStructs.Wave2.e18Pos;
                    break;
                case 19:
                    lineUpPoint = EnemyLocationStructs.Wave2.e19Pos;
                    break;
                case 20:
                    lineUpPoint = EnemyLocationStructs.Wave2.e20Pos;
                    break;
                case 21:
                    lineUpPoint = EnemyLocationStructs.Wave2.e21Pos;
                    break;
                case 22:
                    lineUpPoint = EnemyLocationStructs.Wave2.e22Pos;
                    break;
                case 23:
                    lineUpPoint = EnemyLocationStructs.Wave2.e23Pos;
                    break;
                case 24:
                    lineUpPoint = EnemyLocationStructs.Wave2.e24Pos;
                    break;
                case 25:
                    lineUpPoint = EnemyLocationStructs.Wave2.e25Pos;
                    break;
                case 26:
                    lineUpPoint = EnemyLocationStructs.Wave2.e26Pos;
                    break;
                case 27:
                    lineUpPoint = EnemyLocationStructs.Wave2.e26Pos;
                    break;
                case 28:
                    lineUpPoint = EnemyLocationStructs.Wave2.e26Pos;
                    break;
                case 29:
                    lineUpPoint = EnemyLocationStructs.Wave2.e26Pos;
                    break;
            }
        }

        else if (SpawnControl.waveNumber == 3)
        {
            switch (GameController.currentEnemies)
            {
                case 1:
                    lineUpPoint = EnemyLocationStructs.Wave3.e1Pos;
                    break;
                case 2:
                    lineUpPoint = EnemyLocationStructs.Wave3.e2Pos;
                    break;
                case 3:
                    lineUpPoint = EnemyLocationStructs.Wave3.e3Pos;
                    break;
                case 4:
                    lineUpPoint = EnemyLocationStructs.Wave3.e4Pos;
                    break;
                case 5:
                    lineUpPoint = EnemyLocationStructs.Wave3.e5Pos;
                    break;
                case 6:
                    lineUpPoint = EnemyLocationStructs.Wave3.e6Pos;
                    break;
                case 7:
                    lineUpPoint = EnemyLocationStructs.Wave3.e7Pos;
                    break;
                case 8:
                    lineUpPoint = EnemyLocationStructs.Wave3.e8Pos;
                    break;
                case 9:
                    lineUpPoint = EnemyLocationStructs.Wave3.e9Pos;
                    break;
                case 10:
                    lineUpPoint = EnemyLocationStructs.Wave3.e10Pos;
                    break;
                case 11:
                    lineUpPoint = EnemyLocationStructs.Wave3.e11Pos;
                    break;
                case 12:
                    lineUpPoint = EnemyLocationStructs.Wave3.e12Pos;
                    break;
                case 13:
                    lineUpPoint = EnemyLocationStructs.Wave3.e13Pos;
                    break;
                case 14:
                    lineUpPoint = EnemyLocationStructs.Wave3.e14Pos;
                    break;
                case 15:
                    lineUpPoint = EnemyLocationStructs.Wave3.e15Pos;
                    break;
                case 16:
                    lineUpPoint = EnemyLocationStructs.Wave3.e16Pos;
                    break;
                case 17:
                    lineUpPoint = EnemyLocationStructs.Wave3.e17Pos;
                    break;
                case 18:
                    lineUpPoint = EnemyLocationStructs.Wave3.e18Pos;
                    break;
                case 19:
                    lineUpPoint = EnemyLocationStructs.Wave3.e19Pos;
                    break;
                case 20:
                    lineUpPoint = EnemyLocationStructs.Wave3.e20Pos;
                    break;
                case 21:
                    lineUpPoint = EnemyLocationStructs.Wave3.e21Pos;
                    break;
                case 22:
                    lineUpPoint = EnemyLocationStructs.Wave3.e22Pos;
                    break;
                case 23:
                    lineUpPoint = EnemyLocationStructs.Wave3.e23Pos;
                    break;
                case 24:
                    lineUpPoint = EnemyLocationStructs.Wave3.e24Pos;
                    break;
                case 25:
                    lineUpPoint = EnemyLocationStructs.Wave3.e25Pos;
                    break;
                case 26:
                    lineUpPoint = EnemyLocationStructs.Wave3.e26Pos;
                    break;
                case 27:
                    lineUpPoint = EnemyLocationStructs.Wave3.e27Pos;
                    break;


            }
        }
        #endregion Enemy Line Up Wave Points
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameEnabled)
        {
            #region Enemy Rotation
            Quaternion o = transform.rotation;
            transform.rotation = o * Quaternion.AngleAxis(10, Vector3.up);
            #endregion Enemy Rotation

            #region Enemy Movement

            moveStep = enemySpeed * Time.deltaTime;

            if (!reachedMiddle)
            {
                transform.position = Vector3.MoveTowards(transform.position, enemyTargetPoints[randomInt].transform.position, moveStep);
            }

            if (transform.position == enemyTargetPoints[0].transform.position || transform.position == enemyTargetPoints[1].transform.position || transform.position == enemyTargetPoints[2].transform.position)
            {
                reachedMiddle = true;
            }

            if (reachedMiddle)
            {
                transform.position = Vector3.MoveTowards(transform.position, lineUpPoint, moveStep);
            }
            #endregion Enemy Movement

            #region Enemy Shooting
            if(Time.time > nextFire)
            {
                if (enemyType == 1)
                {
                    nextFire = Time.time + Random.Range(shot1FireRateMin, shot1FireRateMax);
                    GameObject enemyshot = Instantiate(enemyShot1, enemyShotSpawn.position, Quaternion.Euler(new Vector3(0,0,180)));
                    Destroy(enemyshot, 10f);
                }

                else if (enemyType == 2)
                {
                    nextFire = Time.time + Random.Range(shot2FireRateMin, shot2FireRateMax);
                    GameObject enemyshot = Instantiate(enemyShot2, enemyShotSpawn.position, Quaternion.identity);
                    Destroy(enemyshot, 10);
                }
            }

            #endregion

            #region Enemy PingPong
            //if (SpawnControl.waveNumber == 1  && GameController.currentEnemies == 17)
            //{
            //    transform.position = new Vector3(Mathf.PingPong(Time.time * 2, 1), transform.position.y, transform.position.z);
            //}
            //if (SpawnControl.waveNumber == 2 && GameController.currentEnemies == 29)
            //{
            //    transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
            //}
            //if (SpawnControl.waveNumber == 1 && GameController.currentEnemies == 30)
            //{
            //    transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
            //}
            #endregion Enemy PingPong

        }
    }
}

