using UnityEngine;

public class HitByBigExplosion : MonoBehaviour
{

	private Transform _transform;
	
	private void Awake()
	{
		Messenger<Vector3, float, float>.AddListener(EGameEvents.BigExplosion.ToString(), OnBigExplosion);
		Messenger.AddListener(EGameEvents.Respanw.ToString(), RespawnObject);
	}

	private void Start()
	{
		_transform = transform;
	}

	private void OnDestroy()
	{
		Messenger<Vector3, float, float>.RemoveListener(EGameEvents.BigExplosion.ToString(), OnBigExplosion);
		Messenger.RemoveListener(EGameEvents.Respanw.ToString(), RespawnObject);

	}
	
	private void OnBigExplosion(Vector3 p, float deadDistance, float force)
	{
		if ((p - _transform.position).sqrMagnitude <= deadDistance)
		{
			gameObject.SetActive(false);
			
			//TODO then we will call animation here ...
		}
	}
	
	private void RespawnObject()
	{
		gameObject.SetActive(true);
	}
}
