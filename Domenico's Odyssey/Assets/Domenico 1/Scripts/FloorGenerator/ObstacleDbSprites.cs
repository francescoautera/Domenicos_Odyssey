using System.Collections.Generic;
using UnityEngine;

namespace Domenico1 {

	[CreateAssetMenu(menuName = "Domenico1/obstacle",fileName = "obstacleDbSprites")]
	public class ObstacleDbSprites : ScriptableObject {
        
		public List<Sprite> sprites;

		public Sprite GetSprite() => sprites[Random.Range(0, sprites.Count)];
	}

}