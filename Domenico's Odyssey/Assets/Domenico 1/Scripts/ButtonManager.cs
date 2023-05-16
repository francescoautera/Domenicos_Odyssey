using System;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
using DG.Tweening;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
   public List<ButtonData> buttons = new List<ButtonData>();
   public ColorDB db;
   private List<int> indexColors = new List<int>();
   [FormerlySerializedAs("timerSwap")] [SerializeField] Vector2 timerEvent = new Vector2(3,5);
   private float currentTimer;
   private float currentTimerSwap;
   [SerializeField] private GameObject feedbackChangeColor;
    public bool somethingIsSwapping=false;
    [Header("Animation")]
    public float yMovement;
    public float yTime;
    public float xTime;
   
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
        currentTimerSwap = Random.Range(timerEvent.x, timerEvent.y);

    }

    private void Update() {
     
        currentTimer += Time.deltaTime;
        if (currentTimer > currentTimerSwap) {
            currentTimer = 0;
            currentTimerSwap = Random.Range(timerEvent.x, timerEvent.y);
            var x =Random.Range(0, 2);
            Debug.Log(x);
            if (x == 0&&!somethingIsSwapping) {
                TrySwap();
                return;
            }
            ChangeAllColor();
            
        }
        
    }

    private void TrySwap() {
        somethingIsSwapping = true;
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
        Debug.Log("enter");
        feedbackChangeColor.SetActive(true);
        
        for(int i=0; i < db.colors.Count; i++)
        { 
            
            db.colors[i] = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);

        }
    }

    public IEnumerator Anim(ButtonData button, ButtonData button2)
    {
        button.gameObject.transform.DOMoveY(button.gameObject.transform.position.y + yMovement, yTime);
        button2.gameObject.transform.DOMoveY(button2.gameObject.transform.position.y + yMovement, yTime);
        yield return new WaitForSeconds(yTime);
        button.gameObject.transform.DOMoveX(button2.gameObject.transform.position.x, xTime);
        button2.gameObject.transform.DOMoveX(button.gameObject.transform.position.x, xTime);
        yield return new WaitForSeconds(xTime);
            
        button.gameObject.transform.DOMoveY(button.gameObject.transform.position.y - yMovement, yTime);
        button2.gameObject.transform.DOMoveY(button2.gameObject.transform.position.y - yMovement, yTime);
        yield return new WaitForSeconds(0.9f);
        somethingIsSwapping=false;
    }

    public IEnumerator AnimThrowOut(ButtonData button, ButtonData button2)
    {
        ButtonData inButton;
        ButtonData outButton;
        float y;
        if (button.isIn) {
        inButton= button;
        outButton= button2;
            y = inButton.transform.position.y;
        }
        else
        {
        inButton= button2;
        outButton= button;
            y = inButton.transform.position.y;

        }
        outButton.gameObject.transform.DOMoveX(inButton.gameObject.transform.position.x , xTime);
        inButton.gameObject.transform.DOMoveY(outButton.gameObject.transform.position.y , yTime);
        yield return new WaitForSeconds(xTime);
        outButton.gameObject.transform.DOMoveY(y, yTime);
        outButton.isIn = true;
        inButton.isIn = false;
        yield return new WaitForSeconds(0.9f);

        somethingIsSwapping = false;


    }
    [Button("Swap pos")]

    public void SwapButton(ButtonData button, ButtonData button2)
    {
        if (button.isIn && button2.isIn)
        {
            StartCoroutine(Anim(button, button2));
        }
        else
        {
            StartCoroutine (AnimThrowOut(button, button2));
        }
    }
    [Button("swap colore")]
    public void SwapColor(ButtonData button, ButtonData button2)
    {
        Color tmp = button.col;
        button.col=button2.col;
        button2.col=tmp;
    }


    
    
   
}