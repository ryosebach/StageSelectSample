using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	public GameObject northPath;
	public GameObject southPath;
	public GameObject westPath;
	public GameObject eastPath;

	public Dictionary<Const.Direction, GameObject> dirPathObjs = new Dictionary<Const.Direction, GameObject>();


	void Awake() {
		dirPathObjs.Add(Const.Direction.north, northPath);
		dirPathObjs.Add(Const.Direction.south, southPath);
		dirPathObjs.Add(Const.Direction.west, westPath);
		dirPathObjs.Add(Const.Direction.east, eastPath);
	}
}
