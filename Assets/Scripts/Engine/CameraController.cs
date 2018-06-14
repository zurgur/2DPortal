using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition;

	private float distanceToMove;

    private float shakeTimer;
    private float shakeAmount;

    // Use this for initialization
    void Start () {
		// thePlayer = FindObjectOfType<PlayerController>();
		lastPlayerPosition = thePlayer.transform.position;
	}

    void Update()
    {
        if (shakeTimer > 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);

            shakeTimer -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void LateUpdate() {
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3(transform.position.x + distanceToMove,  transform.position.y, transform.position.z);
		lastPlayerPosition = thePlayer.transform.position;

		
	}
    public void StartShake(float time, float amount)
    {
        shakeTimer = time;
        shakeAmount = amount;
    }
}
