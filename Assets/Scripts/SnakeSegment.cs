using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SnakeSegment : MonoBehaviour
{
    private static Dictionary<Vector2, Dictionary<Vector2, float>> orientations;  // thuộc tính orientations 
    // lưu trữ các giá trị định hướng quay của rắn
    private SpriteRenderer spriteRenderer;  //SpriteRenderer là kiểu dữ liệu kết xuất spite 2d

    public Sprite head;
    public Sprite tail;
    public Sprite body;
    public Sprite corner;

    public Vector2 direction { get; private set; }

    private void Awake() // phương thức sẽ được thực thi trước khi ứng dụng bắt đầu chạy.
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetDirection(Vector2 direction, Vector2 previous) 
    {
        if (orientations == null) {
            SetOrientations();
        }
        // xoay cái direction để đối với hướng trước đó là previous
        // angle la tao do z de quay truc 
        float angle = orientations[direction][previous];
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);   // vector3(0,0,angle);
                                    //AngleAxis Tạo một phép quay xoay góc độ quanh trục.

        this.direction = direction;
    }

    public void Follow(SnakeSegment other, int index, int length)
    {
        bool head = index == 0;
        bool tail = index == length - 1;
        bool turning = this.direction != other.direction;

        // Set the correct sprite depending where the segment is in the snake
        if (index == 0) {
            spriteRenderer.sprite = this.head;
        } else if (index == length - 1) {
            spriteRenderer.sprite = this.tail;
        } else if (turning) {
            spriteRenderer.sprite = this.corner;
        } else {
            spriteRenderer.sprite = this.body;
        }

        if (turning && !head && !tail) {
            SetDirection(other.direction, this.direction);
        } else {
            SetDirection(other.direction, Vector2.zero);
        }

        // Match the position of the segment to the one its following
        this.transform.position = other.transform.position;
    }

    private void SetOrientations()
    {          
        orientations = new Dictionary<Vector2, Dictionary<Vector2, float>>(5);
        // Dictionary lưu một key là hướng di chuyển hiện tại
                // một value là một dictionary khác.
                    // trong dictionary ở trong có key là hướng di chuyển trước đó. 
                                            // và value là một góc quay float
        orientations.Add(Vector2.zero, new Dictionary<Vector2, float>(5));
        orientations.Add(Vector2.right, new Dictionary<Vector2, float>(5));
        orientations.Add(Vector2.up, new Dictionary<Vector2, float>(5));
        orientations.Add(Vector2.left, new Dictionary<Vector2, float>(5));
        orientations.Add(Vector2.down, new Dictionary<Vector2, float>(5));

        orientations[Vector2.zero].Add(Vector2.zero, 0.0f);    // vị trí đứng yên của thân
        orientations[Vector2.zero].Add(Vector2.right, 0.0f);
        orientations[Vector2.zero].Add(Vector2.up, 90.0f);
        orientations[Vector2.zero].Add(Vector2.left, 180.0f);
        orientations[Vector2.zero].Add(Vector2.down, 270.0f);

        orientations[Vector2.right].Add(Vector2.zero, 0.0f);
        orientations[Vector2.right].Add(Vector2.left, 0.0f);
        orientations[Vector2.right].Add(Vector2.right, 0.0f);
        orientations[Vector2.right].Add(Vector2.down, 0.0f);
        orientations[Vector2.right].Add(Vector2.up, -90.0f);

        orientations[Vector2.up].Add(Vector2.zero, 90.0f);
        orientations[Vector2.up].Add(Vector2.up, 90.0f);
        orientations[Vector2.up].Add(Vector2.down, 90.0f);
        orientations[Vector2.up].Add(Vector2.right, 90.0f);
        orientations[Vector2.up].Add(Vector2.left, 0.0f);

        orientations[Vector2.left].Add(Vector2.zero, 180.0f);
        orientations[Vector2.left].Add(Vector2.left, 180.0f);
        orientations[Vector2.left].Add(Vector2.right, 180.0f);
        orientations[Vector2.left].Add(Vector2.up, 180.0f);
        orientations[Vector2.left].Add(Vector2.down, 90.0f);

        orientations[Vector2.down].Add(Vector2.zero, 270.0f);
        orientations[Vector2.down].Add(Vector2.down, 270.0f);
        orientations[Vector2.down].Add(Vector2.up, 270.0f);
        orientations[Vector2.down].Add(Vector2.left, 270.0f);
        orientations[Vector2.down].Add(Vector2.right, 180.0f);
    }

}
