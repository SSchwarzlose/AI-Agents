// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerController.cs" author="Sascha Schwarzlose">
//  
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(move * Speed * Time.deltaTime);
    }
}
