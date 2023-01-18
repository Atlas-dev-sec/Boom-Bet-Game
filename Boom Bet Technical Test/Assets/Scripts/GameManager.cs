using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;
    public static float totalCoinsAmount;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        totalCoinsAmount = 100;
        totalCoinsAmount = PlayerPrefs.GetFloat("totalCoinsAmount", 100);
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
