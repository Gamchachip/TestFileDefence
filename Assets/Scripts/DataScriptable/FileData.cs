using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "File Data", menuName = "Scriptable Object/File Data")]


//ëª¬ìŠ¤?„°, ?ŒŒ?¼?˜ ?°?´?„°
//?˜„?¬?Š” ëª¬ìŠ¤?„°?„ ?ŒŒ?¼?„ ?´ ?°?´?„°ë¥? ?‚¬?š©?•˜?Š”?° ?–´?–¤ êµ¬ì¡°ê°? ì¢‹ì??ì§?ë¥? ?˜ ëª¨ë¥´ê² ìŒ,,
public class FileData : ScriptableObject
{
    [SerializeField] private string fileName;
    public string FileName { get { return fileName;}}
    

    [SerializeField] private float hp;
    public float HP { get { return hp;} }
    

    
    [SerializeField] private float damage;
    public float Damage { get { return damage;} }
    

    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed;}}
    

    [SerializeField] private Sprite img;
    public Sprite Image { get { return img;}}


    [SerializeField] private GameObject prefab;
    public GameObject Prefab { get { return prefab;}}

    
    // [SerializeField] private Skill skill;
    // public Skill Skill { get { return skill;}}




}
