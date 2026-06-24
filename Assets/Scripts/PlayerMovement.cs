using System;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlspeed = 10f;
    [SerializeField] float xclamprange = 30f;
    [SerializeField] float yclamprange = 30f;

    [SerializeField] float controlRotation = 20f;
    [SerializeField] float Rotationspeed = 10f;
    [SerializeField] float controlpitch = 18f;
    
    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xoffset = movement.x * controlspeed * Time.deltaTime;
        float yoffset = movement.y * controlspeed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xoffset;
        float rawYpos = transform.localPosition.y + yoffset;
        float clamedXpos = Mathf.Clamp(rawXpos, -xclamprange, xclamprange);
        float clampedYpos = Math.Clamp(rawYpos, -yclamprange, yclamprange);
        transform.localPosition = new Vector3(clamedXpos, clampedYpos, 0f);
    }

    private void ProcessRotation()
    {
        float pitch = controlpitch * movement.y;
        float roll = -controlRotation * movement.x;
        quaternion targetrotation = quaternion.Euler(pitch,0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetrotation, Rotationspeed * Time.deltaTime);
    }
    
}
