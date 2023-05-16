using System;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ColorDB", menuName = "ScriptableObjects/DB", order = 1)]

public class ColorDB : SerializedScriptableObject
{
  public List<MapColor> colors;
  
}

[Serializable]
public class MapColor {
  public Color color;
  public string nameColor;
}
