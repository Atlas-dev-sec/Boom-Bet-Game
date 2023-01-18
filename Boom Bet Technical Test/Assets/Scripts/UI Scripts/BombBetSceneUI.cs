using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class BombBetSceneUI : MonoBehaviour
{
    private GameObject bombtimerScript;
    public Button withDrawButton;

    void Start()
    {
        bombtimerScript = GameObject.Find("Bomb");
        withDrawButton.enabled = true;
    }
    public void OnWithdrawBet()
    {
        bombtimerScript.GetComponent<BombTimer>().WithdrawCheckout(true);
        withDrawButton.enabled = false;

    }
}
