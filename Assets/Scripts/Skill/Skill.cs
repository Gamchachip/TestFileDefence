using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스킬 전략패턴
public interface Skill
{
    void Init();
    IEnumerator UseSkill();

    

}
