using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int health;

    [SerializeField]
    private Slider healthBar;

    void Start()
    {
        HurtPlayer(50);
    }

    public void HurtPlayer(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Debug.Log("dead need to implament deth screen");
        }
        healthBar.value = health;
    }
	
}
