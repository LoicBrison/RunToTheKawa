using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint; 
    public PlatformTile tilePrefab;
    public float movingSpeed = 12;
    public int tilesToPreSpawn = 15; 
    public int tilesWithoutObstacles = 3; 

    List<PlatformTile> spawnedTiles = new List<PlatformTile>();
    int nextTileToActivate = -1;
    [HideInInspector]
    public bool gameOver = false;
    static bool gameStarted = false;
    public float score = 0;

    public static GroundGenerator instance;

    void Start()
    {
        instance = this;

        Vector3 spawnPosition = startPoint.position;
        int tilesWithNoObstaclesTmp = tilesWithoutObstacles;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            PlatformTile spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity) as PlatformTile;
            if(tilesWithNoObstaclesTmp > 0)
            {
                spawnedTile.DeactivateAllObstacles();
                tilesWithNoObstaclesTmp--;
            }
            else
            {
                spawnedTile.ActivateRandomObstacle();
            }
            
            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    void Update()
    {
        if (!gameOver && gameStarted)
        {
            transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * (movingSpeed + (score/500)), Space.World);
            score += Time.deltaTime * movingSpeed;
        }

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).z < 0)
        {
            PlatformTile tileTmp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTmp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTmp.startPoint.localPosition;
            tileTmp.ActivateRandomObstacle();
            spawnedTiles.Add(tileTmp);
        }

        if (gameOver || !gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameOver)
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
                else
                {
                    gameStarted = true;
                }
            }
        }
    }

    void OnGUI()
    {
        if (gameOver)
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Game Over\nYour score is: " + ((int)score) + "\nPress 'Space' to restart");
        }
        else
        {
            if (!gameStarted)
            {
                GUI.color = Color.red;
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "Press 'Space' to start");
            }
        }


        GUI.color = Color.green;
        GUI.Label(new Rect(5, 5, 200, 25), "Score: " + ((int)score));
    }
}