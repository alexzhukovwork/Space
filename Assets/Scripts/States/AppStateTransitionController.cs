using System;
using UnityEngine;
using WebClientSDK.Scripts.StateMachine;
using static States;

public class AppStateTransitionController : MonoBehaviour {
	
	private void Awake () {
		Messenger.AddListener(StateEvents.GO_TO_MENU, OnMenu);
		Messenger.AddListener(StateEvents.GO_TO_PLAY, OnPlay);
		Messenger.AddListener(StateEvents.GO_TO_BASE, OnBase);
	}

	private void OnDestroy()
	{
		Messenger.RemoveListener(StateEvents.GO_TO_MENU, OnMenu);
		Messenger.RemoveListener(StateEvents.GO_TO_PLAY, OnPlay);		
		Messenger.RemoveListener(StateEvents.GO_TO_BASE, OnBase);
	}

	private void Start()
	{
		OnPlay();
	}

	private void OnBase()
	{
		AppStateManager.Instance.SetState(StateApp.Base);
	}
	
	private void OnMenu() {
		AppStateManager.Instance.SetState(StateApp.Menu);
	}
	
	private void OnPlay() {
		AppStateManager.Instance.SetState(StateApp.Play);
	}

	
}
