using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public int rows = 10;
    public int cols = 10;
    public float gridSize = 2.08f;

    public Color gridColor = Color.red;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = gridColor;

        for (int x = 0; x <= cols; x++)
        {
            Gizmos.DrawLine(new Vector3(x * gridSize, 0, transform.position.z),
                new Vector3(x * gridSize, rows * gridSize, transform.position.z));

        }

        for (int y = 0; y <= rows; y++)
        {
            Gizmos.DrawLine(new Vector3(0, y * gridSize, transform.position.x),
                new Vector3(cols * gridSize, y * gridSize, transform.position.z));
        }
        Debug.Log("CallCount");

        SpriteRenderer[] sprites = GameObject.FindObjectsOfType<SpriteRenderer>();

        for (int i = 0; i < sprites.Length; i++)
        {
            //find center of sprite
            SpriteRenderer currentSpriteRenderer = sprites[i];
            Sprite currentSprite = currentSpriteRenderer.sprite;
            Vector3 spriteCenterWorld = currentSpriteRenderer.transform.position + currentSprite.bounds.center;


            Vector3 spriteCenterGrid = new Vector3(
                Mathf.FloorToInt(spriteCenterWorld.x / gridSize),
                Mathf.FloorToInt(spriteCenterWorld.y / gridSize),
                currentSpriteRenderer.transform.position.z);

            currentSpriteRenderer.transform.position = spriteCenterGrid * gridSize;
        }
    }

}
