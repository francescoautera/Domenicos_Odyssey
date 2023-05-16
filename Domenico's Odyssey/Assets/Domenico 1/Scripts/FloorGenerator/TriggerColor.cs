using System;
using UnityEngine;

namespace Domenico1 {

	public class TriggerColor : MonoBehaviour {
		public Action OnPlayerInside;
			
		private void OnTriggerEnter2D(Collider2D col) {
			if (col.GetComponent<CharacterController>()) {
				OnPlayerInside?.Invoke();
			}
		}
	}

}