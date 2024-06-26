using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PoolManager : MonoBehaviour
{
    

    public List<GameObject>     fileList;           //생성된 프리펩 보관장소
    public List<GameObject>     monsterList;           //생성된 프리펩 보관장소
    
    public List<GameObject>     weaponList; 



    void Awake()
    {
        //프리펩 저장장소 초기화
        fileList = new List<GameObject>();
        monsterList = new List<GameObject>();
    }



    //파일생성 함수
    // fileData = data의 prefab변수 , Pos = 생성위치
    public GameObject FileForderGet(FileData fileData, Vector3 pos)
    {
        Debug.Log("FileGet함수 작동되었습니다");
        GameObject select = null;

        foreach (GameObject item in fileList)
        {
            //선택한 것이 비활성화 시 재활용
            if (!item.activeSelf)
            {
                select = item;

                //생성위치조정 0.5단위로
                pos = Camera.main.ScreenToWorldPoint(pos);
                pos.x = Mathf.Round(pos.x*2) /2;
                pos.y = Mathf.Round(pos.y*2) /2;
                pos.z = 0;
                select.transform.position = pos;
                
                
                //초기화
                if (select.layer == LayerMask.NameToLayer("File"))
                {
                    select.GetComponent<File>().Init(fileData);
                }
                else if (select.layer == LayerMask.NameToLayer("Forder"))
                {

                }


                select.SetActive(true);
                Debug.Log("원래 있던 녀식을 재활용하여서 소환되었습니다." + select.name);
                break;
            }
        }


        //다 돌고도 못찾으면 새로 Instantiate
        if (!select)
        {
            //생성위치조정 0.5단위로
            pos.x = Mathf.Round(pos.x*2) /2;
            pos.y = Mathf.Round(pos.y*2) /2;
            pos.z = 0;
            select = Instantiate(fileData.Prefab, pos, Quaternion.identity, GameObject.Find("Files").transform);   //Files폴더 자식으로
        

            //초기화
            if (select.layer == LayerMask.NameToLayer("File"))
            {
                select.GetComponent<Scanner>().InitLayer();
                select.GetComponent<File>().Init(fileData);
            }
            else if (select.layer == LayerMask.NameToLayer("Forder"))
            {
                
            }
            
            fileList.Add(select);
        }

        Debug.Log("소환되었습니다." + select.name);
        return select;
    }



    //몬스터 소환
    public GameObject MonsterGet(FileData fileData)
    {
        GameObject select = null;
        Vector3 pos;
        
        //스폰포인트중에 랜덤으로 소환
        Transform spawnpoints = GameObject.Find("SpawnPoints").transform;
        int random = Random.Range(0, spawnpoints.childCount);
        pos = spawnpoints.GetChild(random).position;



        foreach (GameObject item in monsterList)
        {
            //선택한 것이 비활성화 시 재활용
            if (!item.activeSelf)
            {
                select = item;


                select.transform.position = pos;
                select.GetComponent<Monster>().Init(fileData);
                select.SetActive(true);

                Debug.Log("원래 있던 몬스터를 재활용하여서 소환되었습니다." + select.name);
                break;
            }
        }


        //다 돌고도 못찾으면 새로 Instantiate
        if (!select)
        {
            select = Instantiate(fileData.Prefab, pos, Quaternion.identity, GameObject.Find("Monsters").transform);  //Files폴더 자식으로        
            select.GetComponent<Monster>().Init(fileData);      //생성 초기값 설정
            //생성된 몬스터 리스트에 추가
            monsterList.Add(select);
        }

        Debug.Log("몬스터가 소환되었습니다." + select.name);
        return select;
    }



}
