using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	private static bool playing;
	// Use this for initialization
	void Start () {
		if(instance != null && instance !=this){
			Destroy(gameObject);
			print ("music destroyed");
		}else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
