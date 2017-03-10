using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_manager : MonoBehaviour {
    private int score_int;
    private Text score;
	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addscore(int num)
    {
        score_int += num;
        score.text = "score: " + score_int.ToString();
    }
}
