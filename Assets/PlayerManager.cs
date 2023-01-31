using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public GameObject[] FruitPreFabs;

    public Transform FruitPosition;

    public GameObject ReadyFruit;
    //状态位，使水果能正常下落
    //private int state = 0;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CreateFruit();
    }

    void Update()
    {
        if (ReadyFruit == null)
        {
            return;
        }
        if (Input.GetMouseButton(0) /*&& state == 1*/)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 NewPos = new Vector3(MousePos.x, ReadyFruit.transform.position.y, ReadyFruit.transform.position.z);
            //边界校验
            float max = 3f - ReadyFruit.GetComponent<CircleCollider2D>().radius;
            float min = -3f + ReadyFruit.GetComponent<CircleCollider2D>().radius;
            if (NewPos.x > max)
            {
                NewPos.x = max;
            }
            else if (NewPos.x < min)
            {
                NewPos.x = min;
            }
            ReadyFruit.transform.position = NewPos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //state = 0;
            ReadyFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
            Invoke("CreateFruit", 1f);
            ReadyFruit = null;
        }
    }
    private void CreateFruit()
    {
        //state = 1;
        //随机一个索引
        int index = Random.Range(0, 4); //0,1,2,3
        //获得水果预制体
        GameObject prefab = FruitPreFabs[index];
        //预制体实例化
        ReadyFruit = Instantiate(prefab);
        //把水果移到起点
        ReadyFruit.transform.position = FruitPosition.position;
        //水果重力清0
        ReadyFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
