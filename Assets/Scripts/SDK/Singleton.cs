using UnityEngine;

namespace WebClientSDK.Scripts {

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {
	public static T Instance { get; private set; }

	protected virtual void Awake() {
		if (Instance == null) {
			Instance = (T) this;
			Init();
		}
		else
			Destroy(this);
	}

	/// <summary>
	/// Вызывается в конце Singleton.Awake();
	/// </summary>
	protected virtual void Init() {
	}
}

}