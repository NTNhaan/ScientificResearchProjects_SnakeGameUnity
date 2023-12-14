using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour
{
    // public TilemapCollider2D tilemapCollider;
    public Collider2D gridArea;
    public Tilemap GridWall;
    bool isScene1;
    bool isScene2;
    bool isScene3;
    bool isScene4;
    bool Checkdestroy = false;
    public Tilemap G;

    // public LayerMask walllayer;
    // private void Awake()
    // {
    //     G = GameObject.Find("TileWall").GetComponent<Tilemap>();
    // }
    private void Start()
    {
        RandomizePosition();
        if (isScene1 || isScene2)
        {
            G = GameObject.Find("TileWall").GetComponent<Tilemap>();
        }

        isScene1 = SceneManager.GetActiveScene().name == "SnakeWallMod";
        isScene2 = SceneManager.GetActiveScene().name == "SnakeWall1";
        isScene3 = SceneManager.GetActiveScene().name == "SnakeWall2";
        isScene4 = SceneManager.GetActiveScene().name == "SnakeWall3";
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        // x = Mathf.Round(x);
        // y = Mathf.Round(y);

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
        // Vector2 foodSize;
        // if(GridWall.GetComponent<TilemapRenderer>() != null)
        // {
        //     foodSize = GridWall.GetComponent<TilemapRenderer>().bounds.size;
        // }
        // else{
        //     foodSize = GetComponent<SpriteRenderer>().bounds.size;    
        // }

        // Bounds bounds = gridArea.bounds;

        // Vector2 randomPosition = new Vector2(
        //     Random.Range(bounds.min.x + foodSize.x / 2, bounds.max.x - foodSize.x / 2),
        //     Random.Range(bounds.min.y + foodSize.y / 2, bounds.max.y - foodSize.y / 2)
        // );//RaycastHit2D
        // Collider2D hit = Physics2D.OverlapCircle(randomPosition, foodSize.x / 2, LayerMask.GetMask("Obstacle"));
        // if(hit.GetComponent<Collider>() != null)
        // {
        //     RandomizePosition();
        //     return;
        // }
        // this.transform.position = new Vector2(Mathf.Round(randomPosition.x), Mathf.Round(randomPosition.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isScene1 || isScene2 || isScene3 || isScene4)
            {
                Checkdestroy = true;
                if (Checkdestroy == true)
                {
                    TilemapRenderer myTilemapRenderer = GameObject.Find("TileWall").GetComponent<TilemapRenderer>();
                    TilemapCollider2D myTilemapCollider = GameObject.Find("TileWall").GetComponent<TilemapCollider2D>();

                    Destroy(myTilemapRenderer);
                    Destroy(myTilemapCollider);
                    G.ClearAllTiles();
                    Destroy(this.gameObject);
                    Destroy(G);
                }
            }
            else
            {
                RandomizePosition();
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Vector2 foodsize = GetComponent<BoxCollider2D>().size; 
            // float xRange = other.GetComponent<TilemapCollider2D>().bounds.size.x - foodsize.x;
            // float yRange = other.GetComponent<TilemapCollider2D>().bounds.size.y - foodsize.y;

            // transform.position = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));

            Vector2 foodsize = GetComponent<BoxCollider2D>().size; 
            Collider2D overlap = Physics2D.OverlapBox(transform.position, foodsize, 0, LayerMask.GetMask("Obstacle"));

            if (overlap != null)
            {
                RandomizePosition();
            }
        }
    }

}
