using UnityEngine;
using System.Collections.Generic;
public class Vertex
{
        // nombre del vertice
        public string name {get; set;}
        // valor del vertice actual
        public int Valeu {get; set;} 
        // lista de aristas conectadas
        public List<Vertex> Edges {get;set;} 
        // guardamos un padre para tener mas manejo durante la ejecucion
        public Vertex ParentVertive {get;set;}
        // constructor
        public  Vertex(int newValeu = 0, string newName = "null") 
        {
                this.Valeu = newValeu;
                name = newName;
                Edges = new List<Vertex>();
        }
}