using System.Collections.Generic;
using UnityEngine;

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
        createMap();
    }

    public void createMap()
    {
        vertexPositions.Clear();
        Queue<Vertex> queue = new Queue<Vertex>();
        Dictionary<Vertex, int> depthMap = new Dictionary<Vertex, int>();

        Vertex root = roomList[0];
        vertexPositions[root] = Vector3.zero;
        depthMap[root] = 0;
        queue.Enqueue(root);

        bool alternateAxis = true; // alterna entre X y Z para evitar diagonales

        while (queue.Count > 0)
        {
            Vertex current = queue.Dequeue();
            Vector3 parentPos = vertexPositions[current];
            int depth = depthMap[current];

            for (int i = 0; i < current.Edges.Count; i++)
            {
                Vertex child = current.Edges[i];
                float offset = (i + 1) * (roomSize + hallLength);

                Vector3 childPos;
                if (alternateAxis)
                {
                    childPos = parentPos + new Vector3(offset, 0, 0); // horizontal
                }
                else
                {
                    childPos = parentPos + new Vector3(0, 0, offset); // vertical
                }

                vertexPositions[child] = childPos;
                depthMap[child] = depth + 1;
                queue.Enqueue(child);
                alternateAxis = !alternateAxis; // cambia el eje para el siguiente hijo
            }
        }

        foreach (var room in roomList)
        {
            Instantiate(roomPrefab[0], vertexPositions[room], Quaternion.identity);
        }

        foreach (var room in roomList)
        {
            if (room.ParentVertex != null)
            {
                Vector3 start = vertexPositions[room.ParentVertex];
                Vector3 end = vertexPositions[room];
                Vector3 direction = end - start;
                Vector3 midPoint = start + direction / 2f;
                Quaternion rotation = Quaternion.LookRotation(direction);

                Instantiate(hallPrefab[0], midPoint, rotation);
            }
        }
    }


}