using UnityEngine;
using System.Collections;

public class rrTree {

	private ArrayList _nodes = new ArrayList();
	//private ArrayList connection = new ArrayList();
	public rrtNode source;
	public rrtNode last;

	public void addNode( rrtNode node) 
	{
		if (nodes.Count == 0 )
			source = node;

		nodes.Add (node);
		last = node;
	}

	//Try to merge the last node of the tree with the first possible node of the OTHER tree
	public ArrayList Merge (rrTree other) {

		ArrayList nodeList = other.nodes;
		bool find = false;
		rrtNode conn = null;
		foreach (rrtNode checkNode in nodeList) {
			if (freePath (last, checkNode)) {
				conn = checkNode;
				find = true;
				break;
			}
		}

		if (!find)
			return null;

		ArrayList fwdPath = getPath ();
		ArrayList bwdPath = other.getPath (conn);
		bwdPath.Reverse ();
		foreach (Vector3 v in bwdPath) {
			fwdPath.Add(v);
		}

		return fwdPath;
	}

	private bool freePath (rrtNode from, rrtNode to) {
		return rrtAlgorithm.freePath (from.point, to.point);
	}

	public ArrayList getPath()
	{
		ArrayList path = new ArrayList ();
		rrtNode node = last;

		path.Add (node.point);
		while (node.back != null) {
			node = node.back;
			path.Add (node.point);
		}
		path.Reverse ();
		return path;
	}

	public ArrayList getPath(rrtNode node)
	{
		if (node == null) return null;
		ArrayList path = new ArrayList ();
		
		path.Add (node.point);
		while (node.back != null) {
			node = node.back;
			path.Add (node.point);
		}
		path.Reverse ();
		return path;
	}

	public rrtNode findClosestNode (Vector3 point) {
		ArrayList reachble = getAllReachbleNode (point);
		
		float min = 100000;
		rrtNode closest = null;
		foreach (rrtNode node in reachble) {
			float d = Vector3.Distance(node.point, point);
			if (d < min) {
				min = d;
				closest = node;
			}
		}

		return closest;
	}

	public ArrayList getAllReachbleNode (Vector3 point) {
		ArrayList reachble = new ArrayList ();
		
		foreach (rrtNode node in nodes) {
			if ( rrtAlgorithm.freePath(node.point, point) ) {
				reachble.Add(node);
			}
		}
		return reachble;
	}

	public void printTree() {
		/*for (int i = 0; i<path.Count-1; i++) {
			Debug.Log ();
		}*/
	}

	public ArrayList nodes
	{
		//set the person name
		set { this._nodes = value; }
		//get the person name 
		get { return this._nodes; }
	}
}
