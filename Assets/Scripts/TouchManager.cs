using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {
	private float InitialTouchTime;
	private float FinalTouchTime;
	private Vector2 InitialTouchPosition;
	private Vector2 FinalTouchPosition;

	private float XaxisForce; //Checking velocity in X-axis
	private float YaxisForce; //Checking velocity in Y axis
	private float ZaxisForce; //Checking velocity in Z axis

	private Vector3 Requireforce;

	public Rigidbody ball;

	public bool canswipe = true;
	void Start()
	{
		Time.timeScale = 3; //to increase gameplay by 3 times
		ball.useGravity = false; //unless user acts on the ball gravity should be neglected
	}

	public void OnTouchDown() //For the mouse being pressed
	{
		if (canswipe) {
			InitialTouchTime = Time.time;
			InitialTouchPosition = Input.mousePosition;
		}
	}

	public void OnTouchUp() //After lifting the mouse
	{
		if (canswipe) {
			FinalTouchTime = Time.time;
			FinalTouchPosition = Input.mousePosition;
			Ballthrow ();
		}
	}

	private void Ballthrow()
	{
		XaxisForce = FinalTouchPosition.x - InitialTouchPosition.x;//force on x
		YaxisForce = FinalTouchPosition.y - InitialTouchPosition.y;
		ZaxisForce = FinalTouchTime - InitialTouchTime;

		Requireforce = new Vector3 (-XaxisForce, YaxisForce/2.0f, -ZaxisForce*90f); //we divide to make sure that slight swipe is enough to make it work
		ball.useGravity = true;
		ball.isKinematic = false;
		ball.velocity = Requireforce;
		canswipe = false;
	}
		
}
