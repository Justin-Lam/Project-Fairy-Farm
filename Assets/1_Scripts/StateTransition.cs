// All state machine related scripts are based from http://www.gameaipro.com/GameAIPro3/GameAIPro3_Chapter12_A_Reusable_Light-Weight_Finite-State_Machine.pdf.

using UnityEngine;

// This is a base factory class
public abstract class StateTransition : MonoBehaviour
{
	protected GameObject owner;

	public StateTransition(GameObject owner)
	{
		this.owner = owner;
	}

	public abstract bool ToTransition();
}
