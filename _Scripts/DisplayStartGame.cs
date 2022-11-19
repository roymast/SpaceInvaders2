using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DisplayStartGame : MonoBehaviour
{
    GameManager GameManager;

    public TextMeshProUGUI counterText;

    public event Action OnCountDownOver;    
    public void StartCountingBack()
    {
        StartCoroutine(CountingBack());
    }    
    IEnumerator CountingBack()
    {
        int count = 3;                
        while(count>0)
        {
            counterText.text = count--.ToString();
            yield return new WaitForSeconds(1);
        }
        counterText.text = "Start";
        yield return new WaitForSeconds(1);
        counterText.gameObject.SetActive(false);
        OnCountDownOver?.Invoke();
    }
}
