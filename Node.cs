using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node 
{
    private bool _visited;
    private float _value;
    private List<Edge> _edges;
    private Edge _correctEdge;
    public GameObject _nodePos;

    public Node() {
        _visited = false;
        _value = 0;
        _edges = new List<Edge>();
        _nodePos = null;
    }

    public Node(float val, GameObject GO) {
        _visited = false;
        _value = val;
        _edges = new List<Edge>();
        _nodePos = GO;
    }

    public void AddEdge(ref Edge edge) //Set
    {
        _edges.Add(edge);
    }

    public void SetVisited(bool visited) {
        _visited = visited;
    }

    public bool GetVisited() {
        return _visited;
    }

    public List<Edge> GetEdges() {
        return _edges;
    }

    public void SetValue(float val) {
        _value = val;
    }

    public float GetValue() {
        return _value;
    }

    public void SetCorrectEdge(Edge edge) {
        _correctEdge = edge;
    }

    public Edge GetCorrectEdge() {
        return _correctEdge;
    }
}
