using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMgr : SingeBase<MapMgr>
{

    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor;
    public GameObject endRoom;

    [Header("位置控制")]
    public Transform generatorPoint;
    public int offsetX = 3;
    public int offsetY = 3;
    public Direction direction;
    public LayerMask roomLayer;

    public List<GameObject> rooms = new List<GameObject>();

    public GameObject shengchengyuandian()
    {
        GameObject go = GameObject.Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity);//原点
        rooms.Add(go);
        rooms[0].GetComponent<SpriteRenderer>().color = startColor;
        return go;
    }
    public bool hasRoom(GameObject room)
    {
        Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer);
        return false;
    }
    public GameObject shengchengsuiji(GameObject room)
    {

        direction = (Direction)Random.Range(0, 4);//表示方向，0上，1下，2左，3右
        Vector3 v3 = new Vector3(room.transform.position.x, room.transform.position.y, room.transform.position.z);


        //检测上下左右是否有房间




        switch (direction)
        {

            case Direction.UP:
                generatorPoint.position += new Vector3(0, offsetY, 0);

                break;
            case Direction.DOWN:
                generatorPoint.position += new Vector3(0, -offsetY, 0);
                break;
            case Direction.LEFT:
                generatorPoint.position += new Vector3(-offsetX, 0, 0);
                break;
            case Direction.RIGHT:
                generatorPoint.position += new Vector3(offsetX, 0, 0);
                break;
            default:
                break;
        }
        GameObject gonew = GameObject.Instantiate(room, v3, room.transform.rotation);
        rooms.Add(gonew);
        return gonew;

    }

    public void shengcheng()
    {
        GameObject gameObject1 = shengchengyuandian();


        for (int i = 0; i < 10; i++)
        {
            gameObject1 = shengchengsuiji(gameObject1);
        }



    }


    public enum Direction
    {
        UP, DOWN, LEFT, RIGHT
    }

}
