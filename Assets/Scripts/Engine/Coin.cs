using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private GameObject particle;

    [SerializeField]
    private string playerOne = "player1";

    [SerializeField]
    private string playerTwo = "player2";

    [SerializeField]
    private int points = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "PlayerOne")
        {
            int current = PlayerPrefs.GetInt(playerOne);
            PlayerPrefs.SetInt(playerOne, current + points);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(col.tag == "PlayerTwo")
        {
            int current = PlayerPrefs.GetInt(playerTwo);
            PlayerPrefs.SetInt(playerTwo, current + points);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
