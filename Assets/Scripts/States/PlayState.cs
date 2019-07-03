using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebClientSDK.Scripts.StateMachine;

public class PlayState : UserOfStateMachine
{

	protected override States.StateApp GetMainState()
	{
		return States.StateApp.Play;
	}

	protected override void OnGoingIntoState()
	{
		base.OnGoingIntoState();


		Debug.Log("Going");
	}

	protected override void OnPassingFromState()
	{
		base.OnPassingFromState();
		Debug.Log("Passing");
	}
}
