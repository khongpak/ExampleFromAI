using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;  // จำนวนคอลัมน์ของกริด
    public int height = 10; // จำนวนแถวของกริด
    public float cellSize = 1.0f; // ขนาดของแต่ละช่องในกริด

    private GameObject[,] gridArray; // 2D Array สำหรับเก็บข้อมูลกริด

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        gridArray = new GameObject[width, height]; // สร้าง Array 2 มิติ

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // สร้างจุดกำเนิดของแต่ละช่อง
                Vector3 worldPosition = new Vector3(x * cellSize, y * cellSize, 0);

                // วาดเส้นกรอบกริด (สำหรับ Debug)
                Debug.DrawLine(worldPosition, worldPosition + Vector3.right * cellSize, Color.white, 100f);
                Debug.DrawLine(worldPosition, worldPosition + Vector3.up * cellSize, Color.white, 100f);

                // คุณสามารถเพิ่ม Tile หรือ GameObject ลงไปในช่องนี้ได้ (ถ้าจำเป็น)
                gridArray[x, y] = null; // ช่องเริ่มต้นว่างเปล่า
            }
        }

        // เส้นกรอบรอบกริด (ขอบด้านนอก)
        Debug.DrawLine(new Vector3(0, height * cellSize, 0), new Vector3(width * cellSize, height * cellSize, 0), Color.white, 100f);
        Debug.DrawLine(new Vector3(width * cellSize, 0, 0), new Vector3(width * cellSize, height * cellSize, 0), Color.white, 100f);
    }

    public Vector2Int WorldToGrid(Vector3 worldPosition)
    {
        // แปลงตำแหน่งในโลกจริงให้เป็นตำแหน่งในกริด
        int x = Mathf.FloorToInt(worldPosition.x / cellSize);
        int y = Mathf.FloorToInt(worldPosition.y / cellSize);
        return new Vector2Int(x, y);
    }

    public Vector3 GridToWorld(Vector2Int gridPosition)
    {
        // แปลงตำแหน่งในกริดให้เป็นตำแหน่งในโลกจริง
        return new Vector3(gridPosition.x * cellSize, gridPosition.y * cellSize, 0);
    }
}
