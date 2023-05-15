using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domenico.Shared
{


   [CreateAssetMenu(fileName = "ScriptableColor_", menuName = "Domenico/Color")]
   public class ScriptableColor : ScriptableObject
   {
      [SerializeField] private Color color = Color.black;
      public Color Color => color;

      [SerializeField] private string colorName;
      public string ColorName => colorName;

      
      


   }

}