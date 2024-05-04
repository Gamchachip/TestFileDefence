using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;



//범위 중 가장 가까운 타겟 (transform)반환
//범위 중 가장 가까운 타겟배열
public class Scanner : MonoBehaviour
{
    public float scanRange = 50;    //탐색 범위
    public LayerMask targetLayer;   //탐색 레이어
    public RaycastHit2D[] targets;  //탐색된 정보들




    //targetLayer 조정
    public void InitLayer()
    {
        
        //파일 -> 몬스터노림
        if (1 << this.gameObject.layer ==  1<<LayerMask.NameToLayer("File"))
        {
            Debug.Log("타겟은 몬스터입니다");
            targetLayer = 1 << LayerMask.NameToLayer("Monster");
        }

        //몬스터 -> 파일,폴더노림
        else if (1 << this.gameObject.layer == 1<<LayerMask.NameToLayer("Monster"))
        {
            Debug.Log("타겟은 파일,폴더입니다");
            targetLayer = GameManager.instance.selectManager.fileForderLayer;
            
        }
    }


    //가장 가까운 타겟 반환
    public Transform GetNearest()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        Transform nearTarget = null;
        float diff = 100f;

        foreach (var item in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = item.transform.position;

            float curDiff = Vector3.Distance(myPos, targetPos);
            if (curDiff < diff)
            {
                diff = curDiff;
                nearTarget = item.transform;
            }
        }
        return nearTarget;
    }


    //가까운 순서로 된 배열 targetLength크기만큼 반환 
    public Transform[] GetNearestTargets(int targetCount)
    {
        //범위 내 탐색하고 정렬해서 targetLength만큼의 길이배열로 반환 
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);

        Transform [] sortedTargets = null;
        //LINQ  정렬된 형태로  
        sortedTargets = 
                        (from target in targets    //RaycastHit2D [] 에서 하나씩
                        orderby (target.transform.position - transform.position).sqrMagnitude       //나랑 거리 순으로 정렬해서
                        select target.transform).Take(targetCount).ToArray();  //transform요소로 targetCount 만큼의 길이인 배열을 반환



        return sortedTargets;
    }

}
