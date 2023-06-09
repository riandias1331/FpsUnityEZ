using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnArea : MonoBehaviour 
{
	public BoxCollider areRadius;

    private void Start()
    {
		areRadius = GetComponent<BoxCollider> ();	
    }	
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube (transform.position, areRadius.size);
	}
}