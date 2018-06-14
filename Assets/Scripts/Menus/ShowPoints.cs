using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPoints : MonoBehaviour {

    [SerializeField]
    private string player;

    [SerializeField]
    private TextMeshProUGUI points;

	void Start () {
        int currentPoints = PlayerPrefs.GetInt(player);
        points.text = currentPoints.ToString();
        PlayerPrefs.SetInt(player, 0);
        PlayerPrefsManager.AddMoney(currentPoints);

    }

}
