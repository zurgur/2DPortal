using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	// public GameObject[] platforms;
	public Transform generationPoint;
	private float[] platformWidths;

	private int platformSelector;
	private float distanceBetween;
	private float distanceBetweenMin = 1;
	private float distanceBetweenMax = 4;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	private float maxHeightChange = 10;
	private float heightChange;
    public bool generate = true;

	public ObjectPooler[] objectPools;

	// Use this for initialization
	void Start () {
		platformWidths = new float[objectPools.Length];
        if (generate)
        {
		    for(int i = 0; i < objectPools.Length; i++) {
			    platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		    }

        }

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
		
	}
	
	// Update is called once per frame
	void Update () {
			if(transform.position.x < generationPoint.position.x && generate) {
				platformSelector = Random.Range(0, objectPools.Length);
				distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

				heightChange = transform.position.y + Random.Range(maxHeight, -maxHeightChange);

				if(heightChange > maxHeight) {
					heightChange = maxHeight;
				} else if(heightChange < minHeight){
					heightChange = minHeight; 
				}

				transform.position = new Vector3(
					transform.position.x + distanceBetween + platformWidths[platformSelector]/2, 
					heightChange ,
					transform.position.z);

				GameObject newPlatform = objectPools[platformSelector].GetPooledObject();
				newPlatform.transform.position = transform.position;
				newPlatform.transform.rotation = newPlatform.transform.rotation;
				newPlatform.SetActive(true);


					transform.position = new Vector3(
						transform.position.x + platformWidths[platformSelector]/2, 
						transform.position.y,
						transform.position.z);
			}
	}
}
