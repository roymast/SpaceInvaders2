using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrateManager : MonoBehaviour
{
    public static bool IsVibrateOn;
    public static VibrateManager Instance;
    [SerializeField] Image VibrateImg;
    [SerializeField] Sprite VibrateOnSprite;
    [SerializeField] Sprite VibrateOffSprite;
    private void Awake()
    {
        Instance = this;
        VibrateImg.sprite = IsVibrateOn ? VibrateOnSprite : VibrateOffSprite;
    }
    public void SetVibrateOnOff()
    {
        IsVibrateOn = !IsVibrateOn;
        VibrateImg.sprite = IsVibrateOn ? VibrateOnSprite : VibrateOffSprite;
    }
    public void Vibrate()
    {
        if(IsVibrateOn)
            Handheld.Vibrate();
    }
}
