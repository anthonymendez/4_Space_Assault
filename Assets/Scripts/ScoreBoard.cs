using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scoreDefHit = 12;

    int score = 0;
    Text scoreText;
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}
	
    public void ScoreHit() {
        score += scoreDefHit;
        scoreText.text = score.ToString();
    }

	public void ScorePerHit(int scorePerHit) {
        // CHANGE A
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}
