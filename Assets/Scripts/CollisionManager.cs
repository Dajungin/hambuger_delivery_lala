using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    int hamburgerLayer, glassLayer, playerLayer;

    void Start()
    {
        // 각 오브젝트의 레이어 설정
        hamburgerLayer = LayerMask.NameToLayer("Hamburger");
        glassLayer = LayerMask.NameToLayer("glass");
        playerLayer = LayerMask.NameToLayer("Player");

        // Hamburger와 모든 레이어의 충돌을 무시하게 설정
        for (int i = 0; i < 6; i++)
        {
            if (i != glassLayer)
            {
                Physics2D.IgnoreLayerCollision(hamburgerLayer, i, true);
            }
        }

        // Glass가 Hamburger와 Player를 제외한 모든 레이어를 통과하게 설정
        for (int i = 0; i < 6; i++)
        {
            if (i != hamburgerLayer && i != playerLayer)
            {
                Physics2D.IgnoreLayerCollision(glassLayer, i, true);
            }
        }
    }
}
