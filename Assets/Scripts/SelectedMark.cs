using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//파일 선택 시 테두리 오브젝트 활성화
//(나중에는 쉐이더를 이용해서 하는편이 더 좋을듯)
public class SelectedMark : MonoBehaviour
{
    public GameObject unitMarker;


    public void SelectMe()
    {
        unitMarker.SetActive(true);
    }
    public void DeSelectMe()
    {
        unitMarker.SetActive(false);
    }
    public void MoveTo(Vector3 end)
    {
        this.transform.position = end;
    }
    void Update()
    {
    }
}
