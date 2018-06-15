using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private GameObject particle;

    [SerializeField]
    private string playerOne = "player1";

    [SerializeField]
    private string playerTwo = "player2";

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private int points = 10;

    private Vector3 TargetPos;
    private GameObject player;
    private bool magnet;

    void Awake()
    {
        magnet = PlayerPrefsManager.IsItemnlocked(1);
    }

    void Update()
    {
        if (player && magnet)
        {
            TargetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, TargetPos, moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerOne")
        {
            int current = PlayerPrefs.GetInt(playerOne);
            PlayerPrefs.SetInt(playerOne, current + points);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "PlayerTwo")
        {
            int current = PlayerPrefs.GetInt(playerTwo);
            PlayerPrefs.SetInt(playerTwo, current + points);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       player = other.gameObject;
        
    }

}
