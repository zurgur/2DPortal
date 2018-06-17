
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceManager : MonoBehaviour {

    private float maxDistance;

    
	void Start () {
        maxDistance = PlayerPrefsManager.getDistance();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(this.transform.position, new Vector3(0, 0, 0));
        if(distance > 1000)
        {
            PlayerPrefsManager.setDistance(distance);
            SceneManager.LoadScene(3);
        }
	}
}
