using System;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ColorDB", menuName = "ScriptableObjects/DB", order = 1)]

public class ColorDB : SerializedScriptableObject
{
  public List<MapColor> colors;


  public string GetString(Color color) {
    foreach (var colorMap in colors) {
      if (colorMap.color == color) {
        return colorMap.nameColor;
      }
    }
    return null;
  }
}

[Serializable]
  public class MapColor {
  public Color color;
  public string nameColor;
}
