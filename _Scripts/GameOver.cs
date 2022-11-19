using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameOver += Instance_OnGameOver;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= Instance_OnGameOver;
    }
    private void Instance_OnGameOver()
    {
        if(GameManager.Instance.enemysLeft <= 0)
        {
            WinScreen.SetActive(true);
            LoseScreen.SetActive(false);
        }
        else
        {
            WinScreen.SetActive(false);
            LoseScreen.SetActive(true);
        }
    }    
}
