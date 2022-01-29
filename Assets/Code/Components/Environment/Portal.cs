using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject openPortal;
    [SerializeField]
    private GameObject closedPortal;

    [SerializeField]
    private Transform nextPortal;

    private void Update()
    {
        //For Testing
        //if (InputController.IsPressed("TEST"))
        //    OpenDoor();
    }

    public void OpenDoor()
    {
        closedPortal.SetActive(false);
        openPortal.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" || openPortal.activeInHierarchy || transform.position.x < 0)
            return;

        ActorManager.GetPlayer.Teleport(nextPortal.position + Vector3.up + Vector3.right);
    }
}
