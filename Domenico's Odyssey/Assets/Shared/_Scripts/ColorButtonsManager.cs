using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using Domenico.Shared.Utilities;

namespace Domenico.Shared
{

	public class ColorButtonsManager : MonoBehaviour
	{
		[SerializeField] private RectTransform canvasRoot;
		[SerializeField] private ButtonsMover buttonsMover;
		public ScriptableColor buttonsColor;
		
		[SerializeField] private List<ColorButton> buttons;
		[SerializeField] private ColorPalette palette;
		[SerializeField] private ScriptableKeys keys;

		[SerializeField] private int numberOfButtons;
		[SerializeField] private ColorButton colorButtonPrefab;
		[SerializeField] private RectTransform placeholderPrefab;

		[SerializeField] [ReadOnly] private List<KeyCode> availableKeys;
		[SerializeField] [ReadOnly] private List<ScriptableColor> availableColors;


		public static event Action<ScriptableColor> OnButtonsColorChanged;

		[PropertySpace(30)]
		[Button]
		public void SpawnButtons(int amount)
		{
			RandomizeColor();
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


		[Button]
		public void RandomizeColor()
		{
			buttonsColor = palette.Palette[Random.Range(0, palette.Palette.Count)];
			OnButtonsColorChanged?.Invoke(buttonsColor);
		}

		private void Start()
		{
			availableKeys =  new List<KeyCode>(keys.Keys);
			availableColors = new List<ScriptableColor>(palette.Palette);
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
			button.SetButton(buttonColor, buttonKeyCode,buttonsColor);
			button.gameObject.name = $"Button-{randomKey.ToString().Replace("Alpha", "")}-{randomColor.ColorName}";
			
		}
		
		public void SetupButton(ColorButton button)
		{
			if (availableColors.Count <= 0 || availableKeys.Count <= 0) return;
			if (button==null)return;

			var randomColor = availableColors[Random.Range(0, availableColors.Count)];
			ScriptableColor buttonColor = randomColor;
			availableColors.Remove(buttonColor);
			var randomKey = availableKeys[Random.Range(0, availableKeys.Count)];
			KeyCode buttonKeyCode = randomKey;
			availableKeys.Remove(buttonKeyCode);
			button.SetButton(buttonColor, buttonKeyCode,buttonsColor);
			button.gameObject.name = $"Button-{randomKey.ToString().Replace("Alpha", "")}-{randomColor.ColorName}";
			
		}
		

		[Button]
		public void SetupAllButtons()
		{
			
			foreach (ColorButton button in buttons)
			{
				if (availableColors.Count <= 0 || availableKeys.Count <= 0)
				{
					button.gameObject.name = "Button-NO KEY-NO COLOR";
					button.SetButton(buttonsColor);
					continue;
				}
				var randomColor = availableColors[Random.Range(0, availableColors.Count)];
				ScriptableColor buttonColor = randomColor;
				availableColors.Remove(buttonColor);
				
				var randomKey = availableKeys[Random.Range(0, availableKeys.Count)];
				KeyCode buttonKeyCode = randomKey;
				availableKeys.Remove(buttonKeyCode);
				
				button.SetButton(buttonColor, buttonKeyCode,buttonsColor);
				
			}
		}

		[Button]
		public void UpdateAvailableness()
		{
			availableKeys =  new List<KeyCode>(keys.Keys);
			availableColors = new List<ScriptableColor>(palette.Palette);
		}
		
		
		[Button]
		public void SwapButtons(int index1, int index2)
		{
			buttons.RemoveNulls();
			if ((index1 < 0 || index1 >= buttons.Count) || (index2 < 0 || index2 >= buttons.Count)) return;
			
			buttonsMover.SwapButtons(buttons[index1],buttons[index2]);
			buttons.Swap(index1, index2);
		}
		
		public void SwapButtons()
		{
			buttons.RemoveNulls();


			SwapButtons(0,2);
			buttons.Swap(0,2);
		}

		public void KickOutFirstButton()
		{
			buttons.TrimExcess();

			buttonsMover.KickOutButton(buttons[0]);
		}

		public void AddButtonToEnd()
		{
			buttons.RemoveNulls();

			var placeholder = Instantiate(placeholderPrefab.gameObject, transform);
			var newButton = Instantiate(colorButtonPrefab,buttonsMover.OutOfScreenEnterPoint.position,quaternion.identity,canvasRoot);
			newButton.name = "entering Button";
			buttons.Add(newButton);
			SetupButton(newButton);
			buttonsMover.MakeButtonEntrance(transform,placeholder.gameObject,newButton);
		}
	}

}