using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(menuName = "Stats/EnnemyStats")]
public class EnnemyStats : ScriptableObject
{
    public float moveSpeed;
    public int lookRange;
    public int lookSphereCastRadius;
    public int attackRange;
    public int attackRate;
    public int attackForce;
    public int attackDamage;
    public int searchDuration;
    public int searchingTurnSpeed;
    public int lifePoints;
}
