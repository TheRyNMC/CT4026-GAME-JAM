using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private InputActionReference playersInputs;
    float pointerInputValue;
    bool fire;
    private new Camera camera;

    private void Awake() {
        playersInputs.action.performed += context => pointerInputValue = context.action.ReadValue<float>();
    }
    private void Start() {
        camera = Camera.main;
    }
    void Update() {
        if (pointerInputValue == 1) {
            if (fire == false) {
                Fire();
            }
        } else if (pointerInputValue == 0) {
            fire = false;
        }
    }
    void Fire() {
        fire = true;
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 7f)) {
            Debug.Log("Shot " + hit.transform.name);
        }
    }
}
