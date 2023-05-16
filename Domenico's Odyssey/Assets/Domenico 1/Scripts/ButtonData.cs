using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonData : MonoBehaviour
{
   public Action<Color> onColorChange;
   public KeyCode keycode;
   public Color col;
   public ColorDB colorDB;
   static List<Color> colors=new List<Color>();
   private TMP_Text text;
    public bool isIn;
    public bool isOutOFRange;

    [Button("AssignColor")]
   
    public void Init(Color color,int index) {
        // colors.AddRange(colorDB.colors);
        // int tmp = UnityEngine.Random.Range(0, colors.Count);
        text = GetComponentInChildren<TMP_Text>();
        col = color;
        var value = index + 1;
        text.text = value.ToString();
        // colors.RemoveAt(tmp);
    }

    public void click()
    {
        onColorChange(col);
    }
    private void Update()
    {
        if (Input.GetKeyDown(keycode) && !isOutOFRange)
        {
            onColorChange(col);
        }
    }

}
