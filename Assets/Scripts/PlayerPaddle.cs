using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {
	// main camera
	public Camera myCamera;
	//mouse Position on the screen
	private Vector3 screenPosition;
	//Object position in the game world
	private Vector3 worldPosition;
	// distance between the camera and the object
	private float cameraToObjectDistance;
	
	private CameraControl cameraControl;
	
	private float x,y;
	
	public GameObject sphere;
	
	// Use this for initialization
	void Start () {
		cameraToObjectDistance = transform.position.z - myCamera.transform.position.z;
		cameraControl = myCamera.GetComponent<CameraControl>();
	}
	
	// Update is called once per frame
	void Update () {
		/*// used for auto playing
		float xValue = Mathf.Clamp(sphere.rigidbody.position.x,-7.5f,7.5f);
		float yValue = Mathf.Clamp(sphere.rigidbody.position.y,-7.5f,7.5f);
		rigidbody.position = new Vector3(xValue,yValue,rigidbody.position.z);
		*/
		
		// update mouse position with respect to depth
		screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraToObjectDistance);
		
		// convert the screen position to game world units
		worldPosition = myCamera.ScreenToWorldPoint(screenPosition);
		float xValue = Mathf.Clamp(worldPosition.x,-7.5f,7.5f);
		float yValue = Mathf.Clamp(worldPosition.y,-7.5f,7.5f);
		worldPosition = new Vector3(xValue,yValue,worldPosition.z);
		// move this object according to the mouse
		cameraControl.move(worldPosition);
		transform.position = worldPosition;
		
	}
	
	
	void OnCollisionEnter(){
		ScoreKeeper.add(1);
	}
}
