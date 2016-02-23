using UnityEngine;
using System.Collections;

/**
 * dynamic move the kill trigger
 * */
public class KillTriggerFollow : MonoBehaviour {

	private Transform player;		// Reference to the player's transform.
	
	public float xSmooth = 8f;		// How smoothly the killTrigger catches up with it's target movement in the x axis.

	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate ()
	{
		if(player != null)
			TrackPlayer();
	}

	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
		targetX = Mathf.Lerp (transform.position.x, player.position.x, xSmooth * Time.deltaTime);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}


}
