// All state machine related scripts are based from http://www.gameaipro.com/GameAIPro3/GameAIPro3_Chapter12_A_Reusable_Light-Weight_Finite-State_Machine.pdf.

using UnityEngine;

// This is a factory for actual states
public abstract class State : MonoBehaviour
{
	protected GameObject owner;

	public State(GameObject owner)
	{
		this.owner = owner;
	}

	// Since State instances live for the entire lifetime of the state machine
	// OnEnter() or OnExit() need to handle resetting the state
	public abstract void OnEnter();
	public abstract void OnExit();
	public abstract void OnUpdate(float deltaTime);
}
