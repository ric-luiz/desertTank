using UnityEngine;
using System.Collections;

public class moveTo : MonoBehaviour {
	public Transform goal;
	private NavMeshAgent nav ;

	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		nav.updatePosition = false;
	}

	void FixedUpdate(){
		if(goal != null)
			nav.SetDestination(goal.position);
	}
}
