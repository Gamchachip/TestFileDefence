using UnityEngine;
using System.Collections;
using System.Linq;



//바꿔야함 따다다닥해야하는데
//바로 딱 나옴
public class SkillLightning : MonoBehaviour, Skill
{
    float cooltime = 3f;
    // 번개를 그리는 간격
    float drawInterval = 0.1f;

    //그리는 컴포넌트
    LineRenderer lineRenderer;  

    //몇 명때릴지
    int targetCount = 4;
    // 타겟
    public Transform target;
    public Transform [] targets;
    bool gameStart = true;
    public void Init()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.07f;
        lineRenderer.sortingOrder = 5;
    }
    void Start()
    {
        Init(); //초기화
        StartCoroutine(Target());
        StartCoroutine(GetNearestTargets());
        StartCoroutine(UseSkill());
        // 번개 그리기 코루틴 시작


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameStart = false;
        }
    }
        //몬스터찾기 쿨타임 마다 실행
        //범위 내 가장가까운 몬스터찾기
        IEnumerator Target()
        {
            while (gameStart){
            yield return null;
            
            target = GetComponent<Scanner>().GetNearest();
            yield return new WaitForSeconds(cooltime-0.1f);  //이렇게하면 계속 클래스 생성되서 가비지콜렉터 폭발임 캐싱해야함
            }
        }

        //범위내 가까운 순서 몬스터 배열
        IEnumerator GetNearestTargets()
        {   
            while(gameStart)
            {
                yield return null;

                targets = GetComponent<Scanner>().GetNearestTargets(targetCount);
                yield return new WaitForSeconds(cooltime-0.1f);
            }
        }


    // 번개 그리기 코루틴 함수
    public IEnumerator UseSkill()
    {
        Debug.Log("왜안돼는거임");
        while (gameStart)
        {   
            yield return null;
            // 타겟이 있을 때만 번개를 그림
            if (target != null)
            {
                // 번개를 그림
                Debug.Log(target.transform.name);
                StartCoroutine(DrawLightning(targets));
                // 지정된 시간만큼 대기
                yield return new WaitForSeconds(cooltime);

            }
        }
    }


    // 번개를 그리는 함수
    private IEnumerator DrawLightning(Transform [] nearTargets)
    {
        Debug.Log("그려지는중");
        Debug.Log(nearTargets.Length);
        

        //타겟들이 이어지도록 선 그리기
        lineRenderer.positionCount = 1; //자신부터 이어지도록 하려고 +1함
        lineRenderer.SetPosition(0 ,transform.position);

        for (int i = 0; i < nearTargets.Length; i++)
        {
            lineRenderer.positionCount ++;
            lineRenderer.SetPosition(i+1 ,nearTargets[i].position);
            yield return new WaitForSeconds(0.1f);
        }
        
        // 선 지우기
        lineRenderer.positionCount = 0;



    }   

    //라인렌더러 띠용띠용 효과
    IEnumerator LineWidth()
    {
        lineRenderer.SetWidth(0.1f,0.1f);
        yield return new WaitForSeconds(0.05f);
    }




}
