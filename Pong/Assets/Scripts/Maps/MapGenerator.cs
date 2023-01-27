using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Players and Ball")]
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;

    [Header("Borders")]
    public GameObject goal1;
    public GameObject goal2;
    public GameObject borderTop;
    public GameObject borderBottom;

    [Header("Other Components")]
    public GameObject background;
    public GameObject divider;

    [Header("Materials")]
    public string folder;
    public Material[] materials;

    public void Awake()
    {
        // Get GameObjects from the scene
        player1 = GameObject.FindGameObjectWithTag("Player 1");
        player2 = GameObject.FindGameObjectWithTag("Player 1");
        ball = GameObject.FindGameObjectWithTag("Ball");

        goal1 = GameObject.FindGameObjectWithTag("Goal 1");
        goal2 = GameObject.FindGameObjectWithTag("Goal 2");
        borderTop = GameObject.FindGameObjectWithTag("Border Top");
        borderBottom = GameObject.FindGameObjectWithTag("Border Bottom");

        background = GameObject.FindGameObjectWithTag("Background");
        divider = GameObject.FindGameObjectWithTag("Divider");

        // Get the folder with the materials for the scene
        folder = MapSelection.mapType;
    }

    void Start()
    {
        materials = Resources.LoadAll(folder, typeof(Material)).Cast<Material>().ToArray();

        foreach (Material material in materials)
        {
            if (material.name == "Players")
            {
                player1.GetComponent<MeshRenderer>().material = material;
                player2.GetComponent<MeshRenderer>().material = material;
            } else if (material.name == "Ball")
            {
                ball.GetComponent<MeshRenderer>().material = material;
            } else if (material.name == "Goals")
            {
                goal1.GetComponent<MeshRenderer>().material = material;
                goal2.GetComponent<MeshRenderer>().material = material;
            } else if (material.name == "Borders")
            {
                borderTop.GetComponent<MeshRenderer>().material = material;
                borderBottom.GetComponent<MeshRenderer>().material = material;
            }
        }
    }
}
