using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Domenico.Shared
{

	public class ColorButtonsManager : MonoBehaviour
	{
		[SerializeField] private List<ColorButton> buttons;
		[SerializeField] private ColorPalette palette;
		[SerializeField] private ScriptableKeys keys;

		[SerializeField] private int numberOfButtons;
		[SerializeField] private ColorButton colorButtonPrefab;

		[SerializeField] [ReadOnly] private List<KeyCode> availableKeys;
		[SerializeField] [ReadOnly] private List<ScriptableColor> availableColors;

		[PropertySpace(30)]
		[Button]
		public void SpawnButtons(int amount)
		{
			if (transform.childCount != 0)
			{
				for (int i = transform.childCount - 1; i >= 0; i--)
				{
					DestroyImmediate(transform.GetChild(i).gameObject);
				}
			}

			buttons = new List<ColorButton>();
			for (int i = 0; i < amount; i++)
			{
				var newButton = Instantiate(colorButtonPrefab, transform);
				buttons.Add(newButton);
			}

			SetupAllButtons();
		}

		private void Start()
		{
			SpawnButtons(numberOfButtons);
		}

		[Button]
		public void SetupButton(int index)
		{
			if (index < 0 || index >= buttons.Count) return;
			if (availableColors.Count <= 0 || availableKeys.Count <= 0) return;

			var button = buttons[index];
			var randomColor = availableColors[Random.Range(0, availableColors.Count)];
			ScriptableColor buttonColor = randomColor;
			availableColors.Remove(buttonColor);
			var randomKey = availableKeys[Random.Range(0, availableKeys.Count)];
			KeyCode buttonKeyCode = randomKey;
			availableKeys.Remove(buttonKeyCode);
			button.SetButton(buttonColor, buttonKeyCode,randomColor);
			button.gameObject.name = $"Button-{randomKey.ToString().Replace("Alpha", "")}-{randomColor.ColorName}";
			
		}

		public void SetupButtons(List<int> indexes)
		{
			var fakeColor = availableColors[Random.Range(0, availableColors.Count)];
			
			foreach (int index in indexes)
			{
				if (index < 0 || index >= buttons.Count) continue;
				if (availableColors.Count <= 0 || availableKeys.Count <= 0) continue;

				var button = buttons[index];
				var randomColor = availableColors[Random.Range(0, availableColors.Count)];
				ScriptableColor buttonColor = randomColor;
				availableColors.Remove(buttonColor);
				var randomKey = availableKeys[Random.Range(0, availableKeys.Count)];
				KeyCode buttonKeyCode = randomKey;
				availableKeys.Remove(buttonKeyCode);
				button.SetButton(buttonColor, buttonKeyCode,fakeColor);
				button.gameObject.name = $"Button-{randomKey.ToString().Replace("Alpha", "")}-{randomColor.ColorName}";
			}
		}

		[Button]
		public void SwapButtons(int index1, int index2)
		{
			if ((index1 < 0 || index1 >= buttons.Count) || (index2 < 0 || index2 >= buttons.Count)) return;

			(buttons[index1].rectTransform.position, buttons[index2].rectTransform.position) = (buttons[index2].rectTransform.position, buttons[index1].rectTransform.position);
		}

		[Button]
		public void SetupAllButtons()
		{
			availableKeys =  new List<KeyCode>(keys.Keys);
			availableColors = new List<ScriptableColor>(palette.Palette);
			var fakeColor=availableColors[Random.Range(0, availableColors.Count)];
			foreach (ColorButton button in buttons)
			{
				if (availableColors.Count <= 0 || availableKeys.Count <= 0)
				{
					button.gameObject.name = "Button-NO KEY-NO COLOR";
					button.SetButton(fakeColor);
					continue;
				}
				var randomColor = availableColors[Random.Range(0, availableColors.Count)];
				ScriptableColor buttonColor = randomColor;
				availableColors.Remove(buttonColor);
				var randomKey = availableKeys[Random.Range(0, availableKeys.Count)];
				KeyCode buttonKeyCode = randomKey;
				availableKeys.Remove(buttonKeyCode);
				button.SetButton(buttonColor, buttonKeyCode,fakeColor);
				button.gameObject.name = $"Button-{randomKey.ToString().Replace("Alpha", "")}-{fakeColor.ColorName}";
			}
		}
	}

}