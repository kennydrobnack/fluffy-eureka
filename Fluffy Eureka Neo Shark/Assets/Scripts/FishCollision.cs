using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FishCollision : MonoBehaviour {

	public int value = 1;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Fish")) {
			IncreaseScore ();
			Destroy (other.gameObject);
		}
	}



	private void IncreaseScore(){
		GameObject score = GameObject.FindGameObjectWithTag ("Score");
		Text text = score.GetComponent<Text> ();
		int scoreValue;
		int.TryParse (text.text, out scoreValue);
		scoreValue += value;
		text.text = scoreValue.ToString();
	}
}
