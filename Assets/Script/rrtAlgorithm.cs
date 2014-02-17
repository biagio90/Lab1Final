﻿using UnityEngine;
using System.Collections;

public class rrtAlgorithm {

	private float y = 0.0f;
	UnityRandom urand = new UnityRandom(112233);

	public ArrayList findBidirectionalPath (Vector3 source, Vector3 dest, int numPoints, int dim) {
		y = source.y;

		rrTree treeForward = new rrTree ();
		rrtNode s = new rrtNode (source, null);
		treeForward.addNode (s);

		rrTree treeBackward = new rrTree ();
		rrtNode d = new rrtNode (dest, null);
		treeBackward.addNode (d);

		bool end = false;

		// try to merge the two tree
		ArrayList path = treeForward.Merge (treeBackward);
		if (path != null ) return path;
		
		ArrayList path2 = treeBackward.Merge (treeForward);
		if (path2 != null ) return path2;

		for (int i=0; i<numPoints && !end; i++) {
			//forward
			addRandomNode(source, dest, treeForward, dim);
			// try to merge the two tree
			ArrayList path3 = treeForward.Merge (treeBackward);
			if (path3 != null ) return path3;

			//backward
			addRandomNode(dest, source, treeBackward, dim);
			// try to merge the two tree
			ArrayList path4 = treeBackward.Merge (treeForward);
			if (path4 != null ) {path4.Reverse(); return path4;}

		}

		return null;
	}

	private void addRandomNode (Vector3 source, Vector3 dest, rrTree tree, int dim) {
		//Vector3 newPoint = new Vector3 (myRnd (-dim, dim), 0, myRnd (-dim, dim));
		//Vector3 newPoint = new Vector3 ( myRnd (tree.source.point.x, 1, dim), y, myRnd (tree.source.point.z, 1, dim));
		Vector3 newPoint = myRndVector (source, dest, dim, 30f, 0.3f);

		Debug.Log ("Rand point: " + newPoint);

		rrtNode point = tree.findClosestNode (newPoint);
		if ( point != null ) {
			//if it is possible to reach the point from the previous point
			//add the connection
			rrtNode p2 = new rrtNode(newPoint, point);
			point.addConnection(p2);
			tree.addNode (p2);
		}
	}

	public ArrayList findPath (Vector3 source, Vector3 dest, int numPoints, int dim) {

		rrTree tree = new rrTree ();
		rrtNode s = new rrtNode (source, null);

		bool end = false;

		tree.addNode (s);
		rrtNode lastPoint = s;
		for (int i=0; i<numPoints && !end; i++) {
			if (freePath (lastPoint.point, dest) ) {
				rrtNode d = new rrtNode (dest, lastPoint);
				lastPoint.addConnection(d);
				tree.addNode (d);
				//Debug.Log ("Point: "+point.point);

				end = true;
			} else {
				//pick up a random point
				//Vector3 newPoint = new Vector3 (myRnd (-dim, dim), 0, myRnd (-dim, dim));
				//Vector3 newPoint = new Vector3 ( myRnd (s.point.x, 1, dim), y, myRnd (s.point.z, 1, dim));
				Vector3 newPoint = myRndVector (source, dest, dim, 45f, 0.5f);

				rrtNode point = tree.findClosestNode (newPoint);
				if ( point != null ) {
					//if it is possible to reach the point from the previous point
					//add the connection
					rrtNode p2 = new rrtNode(newPoint, point);
					point.addConnection(p2);
					tree.addNode (p2);

					//from the next iteration consider the new point
					lastPoint = p2;
				}
			}

		}

		return tree.getPath();
	}

	private float myRnd (float point, float temp, float dim) {
		double p = point;
		float val = urand.Value (UnityRandom.Normalization.STDNORMAL, temp);
		return ((val*2*dim)-dim)+point;
	}

	private Vector3 myRndVector(Vector3 source, Vector3 dest, float dim, float angle, float prob) {
		Vector3 dir = source - dest;
		bool find = false;
		Vector3 p = Vector3.zero;
		while (!find) {
			p = new Vector3(Random.Range (-dim, dim), y, Random.Range (-dim, dim));

			float a = Vector3.Angle(dir, p-source);
			if ( (-angle < a && a < angle) || Random.Range (0, 1) <= prob ){ 
				find = true;
			}

		}

		return p;
	}

	private float myRnd(float min, float max) {
		float n = Random.Range (min, max);
		return n;
		//int n = Random.Range (min*10, max*10);
		//return n / 10;
	}

	static public bool freePath (Vector3 p1, Vector3 p2) {
		Vector3 direction = (p2 - p1).normalized;
		float sight = (p2 - p1).magnitude;
		
		Ray ray = new Ray(p1, direction);
		RaycastHit hit = new RaycastHit ();
		bool collision = true;

		if (Physics.Raycast (ray, out hit, sight)) {
			collision = false;
			Debug.Log("Collision: "+hit.collider.name);
		}
		return collision;
	}
}
