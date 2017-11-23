using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	public GameObject northStage;
	public GameObject southStage;
	public GameObject westStage;
	public GameObject eastStage;

	public Dictionary<Const.Stages, GameObject> stageObjs = new Dictionary<Const.Stages, GameObject>();


	void Awake() {
		stageObjs.Add(Const.Stages.north, northStage);
		stageObjs.Add(Const.Stages.south, southStage);
		stageObjs.Add(Const.Stages.west, westStage);
		stageObjs.Add(Const.Stages.east, eastStage);
	}
}
