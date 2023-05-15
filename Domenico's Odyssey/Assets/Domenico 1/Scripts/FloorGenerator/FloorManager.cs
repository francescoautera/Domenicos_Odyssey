using System;
using UnityEngine;

namespace Domenico1 {

	public class FloorManager : MonoBehaviour {

		[SerializeField] private FloorGenerator firstFloor;
		[SerializeField] private float velocity;

		private void Awake() {
			firstFloor.ParentTransform = transform;
			firstFloor.StartFirstFloor();
		}

		private void Update() {
			transform.position += (Vector3.up * velocity * Time.deltaTime);
		}
	}

}