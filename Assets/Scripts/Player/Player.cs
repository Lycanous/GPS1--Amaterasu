using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public Vector2 position;
	//private int direction=1;
	private int speed=6;
	private float targetX;
	public bool canMove=true;

	void moveToPosition(float posX)
	{
		targetX = posX;
	}

	void Start () 
	{
		targetX = transform.position.x;

	}

	void Update () 
	{
		SpriteRenderer renderer;
		renderer =(SpriteRenderer)gameObject.renderer;
		position = transform.position;
		Vector3 worldMouse=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
		if (Input.GetMouseButton(0))
		{
			if(canMove)
			{
				moveToPosition(worldMouse.x);
			}   
		}
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,transform.position.y), new Vector2(targetX, position.y),speed*Time.deltaTime);
	
	}


}
