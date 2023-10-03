using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ตัวแปรเก็บ object ที่จะกล้องตาม
    public float smoothing = 5f; // ความนิ่งของกล้อง

    Vector3 offset; // ค่าต่างระหว่างตำแหน่งของ target และกล้อง

    void Start () {
        offset = transform.position - target.position; // กำหนดค่าต่างระหว่างตำแหน่งของ target และกล้องเมื่อเริ่มเกม
    }

    void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset; // คำนวณตำแหน่งของกล้องโดยเพิ่ม offset กับตำแหน่งของ target
        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime); // กำหนดตำแหน่งของกล้องให้เลื่อนไปเรื่อยๆจนกว่าจะไปถึงตำแหน่งของ target
    }
}
