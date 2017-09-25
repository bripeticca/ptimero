using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	public Rigidbody2D rb;
	public float movespeed;
	private bool onGround = true;
	float JumpForce = 8;

	// notice: want constant movement to the right
	// only action is tapping

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
		rb.velocity = new Vector2(movespeed, rb.velocity.y);
		Debug.Log ("transform.position: " + transform.position);

		if (!onGround) 
		{
			rb.velocity += new Vector2(0, Physics.gravity.y * 0.04f);
		}
		/*foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) 
			{
				// jump
			} 
			else if (t.phase == TouchPhase.Ended) 
			{
				// stop jumping
			}
		}*/
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Jump ();
		}
	}

	void Jump()
	{
		if (onGround) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, JumpForce * 2);
			//rb.AddForce(new Vector2(0, 10));
			//rb.AddForce(new Vector2(50, 10 * Physics.gravity.magnitude * 5));
			onGround = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") 
		{
			onGround = true;
		}
		/*if (collision.gameObject.tag == "Timer") 
		{
			Destroy (collision.gameObject);
		}*/
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Timer") 
		{
			Destroy (other.gameObject);
		}
	}
}