using UnityEngine;
using System.Collections;

public class Snowflake : MonoBehaviour {

	private PlayerMovement player;
	private Rigidbody2D rigid2D;
	private SpriteRenderer spriteRenderer;
    public float rotationSpeed;

    void Start()
	{
        rigid2D = gameObject.GetComponent<Rigidbody2D>();

		player = FindObjectOfType<PlayerMovement> ();
        Debug.Log("hiutaleeeeeee!!!");
        rigid2D.velocity = Vector3.down * GameManager.snowFlakeSpeedMultiplier;
        rigid2D.AddTorque(rotationSpeed);
    }

	void Update()
	{
        //if (transform.position.y <= ShelfGameManager.destroyPoint.position.y) {
        if (transform.position.y <= 0.0F)
        {
            Destroy (gameObject);
		}
	}

    /*public void Activate()
    {
        Debug.Log("hiutaleeeeeee!!!");
        rigid2D.gravityScale = 1.5f;
        rigid2D.AddTorque(rotationSpeed);
    }*/

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Bucket")
		{
			player.Freeze ();
			Destroy (gameObject);
		}
	}
}
		

