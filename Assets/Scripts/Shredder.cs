using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Ball"){
			levelManager.LoadLevel("Loose Menu");
		}
	}
}
