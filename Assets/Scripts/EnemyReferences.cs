using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DissalowMultipleComponent]
public class EnemyReferences : MonoBehaviour
{
	[HideInInspector] public NavMeshAgent navMeshagent;
    [HideInInspector] public Animator animator;

	public Transform target;
	public EnemyReferences enemyReferences;
	private float pathUpdateDeadLine; 
	private float shootingDistance;

    [Header(" Stats")]

	public float pathUpdateDelay = 0.2f;

    private void Awake(){
		navMeshagent = GetComponent<navMeshagent>();
		animator =	GetComponent<Animator>();
    }	

	private void UpdatePath()
	{
		if(Time.time >= pathUpdateDeadLine)
		{
			Debug.Log("Updating Path");
			pathUpdateDeadLine = Time.time + EnemyReferences.pathUpdateDelay;
			enemyreferences.navMeshagent.SetDestination(enemyReferences.target.position);
        }
    }
}
