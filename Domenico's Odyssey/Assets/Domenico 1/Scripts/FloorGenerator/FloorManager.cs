using UnityEngine;

namespace Domenico1 {

	public class FloorManager : MonoBehaviour {

		[SerializeField] private FloorGenerator firstFloor;

		private void Awake() {
			firstFloor.ParentTransform = transform;
			firstFloor.StartFirstFloor();
		}
	}

}