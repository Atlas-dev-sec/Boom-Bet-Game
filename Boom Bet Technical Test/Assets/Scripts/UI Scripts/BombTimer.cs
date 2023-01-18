using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BombTimer : MonoBehaviour
{
    //public static BombTimer instance;
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

    public float amount;
    public float coinsWin;
    /*private void Awake()
    {
        instance = this;
    }*/

    void Start()
    {
        amount = PlayerPrefs.GetFloat("q");
        coinsValueText.text = amount.ToString("f1");// get float....
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
        Debug.Log("amount :" + amount);
        //Debug.Log(InitialSupply.initialCoinsSupply);
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
            totalWonCoinsText.text =" +" + coinsWin.ToString()+ " coins..";
            bettedAmount *= currentMultiplierValue; 
            amount += bettedAmount;
            totalWonCoinsText.enabled = true;
            coinsValueText.text = Mathf.Round(amount).ToString("f1");
            PlayerPrefs.SetFloat("q", amount);
            Debug.Log("coins were withdrew and added to count...");
            //Debug.Log("Total coins are: " + GameManager.totalCoinsAmount);   
        }
        // lost condition...
        else 
        {
            totalLostCoinsText.text = " -" + bettedAmount.ToString() + " coins...";
            totalLostCoinsText.enabled = true;
            amount -= bettedAmount;
            coinsValueText.text = Mathf.Round(amount).ToString("f1");
            PlayerPrefs.SetFloat("q", amount);
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
        coinsWin = bettedAmount * currentMultiplierValue;
        // updates and multiply the total coin amount...
        
        return wasWithdrew;
        
    }
}
