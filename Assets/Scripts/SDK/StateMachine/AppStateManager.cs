using System;
using System.Linq;
using UnityEngine;

namespace WebClientSDK.Scripts.StateMachine {

	public sealed class AppStateManager : Singleton<AppStateManager> {
	public delegate void StateChange(States.StateApp previousState, States.StateApp newState);

	public event StateChange StateAppChanged;

	[SerializeField] GameObject[] States = null;
	protected override void Init() {
		foreach (GameObject stateObject in States) 
			stateObject.SetActive(true);
	}

	States.StateApp _currentlyApplicationState = global::States.StateApp.Base;

#if UNITY_EDITOR
	[SerializeField] bool isDebug = true;
	public bool IsDebug => isDebug;
#endif

	public States.StateApp LastState { get; private set; } = global::States.StateApp.Base;

	public States.StateApp CurrentlyApplicationState {
		get { return _currentlyApplicationState; }
		private set {
			LastState = _currentlyApplicationState;
			_currentlyApplicationState = value;
			OnStateAppChanged(LastState, _currentlyApplicationState);
		}
	}

public void SetState(States.StateApp state) {
#if UNITY_EDITOR
	if (CurrentlyApplicationState == state)
		Debug.LogError("error: newState = currState");
#endif
	
		CurrentlyApplicationState = state;
}

	public void SetState(int state) {
		if (StateExist(state)) {
			CurrentlyApplicationState = (States.StateApp) state;
		}
	}

	static bool StateExist(int state) {
		string nameState = ((States.StateApp) state).ToString();
		return Enum.GetNames(typeof(States.StateApp)).Contains(nameState);
	}

	void OnStateAppChanged(States.StateApp previousState, States.StateApp newSate) {
		StateAppChanged?.Invoke(previousState, newSate);

#if UNITY_EDITOR
		if (IsDebug)
			Debug.Log("previousState: " + previousState + "; newsSate: " + newSate);
#endif
	}
}

}