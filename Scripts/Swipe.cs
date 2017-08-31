using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection{
	None = 0,
	Left = 1,
	Right = 2,
	Up = 4,
	Down = 8,
	Tap = 16,
}
public class Swipe : MonoBehaviour {

	private static Swipe instance;
	public static Swipe Instance {get {return instance;}}

	public SwipeDirection Direction { set; get; }

	private Vector3 touchPosition;
	private float dragDistance = Screen.width * 10 / 100;

	private void Start(){
		instance = this;
	}
	void Update(){
		Direction = SwipeDirection.None;

		if (Input.GetMouseButtonDown (0)) {
			touchPosition = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp (0)) {
			Vector2 deltaSwipe = touchPosition - Input.mousePosition;
			if (Mathf.Abs (deltaSwipe.x) > dragDistance) {

				Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;

			} else if (Mathf.Abs (deltaSwipe.y) > dragDistance) {

				Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;

			} else {
				Direction = SwipeDirection.Tap;
			}
		}
	}

	public bool IsSwiping(SwipeDirection dir){
		return (Direction & dir) == dir;
	}

}
