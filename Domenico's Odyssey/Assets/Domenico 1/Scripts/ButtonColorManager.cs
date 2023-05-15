using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColorManager : MonoBehaviour
{
   public Action<Color> onColorChange;
   public KeyCode keycode;

    public void click()
    {
        onColorChange(Color.red);
    }
    private void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            onColorChange(Color.blue);
        }
    }

}
