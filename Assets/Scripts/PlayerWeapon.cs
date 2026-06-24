using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
    

    public class PlayerWeapon : MonoBehaviour
    {

        bool isfiring = false;
        [SerializeField] GameObject[] laser;
        [SerializeField] RectTransform crosshair;
        [SerializeField] Transform TargetPoint;
        [SerializeField] float targetdistance = 100f; 


    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
        {
            ProcessFiring();
            movecrosshair();
            MoveTargetPoint();
            aimlasers();
        }
        public void OnFire(InputValue value)
        {
            isfiring = value.isPressed;
        }

        void ProcessFiring()
        {
            // var emissionModule = laser[0].GetComponent<ParticleSystem>().emission;
            // emissionModule.enabled = isfiring;

            // var emissionModule = laser[1].GetComponent<ParticleSystem>().emission;
            // emissionModule.enabled = isfiring;
            // we can go with this method but we can also use foreach loop here 

            foreach (GameObject laser in laser)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = isfiring;
            }
        }

    void movecrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    void MoveTargetPoint()  
    {
        Vector3 targetpointposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetdistance);    
        TargetPoint.position = Camera.main.ScreenToWorldPoint(targetpointposition);
    }

    void aimlasers()
    {
        foreach (GameObject laser in laser)
        {
            Vector3 firedirection = TargetPoint.position - transform.position;
            Quaternion rotationtotarget = Quaternion.LookRotation(firedirection);
            laser.transform.rotation = rotationtotarget;
        }
    }
    }
