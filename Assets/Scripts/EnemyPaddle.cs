using UnityEngine;
using System.Collections;

public class EnemyPaddle : MonoBehaviour {
	
	public GameObject sphere;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// limit the position of the Paddle
		float xValue = Mathf.Clamp(sphere.rigidbody.position.x,-7.5f,7.5f);
		float yValue = Mathf.Clamp(sphere.rigidbody.position.y,-7.5f,7.5f);
		
		// Keeps the same z position but changes x and y value according to the ball
		rigidbody.position = new Vector3(xValue,yValue,rigidbody.position.z);
	}

	
}
