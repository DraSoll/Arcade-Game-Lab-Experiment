using UnityEngine;
using System.Collections;


public class OnKeyAnimate : MonoBehaviour 
{
	public KeyCode key;					// the key that I'm looking for
	[Tooltip("Object that will play animation. If left null, will attempt to play animation on THIS object")]
	public GameObject animationTarget;	// if null, animate me
	[Tooltip("Exact name of the animation")]
	public string animationName;
	[Tooltip("Animation will only be triggered by button press once")]
	public bool singleUse = false;		// if true, only play the animation once; if false, many times

	private bool done = false;			// has it happened yet?


	void Update ()
	{
		// was the key pressed this frame?
		if (!Input.GetKeyDown (key)) return;

		// check if this should happen only once, and if it already happened
		if (singleUse && done) return;

		// animate something
		GameObject toAnimate = animationTarget ? animationTarget : gameObject;
		toAnimate.GetComponent<Animator>().Play (animationName);
		done = true;
	}
}
