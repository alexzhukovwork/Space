using UnityEngine;

namespace WebClientSDK.Scripts.StateMachine {

public abstract class UserOfStateMachine : BaseUserOfStateMachine {
	protected virtual void Start() {
		AppStateManager.Instance.StateAppChanged += SetActive;

#if UNITY_EDITOR
		if (AppStateManager.Instance.IsDebug)
			Debug.Log(gameObject.name + " подписался на StateAppChanged");
#endif
	}

	protected override void SetActive(States.StateApp previousState, States.StateApp newState) {
		
		States.StateApp mainState = GetMainState();

		if (newState == mainState)
			OnGoingIntoState();
		else if (previousState == mainState)
			OnPassingFromState();
	}

	/// <summary>
	///     <para>При каком состоянии нужно вызвать OnPassingFromState()</para>
	///     <para>Пример: return ApplicationStateManager.StateApp.StateName</para>
	/// </summary>
	protected abstract States.StateApp GetMainState();
}

}