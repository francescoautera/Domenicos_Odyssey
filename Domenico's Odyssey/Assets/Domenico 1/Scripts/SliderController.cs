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

            float sliderValue = slider.value;
            
            CheckForMovement(sliderValue);

            UpdateMovement(sliderValue);
        }

        void CheckForMovement(float value)
        {
            if (value != 0.5f && isFirstTime) {
                handTutorial.SetActive(false);
                isFirstTime = false;
            }
        }

        void UpdateMovement(float value)
        {
            Vector3 charPos = characterController.transform.position;
            float xPos = Mathf.Clamp(value, minMaxViewportRange.x, minMaxViewportRange.y);
            Vector3 pos = cameraMain.ViewportToWorldPoint(new Vector3(xPos, charPos.y, charPos.z));

            characterController.SetPos(pos.x);

            if (value == 1)
            {
                float lerpDuration = 2.0f;
                float t = 0.0f;
                
                Vector3 endPos = cameraMain.ViewportToWorldPoint(new Vector3 (minMaxViewportRange.x, charPos.y, charPos.z));

                while (t < 1.0f)
                {
                    t+= Time.deltaTime / lerpDuration;
                    Vector3 lerpedPos = Vector3.Lerp(charPos, endPos, t);
                    characterController.SetPos(lerpedPos.x);
                }
                
                characterController.SetPos(endPos.x);
            }
        }
    }

}
