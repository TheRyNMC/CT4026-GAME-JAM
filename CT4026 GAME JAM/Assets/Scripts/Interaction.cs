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
    [SerializeField]    private GameObject dropdown;
    [SerializeField] private GameObject tower;
    RaycastHit hit;
    private void Awake() {
        playersInputs.action.performed += context => pointerInputValue = context.action.ReadValue<float>();
    }
    private void Start() {
        camera = Camera.main;
        //dropdown = GameObject.Find("Dropdown");
        //tower = GameObject.Find("SingleFireTurret");
        dropdown.SetActive(false);
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

    public void HandlingData(int val) {
        if (val == 1) {
            GameObject newTower = Instantiate(tower, hit.transform.position, Quaternion.identity);
            tower.transform.position = hit.transform.position + new Vector3 (1f,0f,1f);
            Cursor.lockState = CursorLockMode.Locked;
            dropdown.SetActive(false);
        }
    }
    
    void Fire() {
        fire = true;
        
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 7f)) {
            Debug.Log("Shot " + hit.transform.name);
            if (hit.transform.CompareTag("PlaneA")) {
                dropdown.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                HandlingData(0);
            }


        }
    }
    


}
