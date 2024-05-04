using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;




//기본 몬스터 클래스
//소환될 시 1.스탯초기화 2. 스캔범위내에 가장가까운 파일이나 폴더로 이동
public class Monster : MonoBehaviour
{

    [Header("status")]
    public float hp;
    public float moveSpeed = 100f;
    public float damage;
    public Sprite img;
    public Rigidbody2D rigid;
    public Transform target;

    Vector2 dir;







    void Start()
    {
        target = GetComponent<Scanner>().GetNearest();
        rigid = GetComponent<Rigidbody2D>();

        
    }

    void Update()
    {
        if (!target)
            return; 

        dir = target.position - transform.position;
        dir = dir.normalized;        
        rigid.velocity = dir * moveSpeed * Time.deltaTime;
    }

    
    public void Init(FileData data)
    {
        Debug.Log("Init발동");
        hp = data.HP;
        moveSpeed = data.MoveSpeed;
        damage = data.Damage;
        img = data.Image;
        this.GetComponent<Scanner>().InitLayer();
    }
    

    
}
