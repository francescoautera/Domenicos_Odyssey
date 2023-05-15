using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonData : MonoBehaviour
{
   public Action<Color> onColorChange;
   public KeyCode keycode;
    public Color col;

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
