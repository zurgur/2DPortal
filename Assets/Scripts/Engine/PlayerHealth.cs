using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private float health;

    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private int maxHP;


    void Start()
    {
        if (PlayerPrefsManager.IsItemnlocked(2))
        {
            addMaxHelth(100);
        }
    }

    public void HurtPlayer(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    public void resetHelth()
    {
        health = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = health;
    }
    public void addMaxHelth(int hp)
    {
        maxHP += hp;
        resetHelth();

    }

}
