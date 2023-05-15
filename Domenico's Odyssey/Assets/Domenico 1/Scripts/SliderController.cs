using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Domenico1 {

    public class SliderController : MonoBehaviour {

        private CharacterController characterController;
        [SerializeField] private Slider slider;
        [SerializeField] private Vector2 minMaxViewportRange;
        [SerializeField] private GameObject handTutorial;
        private Camera cameraMain;
        bool isFirstTime;
        
        // Start is called before the first frame update
        void Start() {
            
            cameraMain = Camera.main;
            characterController = FindObjectOfType<CharacterController>();
            handTutorial.SetActive(true);
            isFirstTime = true;
        }

        // Update is called once per frame
        void Update() {

            if (slider.value != 0.5f && isFirstTime) {
                handTutorial.SetActive(false);
                isFirstTime = false;
            }
            
            float xPos = Mathf.Clamp(slider.value,minMaxViewportRange.x,minMaxViewportRange.y);
            Vector3 pos = cameraMain.ViewportToWorldPoint(new Vector3(xPos, characterController.transform.position.y,characterController.transform.position.z));

            characterController.SetPos(pos.x);
        }
    }

}
