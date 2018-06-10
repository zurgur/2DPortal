using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
	public GameObject destructionPoint;
	private float platformWidth;

	// Use this for initialization
	void Start () {
		destructionPoint = GameObject.Find ("PlatformDestructionPoint");
		platformWidth = gameObject.GetComponent<BoxCollider2D>().size.x;
		Debug.Log(destructionPoint);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x + platformWidth / 2 < destructionPoint.transform.position.x) {
			Destroy(gameObject);
		}
		
	}
}
