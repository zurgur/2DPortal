using System;
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
    public void buyItem(int index)
    {
        int cost = Int32.Parse(itemButtons[index].GetComponentInChildren<TextMeshProUGUI>().text);
        int walet = PlayerPrefsManager.GetMoney();
        if(cost > walet)
        {
            Debug.Log("not enugh funds");
            return;
        }
        PlayerPrefsManager.AddMoney(-cost);
        PlayerPrefsManager.UnlockItem(index);
        Start();
    }
	
}
