using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public  Transform generationPoint;

	private float platformWidth;

	// Use this for initialization
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		transform.position = new Vector3(platformWidth/2, 0, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3(transform.position.x + platformWidth / 2, transform.position.y, transform.position.z);
			Instantiate (thePlatform, transform.position, transform.rotation );
			transform.position = new Vector3(transform.position.x + platformWidth / 2, transform.position.y, transform.position.z);

		}
	}
}
