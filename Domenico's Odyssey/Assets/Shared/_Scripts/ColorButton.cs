using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domenico.Shared
{

    public class ColorButton : MonoBehaviour
    {
        [SerializeField] private ScriptableColor currentButtonColor;
        [SerializeField] private KeyCode currentButtonKey;
        [SerializeField] private Image buttonImage;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private Button button;
        public RectTransform rectTransform;
        
        public Action<ScriptableColor> onButtonClicked;

        private void OnEnable()
        {
            ColorButtonsManager.OnButtonsColorChanged += UpdateColor;
        }

        private void OnDisable()
        {
            ColorButtonsManager.OnButtonsColorChanged += UpdateColor;
        }

        public void SetButton(ScriptableColor scriptableColor, KeyCode keyCode, ScriptableColor fakeColor)
        {
            button.interactable = true;
            currentButtonColor = scriptableColor;
            currentButtonKey = keyCode;
            buttonImage.color = fakeColor.Color;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(()=>ButtonClicked(scriptableColor));
            buttonText.text = keyCode.ToString().Replace("Alpha","");
            gameObject.name = $"Button-{keyCode.ToString().Replace("Alpha", "")}-{fakeColor.ColorName}";
        }

        public void UpdateColor(ScriptableColor fakeColor)
        {
            buttonImage.color = fakeColor.Color;
        }
        public void SetButton(ScriptableColor fakeColor)
        {
            currentButtonKey = KeyCode.None;
            buttonImage.color = fakeColor.Color;
            buttonText.text = "X";
            button.interactable = false;
        }

        private void ButtonClicked(ScriptableColor color)
        {
            onButtonClicked.Invoke(color);
            Debug.Log($"CLICKED ON BUTTON {gameObject.name}");
        }

    }

}
