using System.Collections.Generic;
using UnityEngine;

namespace Domenico.Shared
{

	[CreateAssetMenu(fileName = "ScriptableKeys_", menuName = "Domenico/Keys")]
	public class ScriptableKeys : ScriptableObject
	{
		[SerializeField] private List<KeyCode> keys;
		public List<KeyCode> Keys => keys;
	}

}