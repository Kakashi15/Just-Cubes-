using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMovement : MonoBehaviour {

    public Transform idealPosition;
	void Start () {
		
	}
	
	void Update () {
        transform.position = new Vector3(idealPosition.position.x,transform.position.y,transform.position.z);
	}
}
