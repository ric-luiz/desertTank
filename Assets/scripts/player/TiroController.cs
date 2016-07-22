using UnityEngine;
using System.Collections;

public class TiroController : Tiro {
	protected override void Start ()
	{
		InvokeRepeating("retirarExplosoes",5.0f,5.0f);	//Repete a função a cada 5 segundos
		base.Start ();
	}
}
