using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int level;
    public float NowExp = 0;
    public float MaxExp = 10f;
    
    public void PlayerExp(int _PlusExp)
    {
        NowExp += _PlusExp;
        if(MaxExp <= NowExp)
        {
            NowExp -= MaxExp;

        }
    }
     
    
}
