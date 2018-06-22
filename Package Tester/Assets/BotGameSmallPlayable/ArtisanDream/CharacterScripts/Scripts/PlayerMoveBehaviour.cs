using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    public Player PlayerController;
    private CharacterController controller;
    
    private void Start()
    {
       controller = GetComponent<CharacterController>();
    }

    void Update() {
        PlayerController.PlayerMovePattern.Move(controller, transform);
    }
}