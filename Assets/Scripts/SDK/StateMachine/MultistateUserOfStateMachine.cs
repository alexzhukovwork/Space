using System.Collections.Generic;
using UnityEngine;

namespace WebClientSDK.Scripts.StateMachine {

public abstract class MultistateUserOfStateMachine : BaseUserOfStateMachine {
    [Header("В каких состояниях объект активен: ")] [SerializeField]
    protected List<States.StateApp> TargetStates;

    protected virtual void Start() {
        if (TargetStates.Count > 0)
            AppStateManager.Instance.StateAppChanged += SetActive;
        else
            Debug.LogError("У объекта " + gameObject.name + " не перечислены состояния при которых он активен");
    }

    protected override void SetActive(States.StateApp previousState, States.StateApp newState) {
        if (TargetStates.Contains(newState))
            OnGoingIntoState(previousState, newState);
        else
            OnPassingFromState(previousState, newState);
    }

    protected virtual void OnGoingIntoState(States.StateApp previousState, States.StateApp newState) {
    }

    protected virtual void OnPassingFromState(States.StateApp previousState, States.StateApp newState) {
    }
}

}