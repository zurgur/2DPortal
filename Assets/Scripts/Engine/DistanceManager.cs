
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class DistanceManager : MonoBehaviour {

    private float maxDistance;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private TextMeshProUGUI text;

    private float timeToShow = 10;

    void Start () {
        maxDistance = PlayerPrefsManager.getDistance();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(this.transform.position, new Vector3(0, 0, 0));

        if(distance > maxDistance && timeToShow > 0)
        {
            text.text = distance.ToString();
            panel.SetActive(true);
            timeToShow -= Time.deltaTime;
            if(timeToShow <= 0)
            {

                panel.SetActive(false);
            }
        }

        if(distance > 1000)
        {
            PlayerPrefsManager.setDistance(distance);
            SceneManager.LoadScene(3);
        }
	}

}
