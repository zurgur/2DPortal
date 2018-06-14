using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Button[] itemButtons;

	// Use this for initialization
	void Start () {
        for (int i = 1; i < itemButtons.Length; i++)
        {
           //  itemButtons[i].interactable = PlayerPrefsManager.IsLevelUnlocked(i);
            
        }
	}
	
}
