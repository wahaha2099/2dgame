using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapCreactor : MonoBehaviour {

	private Transform player;		// Reference to the player's transform.

	public int UnitWidth = 50 ;  	// width unit for map 

	public float xSmooth = 8f;		// How smoothly the killTrigger catches up with it's target movement in the x axis.

	HashSet<int> mapIndex ;			//map index 
	Dictionary<int , GameObject> mapDictory ;

	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;

		mapIndex = new HashSet<int> ();
		mapDictory = new Dictionary<int, GameObject> ();
	}

	void FixedUpdate ()
	{
		if(player != null)
			TrackPlayer();
	}

	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = player.position.x;
		float targetY = player.position.y;

		int index = (int ) targetX / UnitWidth;

		Debug.Log ("map index is = " + index );

		AddNextMap(index - 1 );
		AddNextMap(index + 1 );
		RemoveMap (index - 2 );
		RemoveMap (index + 2 );
	}

	private void AddNextMap( int index ){
		if (index <= 0 || mapDictory.ContainsKey (index))
			return;

		Object map = Resources.Load ("Prefabs/Environment/Foregrounds");
		
		Vector3 mapPos = new Vector3( index * UnitWidth , 0 , 1 );
		
		Debug.Log ("x = " + UnitWidth );
		
		GameObject obj = (GameObject)Instantiate(map, mapPos, Quaternion.identity);

		//mapIndex.Add (index);
		mapDictory.Add ( index , obj );
	}

	private void RemoveMap( int index ){
		if (index > 0) {

			if (!mapDictory.ContainsKey (index))
				return;

			Destroy( mapDictory[ index ]);
			mapDictory.Remove (index);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
