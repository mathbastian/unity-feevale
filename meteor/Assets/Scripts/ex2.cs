using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex2 : MonoBehaviour {

	// Comment for GitHub

	public GameObject GemPrefab;

	private GameObject mo_gem;
	
	private Transform LeftEdge;
	private Transform RightEdge;
	private Transform UpperEdge;
	private Transform LowerEdge;

	private float mv_speed;
	
	private Color mv_color;

	private Vector2 mv_direction = Vector2.right;

	// Use this for initialization
	void Start () {
		LeftEdge = GameObject.FindGameObjectWithTag("left").transform;
		RightEdge = GameObject.FindGameObjectWithTag("right").transform;
		UpperEdge = GameObject.FindGameObjectWithTag("upper").transform;
		LowerEdge = GameObject.FindGameObjectWithTag("lower").transform;

		mo_gem = Instantiate(GemPrefab);
		mv_color = Random.ColorHSV(0,1);
		mv_speed = 1F;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (mv_direction == Vector2.right)
		{
			move_object_to_direction( mo_gem, mv_direction, mv_speed );

			if ( mo_gem.transform.position.x >= RightEdge.position.x )
			{
				change_color_of_object( mo_gem );
				mv_direction = get_new_direction();
			}
		}
		else if (mv_direction == Vector2.left)
		{
			//perform_left_right_response( mo_gem, mv_direction );
			move_object_to_direction( mo_gem, mv_direction, mv_speed );

			if ( mo_gem.transform.position.x <= LeftEdge.position.x )
			{
				change_color_of_object( mo_gem );
				mv_direction = get_new_direction();
			}
		}
		else if (mv_direction == Vector2.down)
		{
			move_object_to_direction( mo_gem, mv_direction, mv_speed );
			
			if ( mo_gem.transform.position.y <= LowerEdge.position.y )
			{
				increase_speed();
				mv_direction = get_new_direction();
			}

		}
		else if (mv_direction == Vector2.up)
		{
			move_object_to_direction( mo_gem, mv_direction, mv_speed );
			
			if ( mo_gem.transform.position.y >= UpperEdge.position.y )
			{
				increase_speed();
				mv_direction = get_new_direction();
			}
		}
	}

	private void move_object_to_direction( GameObject io_gem, Vector2 iv_direction, float iv_speed ){

		io_gem.transform.Translate( iv_direction * Time.deltaTime * iv_speed );

	}

	private void increase_speed( ){
		mv_speed += 0.5F;
	}

	private Vector2 get_new_direction(){
		Vector2 lv_direction;
		int random;
		do
		{
			random = Random.Range(0,4);

			switch ( random )
			{
				case 0: lv_direction = Vector2.left; break;
				case 1: lv_direction = Vector2.right; break;//right
				case 2: lv_direction = Vector2.up; break;//up
				case 3: lv_direction = Vector2.down; break;//down
				default: lv_direction = Vector2.right; break;
			}

		} while ( mv_direction == lv_direction );

		return lv_direction;
	}

	private void change_color_of_object( GameObject io_gem ){
		io_gem.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1);
	}

	private void perform_left_right_response( GameObject io_gem, Vector2 iv_direction ){
		
		move_object_to_direction( io_gem, iv_direction, mv_speed );

		if ( _reached_left_edge( io_gem ) || _reached_right_edge( io_gem ) ) {
			change_color_of_object( io_gem );
			iv_direction = get_new_direction();
		}
	}

	private bool _reached_right_edge( GameObject io_gem ){
		if ( mo_gem.transform.position.x >= RightEdge.position.x )
			{
				return true;
			}
		return false;
	}

	private bool _reached_left_edge( GameObject io_gem ){
		if ( mo_gem.transform.position.x <= LeftEdge.position.x )
			{
				return true;
			}
		return false;
	}
}