using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Image fadeOutUIImage;
    [SerializeField] float fadeSpeed = 0.8f;
    public static bool gameEnabled;
    public static bool playerDead;

    [SerializeField] GameObject binaryShifterButton;
    public static bool binaryShifterActive;
    public static bool binaryShifterCharging;
    [SerializeField] float bSActiveTime;
    [SerializeField] float bSRechargeTime;
    [SerializeField] GameObject redCircle;

    TextMeshProUGUI binaryShifterText, scoreText, endGameScoreText, playerDeadScoreText;

    public static int score;
    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject endGameScore;
    [SerializeField] GameObject playerDeadScore;

    public static int currentEnemies;
    public static int enemiesDefeated;

    [SerializeField] GameObject laserPickup, cannonPickup, rocketPickup;
    public static List<GameObject> pickups;

    Scene currentScene;
    public static string sceneName;

    public static bool level1Done;
    public static bool level2Done;
    [SerializeField] GameObject endLevelPanel;
    [SerializeField] GameObject playerDeadPanel;
    [SerializeField] GameObject pausePanel;

    private bool isPaused;

    public enum FadeDirection
    {
        In, //Alpha = 1
        Out //Alpha = 0
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        playerDead = false;
        enemiesDefeated = 0;

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName != "Main Menu")
        {
            binaryShifterText = binaryShifterButton.GetComponentInChildren<TextMeshProUGUI>();
            scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            endGameScoreText = endGameScore.GetComponent<TextMeshProUGUI>();
            playerDeadScoreText = playerDeadScore.GetComponent<TextMeshProUGUI>();
            endLevelPanel.SetActive(false);
            

            redCircle.SetActive(false);

            pickups = new List<GameObject>();
            pickups.Add(laserPickup);
            pickups.Add(cannonPickup);
            pickups.Add(rocketPickup);
        }

        StartCoroutine(Fade(FadeDirection.Out));
        StartCoroutine(DelayedStart());
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneName != "Main Menu")
        {
            scoreText.SetText("" + score.ToString("00000"));
            endGameScoreText.SetText("Score: " + score.ToString("00000"));
            playerDeadScoreText.SetText("Score: " + score.ToString("00000"));

            #region Binary Shifter UI

            if (!binaryShifterActive && !binaryShifterCharging)
            {
                binaryShifterText.SetText("BS");
            }


                //if binary shifter is in active state
                if (binaryShifterActive && bSActiveTime > 0)
                {
                    binaryShifterActive = true;
                    bSActiveTime -= Time.deltaTime;
                    binaryShifterText.SetText(Mathf.RoundToInt(bSActiveTime).ToString());
                }
                if (bSActiveTime <= 0)
                {
                    bSActiveTime = 0;
                    binaryShifterText.SetText(Mathf.RoundToInt(bSActiveTime).ToString());
                    binaryShifterActive = false;
                    binaryShifterCharging = true;
                    redCircle.SetActive(true);
                }

                //if binary shifter is in charging state
                if (binaryShifterCharging && bSRechargeTime > 0)
                {
                    binaryShifterCharging = true;
                    bSRechargeTime -= Time.deltaTime;
                    binaryShifterText.SetText(Mathf.RoundToInt(bSRechargeTime).ToString());
                }
                if (bSRechargeTime <= 0)
                {
                    bSRechargeTime = 0;
                    binaryShifterText.SetText(Mathf.RoundToInt(bSRechargeTime).ToString());
                    binaryShifterCharging = false;
                    redCircle.SetActive(false);
                }

                //once recharging is done, reset timers
                if (bSActiveTime == 0 && bSRechargeTime == 0)
                {
                    bSActiveTime = 5;
                    bSRechargeTime = 8;
                }
                #endregion 

                if (playerDead)
                {
                    gameEnabled = false;
                    ActivatePanel(playerDeadPanel);
                }
                if (level1Done && sceneName == "Level1")
                {
                    gameEnabled = false;
                    ActivatePanel(endLevelPanel);
                }

                if (level2Done)
                {
                    gameEnabled = false;
                    ActivatePanel(endLevelPanel);
                }
        }
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(FadeAndLoadScene(FadeDirection.In, levelName));

        enemiesDefeated = 0;
        SpawnControl.wave2Called = false;
        SpawnControl.wave3Called = false;
        SpawnControl.waveNumber = 0;

        binaryShifterActive = false;
        binaryShifterCharging = false;
        bSActiveTime = 5;
        bSRechargeTime = 8;

    }

    public void ActivatePanel(GameObject menupanel)
    {
        menupanel.SetActive(true);
    }

    public void DeactivatePanel(GameObject menupanel)
    {
        menupanel.SetActive(false);
    }

    public void Pause()
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
            gameEnabled = true;
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            pausePanel.SetActive(true);
            gameEnabled = false;
            Time.timeScale = 0;
            isPaused = true;
        }
    }


    public void BinaryShifter()
    {
        if (binaryShifterCharging == false)
        {
            binaryShifterActive = true;
        }
    }

    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }

    #region FADE HELPERS
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad)
    {
        yield return Fade(fadeDirection);
        SceneManager.LoadScene(sceneToLoad);
    }
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
    #endregion

    #region Coroutines
    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3);
        gameEnabled = true;
    }
    #endregion Coroutines




}

