// All state machine related scripts are based from http://www.gameaipro.com/GameAIPro3/GameAIPro3_Chapter12_A_Reusable_Light-Weight_Finite-State_Machine.pdf.

using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	/*
	 *	The goal of this state machine architecture
	 *	Is that the states are completely decoupled from each other
	 *	Ideally, the state machine only cares about the states
	 *	And it never has to know which specific state a character is in
	 */

	/*
	 *	(StateTransition, State) = TransitionStatePair
	 *	List<TransitionStatePair> = Transitions
	 *	Dictionary<State, Transitions> = TransitionDictionary
	 *	
	 *	transitions_dict holds the network of transitions for this state machine
	 *	And defines how the game object will move from state to state
	 *	These are typically read from data and built at initialization time
	 *	
	 *	Having no transitions for a state is perfectly valid
	 *	Ex. no transitions out of the death state
	 *	Ex. a state can only be changed manually via SetState()
	 */
	Dictionary<State, List<(StateTransition, State)>> transitions_dict;
	State currentState;

	public void SetState(State state)
	{
		currentState = state;
	}

	void Update()
	{
		/*
		 *	Check if the current state has any transitions
		 *	If there are, walk through the list and see if it's time to move to another state
		 *	If it is then transition
		 *	
		 *	If there currently is a state, call its OnUpdate()
		 */
		
		if (transitions_dict.ContainsKey(currentState))
		{
			List<(StateTransition, State)> transitions = transitions_dict[currentState];
			foreach ((StateTransition, State) transitionStatePair in transitions)
			{
				StateTransition stateTransition = transitionStatePair.Item1;
				if (stateTransition.ToTransition())
				{
					State state = transitionStatePair.Item2;
					SetState(state);
					break;
				}
			}
		}

		if (currentState) currentState.OnUpdate(Time.deltaTime);
	}
}
