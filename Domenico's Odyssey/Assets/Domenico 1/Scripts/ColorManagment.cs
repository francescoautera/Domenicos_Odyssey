using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManagment : MonoBehaviour {

	public ButtonManager buttonManager;
	public Color primaryColor;
	public Color textColor;
	public ColorDB colorDB;
	public string primaryString;
	 public TMPro.TMP_Text colorText;

    [Button("setColor")]
    public void SetColor() {
		var index = Random.Range(0, buttonManager.buttons.Count);
        var index2 = Random.Range(0, buttonManager.buttons.Count);
        while (index==index2)
        {
        index2 = Random.Range(0, buttonManager.buttons.Count);
        }
        primaryColor = buttonManager.buttons[index].col;
		primaryString = colorDB.GetString(primaryColor);
		textColor = buttonManager.buttons[index2].col;
        colorText.text = $"Tappa il colore <color=#{ColorUtility.ToHtmlStringRGBA(textColor)}>{primaryString}</color>";

    }
   
	
	
	
	


}
