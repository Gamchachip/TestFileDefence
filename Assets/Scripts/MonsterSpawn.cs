using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//몬스터 소환
public class MonsterSpawn : MonoBehaviour
{
    public FileData [] MonsterDatas;       //몬스터프리펩등 정보
    int index;

    //테스트용 타이머들
    // private float loundtimer;           //다음라운드용 타이머    
    // private float loundtime = 10f;   
    private float spawntimer;           //몬스터 현재 타이머
    private float spawntime = 2f;       //몇초마다 소환되게 할지

    public void GetMonster()
    {
        GameManager.instance.pool.MonsterGet(MonsterDatas[index]); 
    }
    public void Update()
    {
        spawntimer += Time.deltaTime;
        if(spawntimer > spawntime)
        {
            spawntimer = 0;
            GetMonster();
        }
    }
}
