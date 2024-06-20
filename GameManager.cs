using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour {

    private int Diff;
    [SerializeField] private GameObject Agnt;
    [SerializeField] private GameObject[] nodes;
    public GameObject MKey1;
    public GameObject MKey2;
    Vector3 key1;
    Vector3 key2;

    public List<Node> shortestPathDjk;
    public List<Node> shortestPathAst;

    float E1_2  = 0;
    float E2_3  = 0;
    float E2_4  = 0;
    float E3_7  = 0;
    float E4_5  = 0;
    float E4_6  = 0;
    float E7_8  = 0;
    float E8_9  = 0;
    float E9_6  = 0;
    float E6_10 = 0;

    float E10_11 = 0;
    float E10_12 = 0;
    float E10_14 = 0;
    float E12_13 = 0;
    float E14_15 = 0;
    float E14_16 = 0;
    float E14_20 = 0;
    float E16_17 = 0;
    float E15_23 = 0;
    float E13_14 = 0;
    float E13_23 = 0;
    float E16_18 = 0;

    float E20_21 = 0;
    float E20_24 = 0;
    float E23_22 = 0;
    float E21_27 = 0;
    float E22_27 = 0;
    float E24_25 = 0;
    float E25_26 = 0;
    float E27_26 = 0;

    float E26_28 = 0;
    float E28_29 = 0;
    float E30_28 = 0;
    float E29_31 = 0;
    float E31_30 = 0;
    float E30_32 = 0;
    float E33_31 = 0;
    float E32_18 = 0;
    float E18_30 = 0;

    float E31_19 = 0;
    float E19_33 = 0;
    float E19_34 = 0;
    float E18_19 = 0;
    float E18_34 = 0;

    float E34_35 = 0;
    float E35_36 = 0;
    float E35_37 = 0;
    float E37_38 = 0;
    float E38_39 = 0;
    float E35_40 = 0;
    float  E40_B = 0;

    // Start is called before the first frame update
    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
        int index1 = UnityEngine.Random.Range(10, 40);
        int index2 = UnityEngine.Random.Range(10, 40);

        key1 = nodes[index1].transform.position;
        key2 = nodes[index2].transform.position;

        shortestPathDjk = new List<Node>();
        shortestPathAst = new List<Node>();

        nodeDist();

    }

    public void difficulty1() {
        Debug.Log("dificultad 1");
        Diff = 1;
        Initialize();
        MKey1.transform.position = key1;
        MKey2.transform.position = key2;

        MKey1.SetActive(true);
        MKey2.SetActive(true);

    }

    public void difficulty2() {
        Debug.Log("dificultad 2");
        Diff = 2;
        Initialize();
        MKey1.transform.position = key1;
        MKey2.transform.position = key2;

        MKey1.SetActive(true);
        MKey2.SetActive(true);
    }

    private void nodeDist() {
        E1_2  = Vector3.Distance(nodes[0].transform.position, nodes[1].transform.position);
        E2_3  = Vector3.Distance(nodes[1].transform.position, nodes[2].transform.position);
        E2_4  = Vector3.Distance(nodes[1].transform.position, nodes[3].transform.position);
        E3_7  = Vector3.Distance(nodes[2].transform.position, nodes[6].transform.position);
        E4_5  = Vector3.Distance(nodes[3].transform.position, nodes[4].transform.position);
        E4_6  = Vector3.Distance(nodes[3].transform.position, nodes[5].transform.position);
        E7_8  = Vector3.Distance(nodes[6].transform.position, nodes[7].transform.position);
        E8_9  = Vector3.Distance(nodes[7].transform.position, nodes[8].transform.position);
        E9_6  = Vector3.Distance(nodes[8].transform.position, nodes[5].transform.position);
        E6_10 = Vector3.Distance(nodes[5].transform.position, nodes[9].transform.position);

        E10_11 =  Vector3.Distance(nodes[9].transform.position, nodes[10].transform.position);
        E10_12 =  Vector3.Distance(nodes[9].transform.position, nodes[11].transform.position);
        E10_14 =  Vector3.Distance(nodes[9].transform.position, nodes[13].transform.position);
        E12_13 = Vector3.Distance(nodes[11].transform.position, nodes[12].transform.position);
        E14_15 = Vector3.Distance(nodes[13].transform.position, nodes[14].transform.position);
        E14_16 = Vector3.Distance(nodes[13].transform.position, nodes[15].transform.position);
        E14_20 = Vector3.Distance(nodes[13].transform.position, nodes[19].transform.position);
        E16_17 = Vector3.Distance(nodes[15].transform.position, nodes[16].transform.position);
        E15_23 = Vector3.Distance(nodes[14].transform.position, nodes[22].transform.position);
        E13_14 = Vector3.Distance(nodes[12].transform.position, nodes[13].transform.position);
        E13_23 = Vector3.Distance(nodes[12].transform.position, nodes[22].transform.position);
        E16_18 = Vector3.Distance(nodes[15].transform.position, nodes[17].transform.position);

        E20_21 = Vector3.Distance(nodes[19].transform.position, nodes[20].transform.position);
        E20_24 = Vector3.Distance(nodes[19].transform.position, nodes[23].transform.position);
        E23_22 = Vector3.Distance(nodes[22].transform.position, nodes[21].transform.position);
        E21_27 = Vector3.Distance(nodes[20].transform.position, nodes[26].transform.position);
        E22_27 = Vector3.Distance(nodes[21].transform.position, nodes[26].transform.position);
        E24_25 = Vector3.Distance(nodes[23].transform.position, nodes[24].transform.position);
        E25_26 = Vector3.Distance(nodes[24].transform.position, nodes[25].transform.position);
        E27_26 = Vector3.Distance(nodes[26].transform.position, nodes[25].transform.position);

        E26_28 = Vector3.Distance(nodes[25].transform.position, nodes[27].transform.position);
        E28_29 = Vector3.Distance(nodes[27].transform.position, nodes[28].transform.position);
        E30_28 = Vector3.Distance(nodes[27].transform.position, nodes[29].transform.position);
        E29_31 = Vector3.Distance(nodes[28].transform.position, nodes[30].transform.position);
        E31_30 = Vector3.Distance(nodes[29].transform.position, nodes[30].transform.position);
        E30_32 = Vector3.Distance(nodes[29].transform.position, nodes[31].transform.position);
        E33_31 = Vector3.Distance(nodes[30].transform.position, nodes[32].transform.position);
        E32_18 = Vector3.Distance(nodes[31].transform.position, nodes[17].transform.position);
        E18_30 = Vector3.Distance(nodes[17].transform.position, nodes[29].transform.position);

        E31_19 = Vector3.Distance(nodes[30].transform.position, nodes[18].transform.position);
        E19_33 = Vector3.Distance(nodes[18].transform.position, nodes[32].transform.position);
        E19_34 = Vector3.Distance(nodes[18].transform.position, nodes[33].transform.position);
        E18_19 = Vector3.Distance(nodes[18].transform.position, nodes[17].transform.position);
        E18_34 = Vector3.Distance(nodes[17].transform.position, nodes[33].transform.position);

        E34_35 = Vector3.Distance(nodes[33].transform.position, nodes[34].transform.position);
        E35_36 = Vector3.Distance(nodes[34].transform.position, nodes[35].transform.position);
        E35_37 = Vector3.Distance(nodes[34].transform.position, nodes[36].transform.position);
        E37_38 = Vector3.Distance(nodes[36].transform.position, nodes[37].transform.position);
        E38_39 = Vector3.Distance(nodes[37].transform.position, nodes[38].transform.position);
        E35_40 = Vector3.Distance(nodes[34].transform.position, nodes[39].transform.position);
        E40_B  = Vector3.Distance(nodes[39].transform.position, nodes[40].transform.position);
    }

    private void Initialize() {

        //creacion  de nodos
        Node _node1  = new Node(1, nodes[0]);
        Node _node2  = new Node(1, nodes[1]);
        Node _node3  = new Node(1, nodes[2]);
        Node _node4  = new Node(1, nodes[3]);
        Node _node5  = new Node(1, nodes[4]);
        Node _node6  = new Node(1, nodes[5]);
        Node _node7  = new Node(1, nodes[6]);
        Node _node8  = new Node(1, nodes[7]);
        Node _node9  = new Node(1, nodes[8]);
        Node _node10 = new Node(1, nodes[9]);
        Node _node11 = new Node(1, nodes[10]);
        Node _node12 = new Node(1, nodes[11]);
        Node _node13 = new Node(1, nodes[12]);
        Node _node14 = new Node(1, nodes[13]);
        Node _node15 = new Node(1, nodes[14]);
        Node _node16 = new Node(1, nodes[15]);
        Node _node17 = new Node(1, nodes[16]);
        Node _node18 = new Node(1, nodes[17]);
        Node _node19 = new Node(1, nodes[18]);
        Node _node20 = new Node(1, nodes[19]);
        Node _node21 = new Node(1, nodes[20]);
        Node _node22 = new Node(1, nodes[21]);
        Node _node23 = new Node(1, nodes[22]);
        Node _node24 = new Node(1, nodes[23]);
        Node _node25 = new Node(1, nodes[24]);
        Node _node26 = new Node(1, nodes[25]);
        Node _node27 = new Node(1, nodes[26]);
        Node _node28 = new Node(1, nodes[27]);
        Node _node29 = new Node(1, nodes[28]);
        Node _node30 = new Node(1, nodes[29]);
        Node _node31 = new Node(1, nodes[30]);
        Node _node32 = new Node(1, nodes[31]);
        Node _node33 = new Node(1, nodes[32]);
        Node _node34 = new Node(1, nodes[33]);
        Node _node35 = new Node(1, nodes[34]);
        Node _node36 = new Node(1, nodes[35]);
        Node _node37 = new Node(1, nodes[36]);
        Node _node38 = new Node(1, nodes[37]);
        Node _node39 = new Node(1, nodes[38]);
        Node _node40 = new Node(1, nodes[39]);
        Node _nodeB  = new Node(1, nodes[40]);

        //Creacion de aristas

        Edge edge12 = new Edge(ref _node1, ref _node2,E1_2);
        _node1.AddEdge(ref edge12);
        _node2.AddEdge(ref edge12);

        Edge edge23 = new Edge(ref _node2, ref _node3, E2_3);
        _node2.AddEdge(ref edge23);
        _node3.AddEdge(ref edge23);

        Edge edge24 = new Edge(ref _node2, ref _node4, E2_4);
        _node2.AddEdge(ref edge24);
        _node4.AddEdge(ref edge24);

        Edge edge37 = new Edge(ref _node3, ref _node7, E3_7);
        _node3.AddEdge(ref edge37);
        _node7.AddEdge(ref edge37);

        Edge edge45 = new Edge(ref _node4, ref _node5, E4_5);
        _node4.AddEdge(ref edge45);
        _node5.AddEdge(ref edge45);

        Edge edge46 = new Edge(ref _node4, ref _node6, E4_6);
        _node4.AddEdge(ref edge46);
        _node6.AddEdge(ref edge46);

        Edge edge78 = new Edge(ref _node7, ref _node8, E7_8);
        _node7.AddEdge(ref edge78);
        _node8.AddEdge(ref edge78);

        Edge edge89 = new Edge(ref _node8, ref _node9, E8_9);
        _node8.AddEdge(ref edge89);
        _node9.AddEdge(ref edge89);

        Edge edge96 = new Edge(ref _node9, ref _node6, E9_6);
        _node6.AddEdge(ref edge96);
        _node9.AddEdge(ref edge96);

        Edge edge6_10 = new Edge(ref _node6, ref _node10, E6_10);
        _node6.AddEdge(ref edge6_10);
        _node10.AddEdge(ref edge6_10);

        //*************************//
        
        Edge edge10_11 = new Edge(ref _node10, ref _node11, E10_11);
        _node10.AddEdge(ref edge10_11);
        _node11.AddEdge(ref edge10_11);

        Edge edge10_12 = new Edge(ref _node10, ref _node12, E10_12);
        _node10.AddEdge(ref edge10_12);
        _node12.AddEdge(ref edge10_12);

        Edge edge10_14 = new Edge(ref _node10, ref _node14, E10_14);
        _node10.AddEdge(ref edge10_14);
        _node14.AddEdge(ref edge10_14);

        Edge edge12_13 = new Edge(ref _node12, ref _node13, E12_13);
        _node12.AddEdge(ref edge12_13);
        _node13.AddEdge(ref edge12_13);

        Edge edge14_15 = new Edge(ref _node14, ref _node15, E14_15);
        _node14.AddEdge(ref edge14_15);
        _node15.AddEdge(ref edge14_15);

        Edge edge14_16 = new Edge(ref _node14, ref _node16, E14_16);
        _node14.AddEdge(ref edge14_16);
        _node16.AddEdge(ref edge14_16);

        Edge edge14_20 = new Edge(ref _node14, ref _node20, E14_20);
        _node14.AddEdge(ref edge14_20);
        _node20.AddEdge(ref edge14_20);

        Edge edge16_17 = new Edge(ref _node16, ref _node17, E16_17);
        _node16.AddEdge(ref edge16_17);
        _node17.AddEdge(ref edge16_17);

        Edge edge15_23 = new Edge(ref _node15, ref _node23, E15_23);
        _node15.AddEdge(ref edge15_23);
        _node23.AddEdge(ref edge15_23);

        Edge edge13_14 = new Edge(ref _node15, ref _node13, E13_14);
        _node13.AddEdge(ref edge13_14);
        _node14.AddEdge(ref edge13_14);

        Edge edge13_23 = new Edge(ref _node13, ref _node23, E13_23);
        _node13.AddEdge(ref edge13_23);
        _node23.AddEdge(ref edge13_23);

        Edge edge16_18 = new Edge(ref _node16, ref _node18, E16_18);
        _node16.AddEdge(ref edge16_18);
        _node18.AddEdge(ref edge16_18);

        //**************************//

        Edge edge20_21 = new Edge(ref _node20, ref _node21, E20_21);
        _node20.AddEdge(ref edge20_21);
        _node21.AddEdge(ref edge20_21);

        Edge edge20_24 = new Edge(ref _node20, ref _node24, E20_24);
        _node20.AddEdge(ref edge20_24);
        _node24.AddEdge(ref edge20_24);

        Edge edge23_22 = new Edge(ref _node23, ref _node22, E23_22);
        _node23.AddEdge(ref edge23_22);
        _node22.AddEdge(ref edge23_22);

        Edge edge21_27 = new Edge(ref _node21, ref _node27, E21_27);
        _node21.AddEdge(ref edge21_27);
        _node27.AddEdge(ref edge21_27);

        Edge edge22_27 = new Edge(ref _node22, ref _node27, E22_27);
        _node22.AddEdge(ref edge22_27);
        _node27.AddEdge(ref edge22_27);

        Edge edge24_25 = new Edge(ref _node24, ref _node25, E24_25);
        _node24.AddEdge(ref edge24_25);
        _node25.AddEdge(ref edge24_25);

        Edge edge25_26 = new Edge(ref _node25, ref _node26, E25_26);
        _node25.AddEdge(ref edge25_26);
        _node26.AddEdge(ref edge25_26);

        Edge edge27_26 = new Edge(ref _node27, ref _node26, E27_26);
        _node27.AddEdge(ref edge27_26);
        _node26.AddEdge(ref edge27_26);

        //**************************//

        Edge edge26_28 = new Edge(ref _node26, ref _node28, E26_28);
        _node26.AddEdge(ref edge26_28);
        _node28.AddEdge(ref edge26_28);

        Edge edge28_29 = new Edge(ref _node28, ref _node29, E28_29);
        _node28.AddEdge(ref edge28_29);
        _node29.AddEdge(ref edge28_29);

        Edge edge30_28 = new Edge(ref _node30, ref _node28, E30_28);
        _node30.AddEdge(ref edge30_28);
        _node28.AddEdge(ref edge30_28);

        Edge edge29_31 = new Edge(ref _node29, ref _node31, E29_31);
        _node29.AddEdge(ref edge29_31);
        _node31.AddEdge(ref edge29_31);

        Edge edge31_30 = new Edge(ref _node31, ref _node30, E31_30);
        _node31.AddEdge(ref edge31_30);
        _node30.AddEdge(ref edge31_30);

        Edge edge30_32 = new Edge(ref _node30, ref _node32, E30_32);
        _node30.AddEdge(ref edge30_32);
        _node32.AddEdge(ref edge30_32);

        Edge edge33_31 = new Edge(ref _node30, ref _node31, E33_31);
        _node33.AddEdge(ref edge33_31);
        _node33.AddEdge(ref edge33_31);

        Edge edge32_18 = new Edge(ref _node32, ref _node18, E32_18);
        _node32.AddEdge(ref edge32_18);
        _node18.AddEdge(ref edge32_18);

        Edge edge18_30 = new Edge(ref _node18, ref _node30, E18_30);
        _node18.AddEdge(ref edge18_30);
        _node30.AddEdge(ref edge18_30);

        //***************************//

        Edge edge31_19 = new Edge(ref _node31, ref _node19, E31_19);
        _node31.AddEdge(ref edge31_19);
        _node19.AddEdge(ref edge31_19);

        Edge edge19_33 = new Edge(ref _node19, ref _node33, E19_33);
        _node19.AddEdge(ref edge19_33);
        _node33.AddEdge(ref edge19_33);

        Edge edge19_34 = new Edge(ref _node19, ref _node34, E19_34);
        _node19.AddEdge(ref edge19_34);
        _node34.AddEdge(ref edge19_34);

        Edge edge18_19 = new Edge(ref _node18, ref _node19, E18_19);
        _node18.AddEdge(ref edge18_19);
        _node19.AddEdge(ref edge18_19);

        Edge edge18_34 = new Edge(ref _node18, ref _node34, E18_34);
        _node18.AddEdge(ref edge18_34);
        _node34.AddEdge(ref edge18_34);

        //***************************//

        Edge edge34_35 = new Edge(ref _node34, ref _node35, E34_35);
        _node34.AddEdge(ref edge34_35);
        _node35.AddEdge(ref edge34_35);

        Edge edge35_36 = new Edge(ref _node35, ref _node36, E35_36);
        _node35.AddEdge(ref edge35_36);
        _node36.AddEdge(ref edge35_36);

        Edge edge35_37 = new Edge(ref _node35, ref _node37, E35_37);
        _node35.AddEdge(ref edge35_37);
        _node37.AddEdge(ref edge35_37);

        Edge edge37_38 = new Edge(ref _node37, ref _node38, E37_38);
        _node37.AddEdge(ref edge37_38);
        _node38.AddEdge(ref edge37_38);

        Edge edge38_39 = new Edge(ref _node38, ref _node39, E38_39);
        _node38.AddEdge(ref edge38_39);
        _node39.AddEdge(ref edge38_39);

        Edge edge35_40 = new Edge(ref _node35, ref _node40, E35_40);
        _node35.AddEdge(ref edge35_40);
        _node40.AddEdge(ref edge35_40);

        Edge edge40_B = new Edge(ref _node40, ref _nodeB, E40_B);
        _node40.AddEdge(ref edge40_B);
        _nodeB.AddEdge(ref edge40_B);

        //creacion del grafo
        WP_Graph graph1 = new WP_Graph();//ref graphNodes
        graph1.AddNode(_node1);
        graph1.AddNode(_node2);
        graph1.AddNode(_node3);
        graph1.AddNode(_node4);
        graph1.AddNode(_node5);
        graph1.AddNode(_node6);
        graph1.AddNode(_node7);
        graph1.AddNode(_node8);
        graph1.AddNode(_node9);
        graph1.AddNode(_node10);
        graph1.AddNode(_node11);
        graph1.AddNode(_node12);
        graph1.AddNode(_node13);
        graph1.AddNode(_node14);
        graph1.AddNode(_node15);
        graph1.AddNode(_node16);
        graph1.AddNode(_node17);
        graph1.AddNode(_node18);
        graph1.AddNode(_node19);
        graph1.AddNode(_node20);
        graph1.AddNode(_node21);
        graph1.AddNode(_node22);
        graph1.AddNode(_node23);
        graph1.AddNode(_node24);
        graph1.AddNode(_node25);
        graph1.AddNode(_node26);
        graph1.AddNode(_node27);
        graph1.AddNode(_node28);
        graph1.AddNode(_node29);
        graph1.AddNode(_node30);
        graph1.AddNode(_node31);
        graph1.AddNode(_node32);
        graph1.AddNode(_node33);
        graph1.AddNode(_node34);
        graph1.AddNode(_node35);
        graph1.AddNode(_node36);
        graph1.AddNode(_node37);
        graph1.AddNode(_node38);
        graph1.AddNode(_node39);
        graph1.AddNode(_node40);
        graph1.AddNode(_nodeB);

        //WP_Graph graph2 = new WP_Graph();
        //graph2.AddNode(_node1);
        //graph2.AddNode(_node2);
        //graph2.AddNode(_node3);
        //graph2.AddNode(_node4);
        //graph2.AddNode(_node5);
        //graph2.AddNode(_node6);
        //graph2.AddNode(_node7);
        //graph2.AddNode(_node8);
        //graph2.AddNode(_node9);

        if (Diff == 1)
        {
            Debug.Log("djkstras method");



            //graph2.Djkstras(_node1, _node6);

            //shortestPathDjk = graph2.GetShortestPath();
            graph1.Djkstras(_node1, _nodeB);
            shortestPathDjk = graph1.GetShortestPath();
            
        }
        else
        {
            //graph1.Astar(_node1, _nodeB);
            Debug.Log("A star");
        }

        Agnt.SetActive(true);
    }

    public List<Node> GetDjkPath(){
        return shortestPathDjk;
    }
}
