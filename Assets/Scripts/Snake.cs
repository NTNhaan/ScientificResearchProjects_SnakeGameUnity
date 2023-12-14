using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    private List<SnakeSegment> segments = new List<SnakeSegment>();

    public Text HightScore;
    bool scene1;
    bool scene2;
    bool scene3;
    bool scene4;
    bool scene5;
    bool scene6;
    public Collider2D gridArea;
    public GameObject Wallspawn;
    // private BrickSpawn brickSpawn;
    private SnakeSegment head;
    public SnakeSegment segmentPrefab;
    public int initialSize = 4;
    protected static int Score = 0;
    protected static int ScoreMod = 5;
    protected static int ScoreWall;
    public Text ScoreText;
    public Text Scoredead;
    public GameOverScene gameOverScene;
    int maxPlatform = 0;
    private void Awake()
    {
        Score = 0;
        ScoreMod = 5;
        ScoreWall = Score;
        scene1 = SceneManager.GetActiveScene().name == "SnakeMod";
        scene2 = SceneManager.GetActiveScene().name == "SnakeFreeMod";

        scene3 = SceneManager.GetActiveScene().name == "SnakeWallMod";
        scene4 = SceneManager.GetActiveScene().name == "SnakeWall1";
        scene5 = SceneManager.GetActiveScene().name == "SnakeWall2";
        scene6 = SceneManager.GetActiveScene().name == "SnakeWall3";
        head = GetComponent<SnakeSegment>();

        if (head == null)
        {
            head = gameObject.AddComponent<SnakeSegment>();
            head.hideFlags = HideFlags.HideInInspector;
        }
    }
    // private void OnEnable(){   // khi reload scene thì phương thức awake ko chạy nên mới onenable
    //     if(UnityEditor.EditorApplication.isPlaying == true)   // chưa hđ
    //     {
    //         head = GetComponent<SnakeSegment>();
    //         if (head == null)
    //         {
    //             head = gameObject.AddComponent<SnakeSegment>();
    //             head.hideFlags = HideFlags.HideInInspector;
    //         }
    //     }
    // }
    // private void Wallgame(){    // x = 29.102
    //     walltop.transform.position.x = -30.484f;
    //     WallSptite[0].Add(walltop);

    //     for(int i=1 ; i<10 ; i++)
    //     {
    //         walltop.position.x += 1; 
    //         WallSptite[i].Add(Instantiate(walltop));
    //     }
    // }

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (head.direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                head.SetDirection(Vector2.up, Vector2.zero);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                head.SetDirection(Vector2.down, Vector2.zero);
            }
        }
        else if (head.direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                head.SetDirection(Vector2.right, Vector2.zero);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                head.SetDirection(Vector2.left, Vector2.zero);
            }
        }
    }

    private void FixedUpdate()
    {
        // đặc mỗi phân đoạn chạy theo sau phân đoạn phía trước nó
        for (int i = segments.Count - 1; i > 0; i--)  // đảo ngược vị trí của các phần tử thêm vào sau để chúng ko xếp chồng lên nhau
        {
            segments[i].Follow(segments[i - 1], i, segments.Count);
        }

        float x = Mathf.Round(head.transform.position.x) + head.direction.x;
        float y = Mathf.Round(head.transform.position.y) + head.direction.y;

        head.transform.position = new Vector2(x, y);   // update các vị trí position 
    }

    public void Grow()
    {
        SnakeSegment segment = Instantiate(segmentPrefab);
        segment.Follow(segments[segments.Count - 1], segments.Count, segments.Count + 1);
        segments.Add(segment);
    }

    public void ResetState()
    {
        // Set the initial direction of the snake, starting at the origin
        // (center of the grid)
        head.SetDirection(Vector2.right, Vector2.zero);
        if (scene3 || scene4 || scene5 || scene6)
        {
            head.transform.position = new Vector3(-22, 0, 0);
        }
        else
        {
            head.transform.position = Vector3.zero;
        }

        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        // Clear the list then add the head as the first segment
        segments.Clear();
        segments.Add(head);
        // -1 since the head is already in the list
        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }
    }
    public void GameOver()
    {
        gameOverScene.Setup(maxPlatform);
    }
    private Vector2 SpawnWall()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        return new Vector2(x, y);

    }
    public void LoadSceneRandom(){
        int i = Random.Range(7, 10);
        SceneManager.LoadScene(i);
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Grow();
            Score++;
            ScoreWall++;
            ScoreText.text = Score.ToString();
            if (Score > PlayerPrefs.GetInt("HightScore", 0))
            {
                PlayerPrefs.SetInt("HightScore", Score);
                HightScore.text = Score.ToString();
            }
            if (scene1)  // snake mod
            {
                if (Score >= ScoreMod)
                {
                    Vector2 Wallposition = SpawnWall();
                    if (Physics2D.OverlapBox(Wallposition, new Vector2(1f, 0.84f), 0f))
                    {
                        Wallposition = SpawnWall();
                    }
                    Instantiate(Wallspawn, Wallposition, Quaternion.identity);
                    ScoreMod += 5;
                }
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            if (scene2)   // freemod
            {
                Vector3 position = transform.position;
                if (head.direction.x != 0f)
                {
                    position.x = -other.transform.position.x + head.direction.x;
                }
                else if (head.direction.y != 0f)
                {
                    position.y = -other.transform.position.y + head.direction.y;
                }
                transform.position = position;
            }
            else if(scene3 || scene4 || scene5 || scene6)  //ObstaceMod
            {
                GameOver();
                Time.timeScale = 0;
                ScoreWall=0;
                Scoredead.text = ScoreWall.ToString() + " POINTS";
                HightScore.text = "HightScore " + PlayerPrefs.GetInt("HightScore", 0).ToString();
                ScoreWall = Score;
            }
            else
            {
                GameOver();
                Time.timeScale = 0;
                Scoredead.text = Score.ToString() + " POINTS";
                HightScore.text = "HightScore " + PlayerPrefs.GetInt("HightScore", 0).ToString();
                Score = 0;
                ScoreMod = 5;
            }
        }
        else if (other.gameObject.CompareTag("DoorCollider"))
        {            
            LoadSceneRandom();
        }
    }
}
// phải cho ui mang vị trí cụ thể để xuất hiện lên trên màn hình trước.  //ok
// rồi sau khi chết thì game phải đứng lại và hiện ra một button có opption chơi lại  ok
// và khi bấm vào nút button chơi lại thì game sẽ Resetstate    ok

// menu vào game ok


// tường đè lên quả
// tường đè lên nhau  ok
// tường đè lên thân