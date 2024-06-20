using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge 
{
    private Node _fromNode;
    private Node _toNode;
    private float _weight;
    private bool _visited;

    public Edge(ref Node one, ref Node two, float weight) {
        _fromNode = one;
        _toNode = two;
        _weight = weight;
        _visited = false;
    }

    public Node GetFromNode() {
        return _fromNode;
    }

    public void SetFromNode(ref Node node1) {
        _fromNode = node1;
    }

    public Node GetToNode() {
        return _toNode;
    }

    public void SetToNode(ref Node node2) {
        _toNode = node2;
    }

    public void SetWeight(float weight) {
        _weight = weight;
    }

    public float GetWeight() {
        return _weight;
    }

    public bool GetVisited() {
        return _visited;
    }

    public void SetVisited(bool visited) {
        _visited = visited;
    }
}
