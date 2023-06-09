using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContreller : MonoBehaviour
{
	[Header("Prefabs")]
	public GameObject zombie1;
	public GameObject zombie2;
    
	[Header("Areas")]
	public SpawnArea horde1;
	public SpawnArea horde2;

	[Header("Controller")]
	public int zombieQtyHord1 = 40;
	public int zombieQtyHord2 = 80;

	private void Start()
	{
		SpawnHord1 ();
		SpawnHord2 ();
	}
	void SpawnHord1()
	{
		for(int i = 0; i < zombieQtyHord1; i++)
		{
			var randomPos = RandomPositionInBounds(horde1.areRadius.GetComponent<Collider>().bounds);
			Instantiate(zombie1, randomPos, transform.rotation);
		}

	}
	void SpawnHord2()
	{
		for(int i = 0; i < zombieQtyHord2; i++)
		{
			var randomPos = RandomPositionInBounds(horde2.areRadius.GetComponent<Collider>().bounds);
			Instantiate(zombie2, randomPos, transform.rotation);
		}	
	}
	public Vector3 RandomPositionInBounds(Bounds bounds)
	{
		return new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			Random.Range(bounds.min.y, bounds.max.y),
			Random.Range(bounds.min.z, bounds.max.z)
		);
	}


}