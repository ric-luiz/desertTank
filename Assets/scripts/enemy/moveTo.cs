using UnityEngine;
using System.Collections;

public class moveTo : MonoBehaviour {
	private Transform goal;
	private NavMeshAgent nav ;

	void Start () {
		goal = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
		nav.updatePosition = false;
	}

	void FixedUpdate(){
		if(goal != null)
			nav.SetDestination(goal.position);
	}

	public Transform getGoal(){
		return goal;
	}
}
