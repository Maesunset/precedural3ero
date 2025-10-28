using System;
using System.Collections.Generic;
using UnityEngine;

public class maoGenerator : MonoBehaviour
{
    public int RoomsAcount = 5;
    public int MaxChilds = 2;
    public List<GameObject> roomPrefab;
    public List<GameObject> CorridorsPrefab;
    private List<Vertex> VerticeList = new List<Vertex>();
    private void Start()
    {
        createVertexMapMap();
    }
    private void createVertexMapMap()
    {
        
    }

    public void createMap()
    {
        
    }

    private void OnDrawGizmos()
    {
        
    }
}