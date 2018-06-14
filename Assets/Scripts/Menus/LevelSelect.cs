using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Button[] itemButtons;
    public TextMeshProUGUI points;


    // Use this for initialization
    void Start () {

        points.text = "Walet: " +PlayerPrefsManager.GetMoney().ToString();


        for (int i = 0; i < itemButtons.Length; i++)
        {
           itemButtons[i].interactable = !PlayerPrefsManager.IsItemnlocked(i);
            
        }
	}
	
}
