using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int CoinAmount;
    public GameObject UpgradeUI;
    public GameObject MenuUI;
    public TMPro.TMP_Text coins_text;
    public TMPro.TMP_Text time_text;
    public float timeElapsed;
    public GameObject GameOverUI;
    public bool Pause = false;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coins_text.text = "Coins : " + CoinAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Pause)
            return;
        timeElapsed += Time.deltaTime;

        int hours = Mathf.FloorToInt(timeElapsed / 3600);
        int minutes = Mathf.FloorToInt((timeElapsed % 3600) / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        string timerText = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
           //Debug.Log("Time elapsed: " + timerText);

        time_text.text = "Time : " + timerText;
    }
    public void getCoins(int coins)
    {
         
         CoinAmount += coins;
         coins_text.text = "Coins : " + CoinAmount.ToString();
    }
    public void OpenUpgradeUI()
    {
        Pause = true;
        UpgradeUI.SetActive(true);
    }
    public void CloseUpgradeUI()
    {
        Pause = false;
        UpgradeUI.SetActive(false);
    }
    public void OpenMenu()  
    {
        Pause = true;
        MenuUI.SetActive(true);
    }  
    public void CloseMenu()  
    {
        Pause = false;
        MenuUI.SetActive(false);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }  
    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void PauseGame()
    {
        Pause = true;
    }
    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
}
