using System.Collections.Generic;
using UnityEngine;

namespace Domenico.Shared
{

	[CreateAssetMenu(fileName = "Domenico_Palette", menuName = "Domenico/Palette")]
	public class ColorPalette : ScriptableObject
	{
		[SerializeField] private List<ScriptableColor> palette;
		public List<ScriptableColor> Palette => palette;

		
	}

}