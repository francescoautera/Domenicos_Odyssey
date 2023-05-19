using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CharacterController = Domenico1.CharacterController;

public class SoundsManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioSource sfxAudioSource;
    public AudioClip backgroundSong;
    public AudioClip loseSong;
    public AudioClip buttonPressedClip;
    public AudioClip switchColorsClip;
    public AudioClip switchButtonsClip;
    public AudioClip quitButtonClip;
    public AudioClip loseGameClip;
    public AudioClip speedUpClip;
    private CharacterController characterController;
    public float timerModifyVolume;
    

    private void Awake() {

        characterController = FindObjectOfType<CharacterController>();
        characterController.OnPlayerDeath += ChangeSong;
        characterController.OnPlaySfxRequested += ButtonPressedSound;
    }
    
    
    public void ButtonPressedSound() {
        sfxAudioSource.clip = buttonPressedClip;
        sfxAudioSource.PlayOneShot(buttonPressedClip);
    }

    public void SwitchColorSound()
    {
        sfxAudioSource.clip = switchColorsClip;
        sfxAudioSource.PlayOneShot(switchColorsClip);
    }
    
    public void SwitchButtonSound()
    {
        sfxAudioSource.clip = switchButtonsClip;
        sfxAudioSource.PlayOneShot(switchButtonsClip);
    }
    
    public void QuitButtonSound()
    {
        sfxAudioSource.clip = quitButtonClip;
        sfxAudioSource.PlayOneShot(quitButtonClip);
    }

    public void LoseGameSound()
    {
        sfxAudioSource.clip = loseGameClip;
        sfxAudioSource.PlayOneShot(loseGameClip);
    }

    public void SpeedUpSound()
    {
        sfxAudioSource.clip = speedUpClip;
        sfxAudioSource.PlayOneShot(speedUpClip);
    }


    private void ChangeSong() {
        StartCoroutine(FadeOutFadeInSong());
    }

    IEnumerator FadeOutFadeInSong() {
        float t = 0;
        float initVolume = audioSource.volume;
        while (t < timerModifyVolume) {
            audioSource.volume = Mathf.Lerp(initVolume,0,t/timerModifyVolume);
            t += Time.deltaTime;
            yield return null;
        }
        audioSource.clip = loseSong;
        audioSource.volume = 0;
        audioSource.Play();
        t = 0;
        yield return new WaitForSeconds(0.2f);
        while (t < timerModifyVolume) {
            audioSource.volume = Mathf.Lerp(0,initVolume,t/timerModifyVolume);
            t += Time.deltaTime;
            yield return null;
        }
    }

}