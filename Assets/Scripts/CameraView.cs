using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

	public Transform playerTransform;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 
			(playerTransform.position.x + offset.x, 
				offset.y,
				offset.z);
	}
}
