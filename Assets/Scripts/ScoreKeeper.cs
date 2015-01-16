using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	private static int score = 0; 
	private static Text text ;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text>();
		text.text = score.ToString();
		if(Application.loadedLevelName == "Start Menu"){
			reset();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public static void add (int point){
		score += point;
		text.text = score.ToString();
		
	}
	
	public static void reset(){
		score = 0;
	}
	
	public static int getScore(){
		return score;
	}
}
