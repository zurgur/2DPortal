using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Button[] levelbuttons;

	// Use this for initialization
	void Start () {
        for (int i = 1; i < levelbuttons.Length; i++)
        {
            levelbuttons[i].interactable = PlayerPrefsManager.IsLevelUnlocked(i);
            ;
        }
	}
	
}
