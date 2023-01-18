using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BombTimer : MonoBehaviour
{
    public static BombTimer instance;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI coinsValueText;
    public TextMeshProUGUI totalWonCoinsText;
    public TextMeshProUGUI totalLostCoinsText;
    int bombTimerResult;
    private float startTime;
    private int seconds; 
    public int randomBombTime;
    public ParticleSystem explosionParticle;
    private AudioSource audioSource;
    public AudioClip explostionSound;
    public float multiplierValueIncreasedPerSecond;
    public float multiplierAmount;
    //public static float totalCoinsAmount = 100;
    float timer = 0f;
    public float bettedAmount; 
    private bool wasWithdrew;
    public GameManager gameManager;
    public float currentMultiplierValue;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //totalCoinsAmount = PlayerPrefs.GetFloat("totalCoinsAmount", 100);
        coinsValueText.text = GameManager.totalCoinsAmount.ToString("f1");
        multiplierAmount = 1f;
        multiplierValueIncreasedPerSecond = 0.2f;
        audioSource = GetComponent<AudioSource>();   
        randomBombTime = RandomBombTimer.bombTimerResult;
        multiplierText.text = " X 1";
        bettedAmount = MainMenu.totalBetAmount;
        totalLostCoinsText.enabled = false;
        totalWonCoinsText.enabled = false;

    }

    void Update()
    {
        CountTimer();
        timer += Time.deltaTime;
        CheckTimer();
        ScoreMultiplier();
    }
    // check timer method...
    private void CheckTimer()
    {
        if (timer >= (float)randomBombTime)
        {
            timerText.text = randomBombTime.ToString();
            if (explosionParticle != null)
            {
                gameManager.isGameOver = true;
                UpdateCoinsValue();
                DestroyBomb(); 
            }
            enabled = false;
        }
    }

    public void CountTimer()
    { 
        seconds = (int)timer % 60;
        string secondsString = (seconds).ToString("f1");
        timerText.text = secondsString;
    }
    // starts the multiplier from one second...
    public void ScoreMultiplier()
    {
        if (seconds >= 1)
        {
             multiplierText.text = " X " + multiplierAmount.ToString("f1");
             multiplierAmount += multiplierValueIncreasedPerSecond * Time.deltaTime;
        }
    }

    // destroy bomb method - adds particle effects + explosion sound...
    public void DestroyBomb()
    {
        audioSource.PlayOneShot(explostionSound);
        explosionParticle.Play();
        Destroy(this.gameObject, 0.35f);
    }

    // method that updates the value of the coins, two cases: won and lost + updates the ui for user...
    public void UpdateCoinsValue()
    {
        // win condition...
        if (wasWithdrew)
        {
            coinsValueText.text = Mathf.Round(GameManager.totalCoinsAmount).ToString("f1");
            totalWonCoinsText.text =" +" + (bettedAmount * currentMultiplierValue).ToString()+ " coins..";
            totalWonCoinsText.enabled = true;
            PlayerPrefs.SetFloat("totalCoinsAmount", GameManager.totalCoinsAmount);
            Debug.Log("coins were withdrew and added to count...");
            Debug.Log("Total coins are: " + GameManager.totalCoinsAmount);   
        }
        // lost condition...
        else 
        {
            totalLostCoinsText.text = " -" + bettedAmount.ToString() + " coins...";
            totalLostCoinsText.enabled = true;
            GameManager.totalCoinsAmount -= bettedAmount;
            coinsValueText.text = Mathf.Round(GameManager.totalCoinsAmount).ToString("f1");
            PlayerPrefs.SetFloat("totalCoinsAmount", GameManager.totalCoinsAmount);
        }
        
    }

    // withdraw method makes withdraw to true...
    public bool WithdrawCheckout(bool response)
    {
        wasWithdrew = response;
        // decimal point convertion...
        int decimalPlaces = 1;
        float factor = Mathf.Pow(10.0f, decimalPlaces);
        currentMultiplierValue = Mathf.RoundToInt(multiplierAmount * factor) / factor;
        // updates and multiply the total coin amount...
        GameManager.totalCoinsAmount *= currentMultiplierValue; 
        return wasWithdrew;
        
    }
}
