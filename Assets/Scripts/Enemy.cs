using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] int HitPoints = 3;
    [SerializeField] int ScoreValue = 10;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard =  FindFirstObjectByType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        HitPoints--;

        if (HitPoints <= 0)
        {
            scoreboard.ModifyScore(ScoreValue);
            Instantiate(destroyVFX, transform.position, quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}