using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitialSupply : MonoBehaviour
{
    public static InitialSupply instance;
    public TextMeshProUGUI coinsValueText;
    public static float q = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;  
    }
    void Start()
    {
        //totalCoinsAmount += initialCoinsSupply;
        //initialCoinsSupply = 550;
        
        //totalCoinsAmount += zialCoinsSupply;
        //coinsValueText.text = PlayerPrefs.GetFloat("zialCoinsSupply").ToString("f1");
        q = PlayerPrefs.GetFloat("q");
    }

    void Update()
    {
        //Debug.Log(zialCoinsSupplyyy);
        if (q == 0)
        {
            
            //PlayerPrefs.SetFloat("ini", 1993);
            //z = 250;
            //coinsValueText.text = PlayerPrefs.GetFloat("ini").ToString("f1");
            coinsValueText.text = 250.ToString();
        }
        if(q != 0)
        {
            coinsValueText.text = PlayerPrefs.GetFloat("q").ToString("f1");
            //coinsValueText.text = ini.ToString("f1");
        }
        
    }
}
