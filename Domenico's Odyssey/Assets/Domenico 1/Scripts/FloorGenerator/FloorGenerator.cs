using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domenico1 {

	
	public class FloorGenerator : MonoBehaviour {


		[SerializeField] private GameObject floorObject;
		private Transform parentTransform;

		public Transform ParentTransform {
			get => parentTransform;
			set => parentTransform = value;
		}

		public void SpawnFloor(Transform positionPrevFloor, Transform parent) {
			var vectorOffset = new Vector3(0, positionPrevFloor.localScale.y * 10, 0);
			var floor = Instantiate(floorObject, positionPrevFloor.position - vectorOffset, Quaternion.identity, parent);
			var floorGeneratorComponent = floor.GetComponent<FloorGenerator>();
			floorGeneratorComponent.ParentTransform = parent;
		}

		private void OnTriggerEnter2D(Collider2D col) {
			if (col.gameObject.CompareTag("Player")) {
				SpawnFloor(transform, parentTransform);
			}
		}
	}

}


