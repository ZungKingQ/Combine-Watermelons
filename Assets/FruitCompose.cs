using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitCompose : MonoBehaviour
{
    private bool IsTrigger = true;
    public int level;
    //如果碰撞则执行
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) != 0 && collision.gameObject.name == "Floor")
        {
            // 播放音效
            AudioManager.Instance.PlayAudio(AudioManager.Instance.AudioClips[1]);
        }
        //碰到水果且非自己
        if (collision.gameObject.tag == "fruit" && PlayerManager.Instance.ReadyFruit != this.gameObject)
        {
            if(this.level == collision.gameObject.GetComponent<FruitCompose>().level)
            {
                if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    //合成
                    //获得高一级水果
                    GameObject prefab = PlayerManager.Instance.FruitPreFabs[level];
                    //实例化高一级水果预制体
                    GameObject fruit = Instantiate(prefab);
                    //把水果移到起点
                    fruit.transform.position = this.gameObject.transform .position;
                    //更新分数
                    UIManager.Instance.Score1 += this.level * 2;
                    //播放音效
                    AudioManager.Instance.PlayAudio(AudioManager.Instance.AudioClips[0]);
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                if (Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0.8f)
                {
                    // 播放音效
                    AudioManager.Instance.PlayAudio(AudioManager.Instance.AudioClips[1]);
                }

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsTrigger == false && PlayerManager.Instance.ReadyFruit != this.gameObject && collision.gameObject.name == "Dead Line")
        {
            //GG
            print("GG");
            SceneManager.LoadScene("合成大西瓜");
        }
        else if(collision.gameObject.name == "Dead Line" && IsTrigger == true)
        {
            IsTrigger = false;
        }
    }
}
