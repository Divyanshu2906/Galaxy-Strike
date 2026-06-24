using Unity.VisualScripting;
using UnityEngine;

public class ColllisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX; 
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyVFX, transform.position, destroyVFX.transform.rotation);
        Destroy(gameObject);
    }
}
