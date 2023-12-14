using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallscript : MonoBehaviour
{
    private SpriteRenderer WallspriteRenderer;

    public Wallscript sprite;
    // public Sprite Wall;
    // public Sprite Wallcorner;

    private void Awake() // phương thức sẽ được thực thi trước khi ứng dụng bắt đầu chạy.
    {
        WallspriteRenderer = GetComponent<SpriteRenderer>();
    }
    // public void SetDirection(Vector2 direction, Vector2 previous)
    // {
    //     // angle la tao do z de quay truc 
    //     float angle = orientations[direction][previous];
    //     this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);   // vector3(0,0,angle);
    //                                 //AngleAxis Tạo một phép quay xoay góc độ quanh trục.

    //     this.direction = direction;
    // }
}
