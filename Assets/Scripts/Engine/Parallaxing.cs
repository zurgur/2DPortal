﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {
	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float smoothing; 				// Must be above 0

	public Transform cam;
	private Vector3 previousCamPosition;

	// Use this for initialization
	void Start () {
		previousCamPosition = cam.position;

		parallaxScales = new float[backgrounds.Length];
		for(int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < backgrounds.Length; i++) {
			float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i]; 
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		previousCamPosition = cam.position;
		
	}
}
