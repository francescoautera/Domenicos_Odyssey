using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
   
   public Image fade;
   public Button buttonStartGame;
   public float waitChangeScene;
   public float fadeTimer;
   private AudioSource source;
   
   private void Awake() {
      source = GetComponent<AudioSource>();
      fade.CrossFadeAlpha(0,fadeTimer,false);
      buttonStartGame.onClick.AddListener(StartGame);
   }


   private void StartGame() {
      fade.CrossFadeAlpha(1,fadeTimer,false);
      StartCoroutine(WaitBeforeChangeScene());

   }

   IEnumerator WaitBeforeChangeScene() {
      source.Play();
      yield return new WaitForSeconds(waitChangeScene);
      SceneManager.LoadScene("_Main");
   }
   
   
}


