using UnityEngine;

namespace WebClientSDK.Scripts.StateMachine {

public abstract class BaseUserOfStateMachine : MonoBehaviour {
    //вынес это сюда на слючай если понадобится создать объект зависимый от двух состояний MultistateUserOfStateMachine : BaseUserOfStateMachine
    //сработает при переходе на другую сцену

    protected virtual void OnDisable() {
        AppStateManager.Instance.StateAppChanged -= SetActive;
    }

    protected abstract void SetActive(States.StateApp stateApp,
                                      States.StateApp app);

    protected virtual void OnGoingIntoState() {
    }

    protected virtual void OnPassingFromState() {
    }
}

}