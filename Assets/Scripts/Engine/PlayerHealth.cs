using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private int health;

    [SerializeField]
    private Slider healthBar;

    

    public void HurtPlayer(int damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health<=0)
        {
            Debug.Log("dead need to implament deth screen");
        }
        
    }
	
}
