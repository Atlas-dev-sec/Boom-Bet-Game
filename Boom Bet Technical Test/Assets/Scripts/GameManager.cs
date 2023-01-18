using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public static float totalCoinsAmount;
  
    // Start is called before the first frame update
    void Start()
    {
        //totalCoinsAmount += initialCoinsSupply;
        //totalCoinsAmount += initialCoinsSupply;
        //coinsValueText.text = PlayerPrefs.GetFloat("initialCoinsSupply").ToString("f1");
        //totalCoinsAmount = PlayerPrefs.GetFloat("initialCoinsSupply", 550);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
      // if game over  equals true start coroutine...
      if (isGameOver)
      {
        StartCoroutine(LoadMainMenuSceneCoroutine());
      }  
    }

    IEnumerator LoadMainMenuSceneCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }
}
