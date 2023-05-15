using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonData : MonoBehaviour
{
   public Action<Color> onColorChange;
   public KeyCode keycode;
   public Color col;
   public ColorDB colorDB;
static List<Color> colors=new List<Color>();
    [Button("AssignColor")]
    private void Start()
    {
        colors.AddRange(colorDB.colors);
        int tmp = UnityEngine.Random.Range(0, colors.Count);
        col = colors[tmp];
        colors.RemoveAt(tmp);
      
    }
    public void click()
    {
        onColorChange(col);
    }
    private void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            onColorChange(col);
        }
    }

}
