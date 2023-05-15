using System;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ButtonManager : MonoBehaviour
{
   public List<ButtonData> buttons = new List<ButtonData>();
   public ColorDB db;
   private List<int> indexColors = new List<int>();
   [SerializeField] Vector2 timerSwap = new Vector2(3,5);
   private float currentTimer;
   private float currentTimerSwap;
   
    private void Start()
    {
        //buttons = FindObjectsOfType<ButtonData>().ToList();
        for (int i = 0; i < db.colors.Count; i++) {
            indexColors.Add(i);
        }
        for (int i = 0; i < buttons.Count; i++) {
            var index = indexColors[Random.Range(0, indexColors.Count)];
            var color = db.colors[index];
            buttons[i].Init(color,i);
            indexColors.Remove(index);
        }
        currentTimerSwap = Random.Range(timerSwap.x, timerSwap.y);

    }

    private void Update() {
        currentTimer += Time.deltaTime;
        if (currentTimer > currentTimerSwap) {
            currentTimer = 0;
            currentTimerSwap = Random.Range(timerSwap.x, timerSwap.y);
            TrySwap();
        }
    }

    private void TrySwap() {
        var tmpButtons = new List<ButtonData>();
        tmpButtons.AddRange(buttons);
        var b1 = tmpButtons[Random.Range(0, tmpButtons.Count)];
        tmpButtons.Remove(b1);
        var b2 = tmpButtons[Random.Range(0, tmpButtons.Count)];
        tmpButtons.Remove(b2);
        SwapButton(b1,b2);
    }

    [Button("ChangeAllColor")]
    public void ChangeAllColor()
    {
        for(int i=0; i < db.colors.Count; i++)
        {
            db.colors[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);

        }
    }
    [Button("Swap pos")]
    public void SwapButton(ButtonData button, ButtonData button2)
    {
        Vector3 tmp = button.gameObject.transform.position;
        button.gameObject.transform.position = button2.gameObject.transform.position;
        button2.gameObject.transform.position = tmp;  
    }
    [Button("swap colore")]
    public void SwapColor(ButtonData button, ButtonData button2)
    {
        Color tmp = button.col;
        button.col=button2.col;
        button2.col=tmp;
    }

    public void ThrowOut()
    {

    }
    
    
}
