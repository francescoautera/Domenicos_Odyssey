using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
   public List<ButtonData> buttons = new List<ButtonData>();
   public ColorDB db;
    private void Start()
    {
        buttons = FindObjectsOfType<ButtonData>().ToList();
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
