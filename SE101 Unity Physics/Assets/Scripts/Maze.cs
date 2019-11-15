﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MazeObjects;

public class Maze : MonoBehaviour {

	List<Feature> features;

    public int Width { get; private set; }
    public int Height { get; private set; }
    public Vector3 Origin { get; private set; }
    public GameObject Ball { get; private set; }
    private GameObject BallPrefab { get; set; }
    private int [,,] Map { get; set; }

    private GameObject Platform;
    private GameObject Ceiling;
    private GameObject PlatformPrefab;
    private GameObject BlockerPrefab;

	// Use this for initialization
    public void Initialize(int width, int height)
    {
        Width = width;
        Height = height;
        MazeGeneration generator = new MazeGeneration(width, height);
        Map = generator.Generation();
        // Origin = transform.parent.position;
        Origin = new Vector3(-width / 2.0f, 0, -height / 2.0f);
        Ball = Instantiate(BallPrefab, new Vector3(0, (float)0.5, 0), Quaternion.identity);

        BallPrefab = (GameObject) Resources.Load("Prefabs/Ball");
        BlockerPrefab = (GameObject)Resources.Load("Prefabs/Blocker");
        //TilePrefab = (GameObject)Resources.Load("Prefabs/PlatformTile");
        PlatformPrefab = (GameObject)Resources.Load("Prefabs/Platform");

        Platform = Instantiate(PlatformPrefab, new Vector3(-0.5f, 0, -0.5f), Quaternion.identity);
        transform.localScale = new Vector3(width - 1, (float)0.1, height - 1);
        Ceiling = Instantiate(PlatformPrefab, new Vector3(-0.5f, 1, -0.5f), Quaternion.identity);
        //TopBlocker = Instantiate(BlockerPrefab, new Vector3(0, (float)(1+5), 0), Quaternion.identity);
        //BottomBlocker = Instantiate(BlockerPrefab, new Vector3(0, (float)(-5), 0), Quaternion.identity);
        Destroy(Ceiling.GetComponent<MeshRenderer>());
        Platform.transform.SetParent(transform);
        Ceiling.transform.SetParent(transform);
        //TopBlocker.transform.SetParent(Platform.transform);
        //BottomBlocker.transform.SetParent(Platform.transform);


        InitializeFeatures();
        BuildFeatures();
    }
	
	// Update is called once per frame
	void Update () {
		foreach (Feature feature in features)
		{
			feature.Update();
		}
	}
    void BuildFeatures()
    {
        foreach (Feature feature in features)
        {
            feature.Build();
        }
    }
    void InitializeFeatures()
	{
		features.Add(new Walls(this, Map));
		//features.Add(new Obsticles);
	}
}
