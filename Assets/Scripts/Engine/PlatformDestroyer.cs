using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
	private GameObject destructionPoint;
	private float platformWidth;

	// Use this for initialization
	void Start () {
		destructionPoint = GameObject.Find ("PlatformDestructionPoint");
		platformWidth = gameObject.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x + platformWidth / 2 < destructionPoint.transform.position.x) {
			gameObject.SetActive(false);
		}
		
	}
}
