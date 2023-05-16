using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManagment : MonoBehaviour {

	public ButtonManager buttonManager;
	public Color primaryColor;
	public Color textColor;
	public ColorDB colorDB;
	public string primaryString;


	public void SetColor() {
		var index = Random.Range(0, buttonManager.buttons.Count);
		var index2 = Random.Range(0, buttonManager.buttons.Count);
		primaryColor = buttonManager.buttons[index].col;
		primaryString = colorDB.GetString(primaryColor);
		textColor = buttonManager.buttons[index2].col;
	}
	
	
	
	
	
	
	


}
