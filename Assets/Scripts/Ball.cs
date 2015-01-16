using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public AudioClip paddleSound;
	public AudioClip wallSound;
	private LevelManager levelManager;
	private float timePassed;
	private bool collidedWithPaddle;
	// Use this for initialization
	private Vector3 randomnessVector;
	void Start () {
		// Give the ball a velocity toward the player
		rigidbody.velocity = new Vector3(-3,-10,-20);
		// timePassed and collidedWithPaddle are used to avoid infinite loop
		timePassed = 0f;
		collidedWithPaddle = false;
	}
	
	// Update is called once per frame
	void Update () {
		print (rigidbody.velocity);
		if(!collidedWithPaddle){
			timePassed += Time.deltaTime;
		}
		// if timepassed is greater than 5 seconds and the ball still hasnt collided with the paddle
		// and the ball is going toward the AI Paddle , Add z velocity to the ball
		if(timePassed > 5f && !collidedWithPaddle && rigidbody.velocity.z > 0){
			rigidbody.velocity += new Vector3(0f,0f,5f);
			timePassed = 0f;
		}
	}
	
	void OnCollisionEnter (Collision col){

		if(col.gameObject.tag == "Paddle"){
			timePassed = 0;
			collidedWithPaddle = true;
			AudioSource.PlayClipAtPoint(paddleSound,rigidbody.position);
			
			// depending on which direction the ball is going, the velocity will be added accordingly 
			if(rigidbody.velocity.z < 0){
				
				rigidbody.velocity += new Vector3(-1f,-1f,-1f);
				randomnessVector.x = Random.Range(-1,0f); 
				randomnessVector.y = Random.Range(-1,0f);
				randomnessVector.z = 0;
				rigidbody.velocity += randomnessVector;
			}else{
				rigidbody.velocity += new Vector3(1f,1f,1f);
				randomnessVector.x = Random.Range(0f,1f); 
				randomnessVector.y = Random.Range(0f,1f);
				randomnessVector.z = 0;
				rigidbody.velocity += randomnessVector;
			}
		}else{
			collidedWithPaddle = false;
			AudioSource.PlayClipAtPoint(wallSound,rigidbody.position);
		}
		
		
	}
}
