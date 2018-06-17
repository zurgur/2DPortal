using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossHealth : MonoBehaviour {
    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private int maxHP;

    private int health;

    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private GameObject generator;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
       
        health = maxHP;
        healthBar.maxValue = maxHP;
        healthBar.value = health;
    }

    public void hurtBoss(int damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            GameObject.Find("PlatformGenerator").GetComponent<PlatformGenerator>().Generate = false;
            Destroy(gameObject);
        }

    }
    void Update()
    {

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
    }

}
