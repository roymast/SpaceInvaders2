using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public static bool IsPlayingBackGround;
    public static bool IsPlayingVFX;

    [SerializeField] AudioSource soundTrack;
    [SerializeField] AudioSource shootSound;
    [SerializeField] AudioSource invaderKillSound;

    [SerializeField] Image BGMusicImg;
    [SerializeField] Sprite BGMusicOn;
    [SerializeField] Sprite BGMusicOff;

    [SerializeField] Image VRFImg;
    [SerializeField] Sprite VRFOn;
    [SerializeField] Sprite VRFOff;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!IsPlayingBackGround)
            soundTrack.Stop();
        else
            soundTrack.Play();
        BGMusicImg.sprite = IsPlayingBackGround ? BGMusicOn : BGMusicOff;
        VRFImg.sprite = IsPlayingVFX ? VRFOn : VRFOff;

        EnemyDamageable.EnemyDestroyed += PlayKillInvader;
    }

    public void PlayAndStopSoundTrack()
    {
        IsPlayingBackGround = !IsPlayingBackGround;
        BGMusicImg.sprite = IsPlayingBackGround ? BGMusicOn : BGMusicOff;
        if (IsPlayingBackGround)
            soundTrack.Play();
        else
            soundTrack.Stop();
    }
    public void PlayAndStopVRF()
    {
        IsPlayingVFX = !IsPlayingVFX;
        VRFImg.sprite = IsPlayingVFX ? VRFOn : VRFOff;
        shootSound.gameObject.SetActive(IsPlayingVFX);        
    }

    public void PlayShot()
    {
        if (IsPlayingVFX)
            shootSound.Play();
    }    
    public void PlayKillInvader(Enemy enemy)
    {
        if (IsPlayingVFX)
            invaderKillSound.Play();
    }
}
