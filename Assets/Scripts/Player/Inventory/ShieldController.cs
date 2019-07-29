using UnityEngine;

public class ShieldController : MonoBehaviour
{

	[SerializeField] private int countOfShields = 5;

	private void Start()
	{
		Messenger<int>.Broadcast(EGameEvents.EquipShield.ToString(), countOfShields);
	}
}
