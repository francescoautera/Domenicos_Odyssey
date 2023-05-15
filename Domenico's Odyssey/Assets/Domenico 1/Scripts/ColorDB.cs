using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ColorDB", menuName = "ScriptableObjects/DB", order = 1)]

public class ColorDB : SerializedScriptableObject
{
  public List<Color> colors;
}
