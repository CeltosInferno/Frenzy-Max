using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(menuName = "Stats/EnnemyStats")]
public class EnnemyStats : ScriptableObject
{
    public float moveSpeed;
    public float lookRange;
    public float lookSphereCastRadius;
    public float attackRange;
    public int attackRate;
    public int attackForce;
    public int attackDamage;
    public int searchDuration;
    public int searchingTurnSpeed;
    public int lifePoints;
}
