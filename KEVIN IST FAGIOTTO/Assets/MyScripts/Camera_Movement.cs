using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {
    public float speed = 10f;

    CharacterController camera;
    private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {
        camera = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection *= speed;
        camera.Move(moveDirection * Time.deltaTime);
	}
}
