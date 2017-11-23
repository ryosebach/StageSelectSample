using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Path : MonoBehaviour {

	[SerializeField] Transform[] pointsTransform;
	[SerializeField] Transform startPoint;
	[SerializeField] Transform endPoint;

	public Vector3[] GetPath(Transform startPoint) {
		List<Vector3> returnList = new List<Vector3>();

		if (startPoint == this.startPoint) {
			returnList.Add(this.startPoint.position);
			pointsTransform.Select(x => x.position).ToList().ForEach(x => returnList.Add(x));
			returnList.Add(this.endPoint.position);
		} else {
			returnList.Add(this.endPoint.position);
			pointsTransform.Select(x => x.position).Reverse().ToList().ForEach(x => returnList.Add(x));
			returnList.Add(this.startPoint.position);
		}
		return returnList.ToArray();
	}

	public GameObject GetEndPosition(Transform startPoint) {
		if (startPoint == this.startPoint) {
			return endPoint.gameObject;
		} else {
			return this.startPoint.gameObject;
		}
	}
}
