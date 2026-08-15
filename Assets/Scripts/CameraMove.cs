using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // เป้าหมายที่กล้องจะวิ่งตาม (ลาก Player มาใส่)

    [Header("Follow Settings")]
    public float smoothSpeed = 0.125f; // ความเร็วในการเคลื่อนที่ตาม (ยิ่งน้อยยิ่งสมูท/หน่วง)
    public Vector3 offset; // ระยะห่างระหว่างกล้องกับเป้าหมาย
    public bool is2DGame = false;
    private void Start()
    {
        if (target == null) return;

        offset = target.position - transform.position;

        // อัปเดตตำแหน่งกล้อง
        if (is2DGame)
        {
            offset.z = 0;
        }
    }


    void LateUpdate()
    {
        // ตรวจสอบว่ามีเป้าหมายอยู่หรือไม่ เพื่อป้องกัน Error
        if (target == null) return;

        // คำนวณตำแหน่งเป้าหมายที่กล้องควรจะไป
        Vector3 desiredPosition = target.position + offset;

        
        // ใช้ Vector3.Lerp เพื่อให้กล้องเคลื่อนที่ตามอย่างนุ่มนวล
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

       
        transform.position = smoothedPosition;
        
    }
}
