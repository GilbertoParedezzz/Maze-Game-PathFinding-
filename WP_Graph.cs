using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class WP_Graph 
{
    private List<Node> nodes;

    //Dkjstras
    private List<Edge> edgesToVisit = new List<Edge>();

    public List<Node> path;

    public WP_Graph() {
        nodes = new List<Node>();
    }

    public WP_Graph(ref List<Node> listNodes) {
        nodes = listNodes;
    }

    public void AddNode(Node newnode) {
        nodes.Add(newnode);
    }

    public void BFS2(Node n) {
        List<Node> nodesToVisit = new List<Node>();
        n.SetVisited(true);
        nodesToVisit = GetNodesToVisit(n);

        while (nodesToVisit.Count > 0)
        {
            if (nodesToVisit[0].GetVisited())
            {
                nodesToVisit.RemoveAt(0);
            }
            else
            {
                Debug.Log("node visited: " + nodesToVisit[0].GetValue());
                nodesToVisit[0].SetVisited(true);
                nodesToVisit.AddRange(GetNodesToVisit(nodesToVisit[0]));
            }
        }
    }

    public List<Node> GetNodesToVisit(Node n) {
        List<Node> nodesToVisit = new List<Node>();
        foreach (Edge edge in n.GetEdges())
        {
            if (edge.GetFromNode() == n)
            {
                nodesToVisit.Add(edge.GetToNode());
            }
            else
            {
                nodesToVisit.Add(edge.GetFromNode());
            }

        }

        return nodesToVisit;
    }

    public void DFS(Node n) {
        if (!n.GetVisited())
        {
            n.SetVisited(true);
            if (n.GetEdges()[0].GetFromNode() == n)
            {
                DFS(n.GetEdges()[0].GetToNode());
            }
            else
            {
                DFS(n.GetEdges()[0].GetFromNode());
            }
        }
    }

    public void DFS2(Node n) {
        if (!n.GetVisited())
        {
            List<Node> nodesToVisit = new List<Node>();
            n.SetVisited(true);

            while (nodesToVisit.Count > 0)
            {
                if (nodesToVisit[0].GetVisited())
                {
                    nodesToVisit.RemoveAt(0);
                }
                else
                {
                    nodesToVisit[0].SetVisited(true);
                    if (nodesToVisit[0].GetEdges()[0].GetFromNode() == nodesToVisit[0])
                    {
                        nodesToVisit.Add(nodesToVisit[0].GetEdges()[0].GetToNode());
                    }
                    else
                    {
                        nodesToVisit.Add(nodesToVisit[0].GetEdges()[0].GetFromNode());
                    }
                }
            }
        }
    }

    public void Djkstras(Node inicio, Node meta) {//damos nodo inicial y nodo final
        Debug.Log("Djkstras iniciado");
        Debug.Log("Visitaremos el Nodo1");
        DjkstrasVisitNode(inicio, 0, null);//iniciamos en nodo1 y lo marcamos como 0 y null pq es el primero 

        //Debug.Log("Creamos serching");
        bool searching = true; //searching crea un bool true "buscando "
        //if (searching == true)
        //    Debug.Log("Searching creado e igualado a true ");
        Debug.Log("iniciando while");

        while (searching) //mientras siga siendo true
        {
            Debug.Log("ciclo while");
            
            Edge tempEdge = GetNextEdge();//creamos tempEd y sera igual a la llamada de get edge
            //Debug.Log("Creamos tempEdge que es igual al edge más corto del nodo en el que estamos");
            
            tempEdge.SetVisited(true);//marcamos tmpEd como visitado
            //Debug.Log("marcamos tempEd como visitado");
            if (tempEdge.GetFromNode() == inicio) //si el nodo anterior al arista tmp es inicio
            {
                Debug.Log("EL arista sale del inicio");

                DjkstrasVisitNode(tempEdge.GetToNode(), tempEdge.GetWeight(), tempEdge); //llamamos a la funcion visitedDjk dandole el siguiente nodo, peso, y el tmpEd del arista Tmp
                Debug.Log("Visitamos el nodo siguiente de n1 ");


                //searching = false;
                //break;
                
                if (tempEdge.GetToNode() == meta) //si el arista lleva a la meta
                {
                    Debug.Log("Cerramos el ciclo pq el sig nodo es la meta");
                    SetShortestPath(inicio, meta);
                    searching = false;//cerramos el ciclo
                    break;
                    
                }
                
            }
            if (tempEdge.GetFromNode() != inicio)
            {
                //Debug.Log("El arista no sale de el inicio");

                DjkstrasVisitNode(tempEdge.GetToNode(), tempEdge.GetWeight(), tempEdge);//llamamos a la funcion visitedDjk dandole el sig nodo, peso, y el tmpEd del arista Tmp
                Debug.Log("Visitaremos el nodo siguiente  ");
                if (tempEdge.GetToNode() == meta) //si el arista lleva a la meta
                {
                    Debug.Log("Cerramos el ciclo pq el sig nodo es la meta");
                    SetShortestPath(inicio, meta);
                    searching = false;//cerramos el ciclo
                    break;
                }
            }
            
        }
        Debug.Log("ciclo while completado");

    }

    private void DjkstrasVisitNode(Node n, float val, Edge fromEdge) {//recibimos nodo, valor y de donde llegoamos
        if (n == null)
        {
            Debug.LogError("Node is null.");
            return;
        }

        if (!n.GetVisited())//si el nodo no a sido visitado paso1
        {
            n.SetVisited(true);
            Debug.Log("Hemos descubierto un Nodo caso1");
            n.SetValue(val);//le damos el valor de val
            //Debug.Log("Le damos el valor de nuestro arista tmp");
            if (fromEdge != null)//si sabemos por donde llego 
            {
                //Debug.Log("EL nuevo nodo tiene un predecesor (osea no es en nodo inicial) ");
                n.SetCorrectEdge((fromEdge));//marcamos ese camino como correcto
                Debug.Log("ahora el arista correcto del nuevo nodo es por donde llegamos");
            }
        }
        else //si ya fue visitado paso1
        {
            Debug.Log("Llegamos a un nodo ya descubierto caso2");
            if (val < n.GetValue()) //revisamos si el valor de n es mayor a val y si si lo es
            {
                //Debug.Log("nuestro Val de tempEd es menor al val del nodo actual ");
                n.SetValue(val);//a val se le suma el valor del nodo predecesor
               // Debug.Log("seteamos el valor de n a val de tmpEd ");
                if (fromEdge != null)//si sabemos por donde llego
                {
                    //Debug.Log("El nodo tiene un predecesor (osea no es en nodo inicial)");
                    n.SetCorrectEdge((fromEdge));// marcamos ese camino como correcto
                    Debug.Log("marcamos el arista por donde llegamos al nodo ya descubierto com el correcto de n");
                }
            }
        }

        foreach (Edge edge in n.GetEdges())//por cada objeto arista en la lista de aristas del nodo pasos 2
        {
            if (!edge.GetVisited())//si los aristas no han sido visitados se agregan a la lista de por visitar
            {
                edgesToVisit.Add(edge); //agregamos a la lista de vertices por visitar
                Debug.Log("Agregando edges de n a edgesToVisit ");
            }
        }
    }

    private Edge GetNextEdge() {
        if (edgesToVisit.Count == 0)
        {
            Debug.LogError("No edges to visit.");
            return null;
        }
        Edge edgeTempMin = edgesToVisit[0];
        foreach (Edge edge in edgesToVisit)
        {
            if (edge.GetWeight() < edgeTempMin.GetWeight())
            {
                edgeTempMin = edge;
            }
        }
        edgesToVisit.Remove(edgeTempMin); // Remove the edge from the list once it's selected
        return edgeTempMin;
    }


    public List<Node> SetShortestPath(Node startNode, Node endNode) {  //regresamos la lista paths
        
        path = new List<Node>();//creamos la lista path

        Node currentNode = endNode;//nos colocamos en el nodo final
        while (currentNode != startNode && currentNode.GetCorrectEdge() != null)//hasta que no estemos en startNode y no tengamos correct edg (pq el nodo inicial no viene de ning lado)
        {
            path.Add(currentNode);//agregamos el nodo actual a path
            currentNode = currentNode.GetCorrectEdge().GetFromNode();//nos colocamos en el nodo de donde viene el arista correcto
        }

        // agregamos el nodo 1
        path.Add(startNode);

        // Volteamos la lista de nodos path
        path.Reverse();
        int a = path.Count;
        Debug.Log("Returning path de tamaño: "+a);
        return path; //regresamos path
    }

    public List<Node> GetShortestPath() {
        return path;
    }

}
