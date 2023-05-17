using System;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterController = Domenico1.CharacterController;
using Random = UnityEngine.Random;

public class ColorManagment : MonoBehaviour {

	public ButtonManager buttonManager;
	public Color primaryColor;
	public Color textColor;
	public ColorDB colorDB;
	public string primaryString;
	 public TMPro.TMP_Text colorText;
	 private CharacterController characterController;
	 
	 private void Awake() {
		 colorText.enabled = false;
		 characterController = FindObjectOfType<CharacterController>();
		 characterController.OnPlayerWin += CloseText;
	 }

	 [Button("setColor")]
    public void SetColor() {
		var index = Random.Range(0, buttonManager.CurrentButtonsInUi.Count);
        var index2 = Random.Range(0, buttonManager.CurrentButtonsInUi.Count);
        while (index==index2)
        {
			index2 = Random.Range(0, buttonManager.CurrentButtonsInUi.Count);
        }
        primaryColor = buttonManager.CurrentButtonsInUi[index].col;
		primaryString = colorDB.GetString(primaryColor);
		textColor = buttonManager.CurrentButtonsInUi[index2].col;
		colorText.enabled = true;
        colorText.text = $"Cambia nel colore <color=#{ColorUtility.ToHtmlStringRGBA(textColor)}>{primaryString}</color>";

    }


    private void CloseText() {
	    colorText.enabled = false;
    }




}
