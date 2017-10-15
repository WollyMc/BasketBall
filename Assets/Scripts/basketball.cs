using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basketball : MonoBehaviour {

	public Text score;
	public Text remainingballs;

	private int currentscore = 0;
	public int remainingballs_number = 50; 
	private Vector3 InitialPosition;
	private TouchManager touchsystem;

	void Start()
	{
		touchsystem = GameObject.FindObjectOfType<TouchManager>().GetComponent<TouchManager>();
		InitialPosition = this.transform.position; //helps to set initial position to current ball position
		ChangeText();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ring") 
		{
			ScoreUpdate();
			remainingballs_number++;
		}
	}

	public void DecreaseRemainingBalls()
	{
		remainingballs_number--;
		ChangeText ();
	}

	public void ChangeText()
	{
		remainingballs.text = "Balls left: " + remainingballs_number.ToString ();
	}
	private void ScoreUpdate()
	{
		currentscore++;
		score.text = currentscore.ToString();
	}

	public void ResetPosition()
	{
		this.transform.position = InitialPosition + new Vector3 (Random.Range (-50f, 50f), 0f, 0f);
		this.GetComponent<Rigidbody> ().useGravity = false;
		this.GetComponent<Rigidbody> ().isKinematic = true;
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		touchsystem.canswipe = true;
	}
}

