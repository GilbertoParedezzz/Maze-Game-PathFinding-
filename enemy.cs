using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class enemy : MonoBehaviour {

    public bool GameOver;
    private GameObject target;
    [SerializeField]private float Speed;
    public List<Node> targets;
    private int currentTargetIndex;

    private GameManager manager;

    private void Start() {

        manager = FindObjectOfType<GameManager>();
        targets = new List<Node>();
        targets = manager.GetDjkPath();
        int a = targets.Count;
        Debug.Log(a);
        GameOver = false;
        currentTargetIndex = 0;

        if (manager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
            return;
        }

        if (targets == null || targets.Count == 0)
        {
            Debug.LogError("Path not found or empty.");
            return;
        }
    }

    private void Update() {
        if (targets != null && currentTargetIndex < targets.Count)
        {
            // Move towards the current target node
            GameObject target = targets[currentTargetIndex]._nodePos;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);
            //Debug.Log("moviendo a target");
            // Check if the enemy has reached the target node
            if (transform.position == target.transform.position)
            {
                currentTargetIndex++;

                // Check if the enemy reached the end of the path
                if (currentTargetIndex >= targets.Count)
                {
                    OnReachEndNode();
                }
            }
        }
    }

    //void OnTriggerEnter(Collider other) {
    //    if (other.CompareTag("EndNode"))
    //    {
    //        Debug.Log("Defeat");
    //        GameOver = true;
    //    }
    //}
    private void OnReachEndNode() {
        Debug.Log("Enemy has reached the end of the path.");
        GameOver = true;
    }
}
