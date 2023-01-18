using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    public InputField userInput;
    public TextMeshProUGUI coinsValueText;
    public static float totalBetAmount = 0;
    private float coinsAmount;
    void Start()
    {
        //coinsValueText.text = PlayerPrefs.GetFloat("initialCoinsSupply").ToString("f1");
        coinsAmount = PlayerPrefs.GetFloat("q");
        //
        userInput.onEndEdit.AddListener(SubmitBet);
    }

    void Update()
    {
        //Debug.Log(GameManager.initialCoinsSupply);
        Debug.Log("Coin amot: "+ coinsAmount);
    }


    private void SubmitBet(string arg0)
    {
        totalBetAmount = float.Parse(arg0);

        if(coinsAmount == 0)
        {
            PlayerPrefs.SetFloat("q", 250);
            Debug.Log(totalBetAmount);

            userInput.text = "";
            userInput.placeholder.GetComponent<Text>().text = "Betting in process Good Luck...";
            SceneManager.LoadScene("BombBetScene");
        }
        if(totalBetAmount <= coinsAmount)
        {
            Debug.Log(totalBetAmount);
            userInput.text = "";
            userInput.placeholder.GetComponent<Text>().text = "Betting in process Good Luck...";
            SceneManager.LoadScene("BombBetScene");
        }else
        {
            userInput.text = "";
            userInput.placeholder.GetComponent<Text>().text = "Not enough funds...";
        }
        
    }
}
