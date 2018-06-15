using UnityEngine;

public class portal : MonoBehaviour {

    [SerializeField]
    private GameObject playerOne;

    [SerializeField]
    private GameObject playerTwo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerOne" || other.tag == "PlayerTwo")
        {
            playerOne.GetComponent<PlayerController>().Flip();
            playerTwo.GetComponent<PlayerController>().Flip();

        }
    }
}
