using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;



//드래그 시 사각형 그리기
public class DrawDragBox : MonoBehaviour 
{


    [Header("드래그 변수")]
    public GameObject square;

    Vector3 startPos, nowPos, deltaPos;
    float deltaX, deltaY;



    void Start()
    {
    }
    void Update()
    {
        #region 사각형 그리기

        if (!GameManager.instance.selectManager.isSelecting)    // 파일선택 중일시 파일이동하면서 드래그박스 그리면 안됨
        {
            /*사각형 그리기 원리는 대충
            square의 transform.position(위치)은 startPos와 nowPos의 중간 좌표,
            transform.localscale(크기)은 deltaX와 deltaY값
            */
            if (Input.GetMouseButtonDown(0)) // 눌렀을 때 영역 그리기 시작
            {
                Debug.Log("그리기 시작;");
                GameManager.instance.selectManager.isdrag = true;
                startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
                square.transform.position = startPos;
            }



                if (Input.GetMouseButton(0) && !GameManager.instance.selectManager.isSelecting)    // 드래그 중
                {
                    Debug.Log("그리기 중");
                    nowPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
                    if (Vector3.Distance(startPos, nowPos) > 0.5f)
                    {
                        square.SetActive(true);
                    }

                    deltaX = Mathf.Abs(nowPos.x - startPos.x);
                    deltaY = Mathf.Abs(nowPos.y - startPos.y);
                    deltaPos = startPos + (nowPos - startPos) / 2;
                    square.transform.position = deltaPos;
                    square.transform.localScale = new Vector3(deltaX, deltaY, 0);

                }
                if (Input.GetMouseButtonUp(0)) // 드래그가 끝나면 영역 사각형 삭제
                {
                    if (GameManager.instance.selectManager.isSelecting)
                        return;
                    GameManager.instance.selectManager.isdrag = false;

                    Debug.Log("그리기 완");
                    square.SetActive(false);
                }


        }
        #endregion




    }
}
