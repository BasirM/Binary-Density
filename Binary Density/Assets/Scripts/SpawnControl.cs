using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemyBoss;
    [SerializeField] Transform[] enemySpawnPoints;
    private bool spawnEnabled;
    public static int waveNumber;
    public static bool wave2Called, wave3Called;
    private bool isSpawning;

    int randomInt;
    System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnabled = false;
        random = new System.Random();

        wave2Called = false;
        wave3Called = false;

        StartCoroutine(DelayedStart());
    }

    // Update is called once per frame
    void Update()
    {
        randomInt = random.Next(0, enemySpawnPoints.Length);

        #region Enemy Wave Invokes
        if (GameController.enemiesDefeated == 17)
        {
            if (!wave2Called)
            {
                wave2Called = true;
                Invoke("Wave2", 2);
            }
        }

        if(GameController.enemiesDefeated == 40)
        {
            if (!wave3Called)
            {
                wave3Called = true;
                Invoke("Wave3", 2);
            }
        }

        if(GameController.enemiesDefeated == 74)
        {
            Debug.Log("ghgh");
            GameController.level1Done = true;
        }
        #endregion 
    }

    #region Wave Functions
    public void Wave1()//17
    {
        waveNumber = 1;
        GameController.currentEnemies = 0;
        StartCoroutine(SpawnEnemies(enemy1, 8, .5f));
        StartCoroutine(SpawnEnemies(enemy2, 7, .8f));
    }

    public void Wave2()//29
    {
        waveNumber = 2;
        GameController.currentEnemies = 0;
        StartCoroutine(SpawnEnemies(enemy1, 10, .7f));
        StartCoroutine(SpawnEnemies(enemy1, 10, .6f));
        StartCoroutine(SpawnEnemies(enemy2, 6, .3f));
    }

    public void Wave3()//29
    {
        waveNumber = 3;
        GameController.currentEnemies = 0;
        StartCoroutine(SpawnEnemies(enemy1, 6, 2f));
        StartCoroutine(SpawnEnemies(enemy2, 4, 3f));
        StartCoroutine(SpawnEnemies(enemy1, 6, 2f));
        StartCoroutine(SpawnEnemies(enemy2, 5, 4f));
        StartCoroutine(SpawnEnemies(enemy1, 6, 5f));
    }
    #endregion Wave Functions

    #region Courotines
    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3);

        if (GameController.sceneName == "Level 1")
        {
            spawnEnabled = true;
            Wave1();
        }

        if (GameController.sceneName == "Level 2")
        {
            GameObject boss = Instantiate(enemyBoss, enemySpawnPoints[2].position, Quaternion.identity);
        }
    }
    public IEnumerator SpawnEnemies(GameObject enemyType, int howMany, float spawnGap)
    {
        isSpawning = true;

        for (int i = 0; i <= howMany; i++)
        {
            if (enemyType == enemy1)
            {
                GameObject enemy1Copy = Instantiate(enemy1, enemySpawnPoints[randomInt].position, Quaternion.identity) as GameObject;
            }

            if (enemyType == enemy2)
            {
                GameObject enemy2Copy = Instantiate(enemy2, enemySpawnPoints[randomInt].position, Quaternion.identity) as GameObject;
            }
            yield return new WaitForSeconds(spawnGap);
        }
        isSpawning = false;
    }
    #endregion Corutines

}
