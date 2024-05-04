using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//파일, 폴더 생성

public class SpawnFile : MonoBehaviour
{
    
    public GameObject file;
    public FileData fileData;


    public void GetFileForder()
    {
        Debug.Log("GetFileForder 작동되었습니다");
        GameManager.instance.pool.FileForderGet(fileData, transform.parent.position); //앵커위치로 소환됨
    }

    

    
}
