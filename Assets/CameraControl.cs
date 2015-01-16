using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	[Range (0.05f,0.5f)] public float factor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void move(Vector3 position){
		Vector3 newPosition;
		newPosition.x = Mathf.Clamp(position.x * factor,-10,10);
		newPosition.y = Mathf.Clamp(position.y * factor,-10,10);
		newPosition.z = transform.position.z;
		
		transform.position = newPosition;
	
	}
}
