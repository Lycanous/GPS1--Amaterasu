using UnityEngine;
using System.Collections;

public class ClimbLadder : MonoBehaviour {
	private Player player;

	private bool colWithLadder=false;
	private bool isClimbingLadder=false;
	private int climbingDirection=0;


	void startUpLadder()
	{
		
		isClimbingLadder=true;
		
		
	}
	void climbLadder()
	{
		
		if(isClimbingLadder)
		{
			transform.Translate(new Vector3(0,0.1f,0));
			climbingDirection=1;
		}
		if(!colWithLadder)
		{
			isClimbingLadder=false;
			player.canMove=true;
		}
	}
	void Start () 
	{
		player = gameObject.GetComponent<Player>();
	
	}

	void Update () 
	{
		SpriteRenderer renderer;
		renderer =(SpriteRenderer)gameObject.renderer;
		player.position = transform.position;
		Vector3 worldMouse=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));

		if (Input.GetMouseButton(0))
		{
			//climb up ladder
			if(colWithLadder&&worldMouse.x>transform.position.x-renderer.bounds.size.x&&worldMouse.x<transform.position.x+renderer.bounds.size.x&!isClimbingLadder)
			{
				isClimbingLadder=true;
				climbingDirection=1;
			}
			//climb down ladder
			else if(colWithLadder&&worldMouse.x>transform.position.x-renderer.bounds.size.x&&worldMouse.x<transform.position.x+renderer.bounds.size.x&!isClimbingLadder)
			{
				isClimbingLadder=true;
			} 
			else if(!isClimbingLadder)
			{
				player.canMove=true;
			}   
		}
		climbLadder();
	
	}
	void OnTriggerStay2D(Collider2D other)
	{
		
		if(other.gameObject.tag =="Ladder")
		{
			Debug.Log("On Trigger Stay");
			colWithLadder =true;
		}
		
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag =="Ladder")
		{
			Debug.Log("On Trigger Exit");
			colWithLadder=false;
		}
	}
}
