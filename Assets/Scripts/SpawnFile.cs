using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����, ���� ����

public class SpawnFile : MonoBehaviour
{
    
    public GameObject file;
    public FileData fileData;


    public void GetFileForder()
    {
        Debug.Log("GetFileForder �۵��Ǿ����ϴ�");
        GameManager.instance.pool.FileForderGet(fileData, transform.parent.position); //��Ŀ��ġ�� ��ȯ��
    }

    

    
}
