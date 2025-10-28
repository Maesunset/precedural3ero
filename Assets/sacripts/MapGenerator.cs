using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class MapGenerator : MonoBehaviour
{
    public int maxRooms = 5;
    public int maxChilds = 2;
    public float roomSize = 10;
    public int hallLength = 10;
    public List<GameObject> roomPrefab;
    public List<GameObject> hallPrefab;
    private List<Vertex> roomList = new List<Vertex>();
    
    private Dictionary<Vertex, Vector3> vertexPositions = new Dictionary<Vertex, Vector3>();
    private void Start()
    {
        createVertexMap();
    }
    private void createVertexMap()
    {
        // creamos node Root
        roomList.Add(new Vertex(0,"node " + 0));
        for (int i = 0; i < maxRooms; i++)
        {
            // creamos el numero random de cuartos por agregaer
            int RandomRoomsAcount = UnityEngine.Random.Range(1, maxChilds+1);
            List<Vertex> tempList = new List<Vertex>();
            for (int j = roomList.Count; j < roomList.Count + RandomRoomsAcount; j++)
            {
                if (j < maxRooms)
                {
                    tempList.Add(new Vertex(roomList.Count, "node " + j , roomList[i]));
                }
            }
            if (tempList.Count > 0)
            {
                roomList.AddRange(tempList);
                roomList[i].Edges = tempList;
            }
            if (roomList.Count >= maxRooms) { break; }
        }
        Debug.Log(" all register");
        createMap();
    }

    public void createMap()
    {
        Debug.Log("create map");
        foreach (var Vertex in roomList)
        {
            
        }
    }
}