using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyVFX, transform.position, destroyVFX.transform.rotation);
        Destroy(gameObject);
    }
}