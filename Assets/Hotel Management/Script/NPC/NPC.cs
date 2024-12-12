using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class NPC : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(NameTag.Bed))
        {
            NPCController.Instance.NPCLeaveRoom();
            
        }
            
    }







}
