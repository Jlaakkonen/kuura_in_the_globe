using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {

	protected Rigidbody2D rgb2D;
	protected BoxCollider2D itemColl;
	public float rotationSpeed;
	float destPointY;
    bool falling = false;
	//public static Transform destroyPoint;

	// Use this for initialization
	protected virtual void Start () 
	{
		rgb2D = gameObject.GetComponent<Rigidbody2D> ();
		itemColl = gameObject.GetComponent<BoxCollider2D> ();
		itemColl.isTrigger = true;
		// = ShelfGameManager.destroyPoint.position.y;

        destPointY = 0.0F;
    }

	protected virtual void Update()
	{
        if(falling)
        {
            rgb2D.velocity = new Vector3(0, -10, 0);
        }
        

        if (transform.position.y <= 8f) {
			itemColl.isTrigger = false;
		}
		if (transform.position.y <= destPointY) {
			Points.breakingPoints++;
			Destroy (gameObject);
		}
	}

	//Apply physics in child item
	public void Activate()
	{
        //Vector3 dropSpeed = Vector3.down * 100;
        //rgb2D.AddForce(dropSpeed);
        falling = true;
        rgb2D.velocity = new Vector3(0, -10, 0);
		rgb2D.AddTorque(rotationSpeed);
	}

	public void WaitActivate()
	{
		transform.parent = null;
		Invoke ("Activate", 0.7f);
	}
}
