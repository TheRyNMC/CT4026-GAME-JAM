using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {
    [SerializeField]
    private InputActionReference playersInputs;
    float pointerInputValue;
    bool fire;
    private new Camera camera;
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private GameObject tower;
    RaycastHit hit;
    private void Awake() {
        playersInputs.action.performed += context => pointerInputValue = context.action.ReadValue<float>();
    }
    private void Start() {
        camera = Camera.main;
        //dropdown = GameObject.Find("Dropdown");
        //tower = GameObject.Find("SingleFireTurret");
        dropdown.gameObject.SetActive(false);
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

    public void HandlingData() {
        if (dropdown.value == 1) {
            GameObject newTower = Instantiate(tower, hit.transform.position + new Vector3(2.5f, 0f, 2.5f), Quaternion.identity);
            Cursor.lockState = CursorLockMode.Locked;
            dropdown.gameObject.SetActive(false);
        }
        else if (dropdown.value == 2) {
            dropdown.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Fire() {
        fire = true;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 7f)) {
            Debug.Log("Shot " + hit.transform.name);
            if (hit.transform.CompareTag("PlaneA")) {
                dropdown.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            } 
            else if (hit.transform.CompareTag("PlaneB")) {
                dropdown.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            
        }
    }
}
