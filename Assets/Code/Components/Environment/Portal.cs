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
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Vector3 nextPortal;
    [SerializeField]
    private BoxCollider boxCollider;

    private Timer timer;
    [SerializeField]
    private GameObject nian;

    private void Update()
    {
        return;
        if (timer.Done() && meshRenderer.isVisible)
        {
            timer.Set(3);
            Instantiate(nian, transform.position + transform.right, Quaternion.identity);
        }
    }

    public void Disable()
    {
        boxCollider.enabled = false;
    }

    public void SetNextPortal(Vector3 portal)
    {
        nextPortal = portal;
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

        ActorManager.GetPlayer.Teleport(nextPortal + Vector3.up + Vector3.right);
    }
}
