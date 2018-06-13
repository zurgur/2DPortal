using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private float health;

    [SerializeField]
    private Slider healthBar;

    

    public void HurtPlayer(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health<=0)
        {
            Debug.Log("dead need to implament deth screen");
        }
        
    }
	
}
