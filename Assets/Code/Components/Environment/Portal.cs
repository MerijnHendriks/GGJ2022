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

    private Timer timer = new Timer();
    [SerializeField]
    private GameObject nian;

    private void Update()
    {
        //Debug.Log(timer.Done() + " " + meshRenderer.isVisible);
        if (timer.Done() && PortalIsInView())
        {
            timer.Set(3);
            GameObject instance = Instantiate(nian, transform.position + transform.right + transform.up, Quaternion.identity, transform);
            if (transform.position.x > 0)
                instance.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private bool PortalIsInView()
    {
        Vector2 screenPosition = Player.GetCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x > 0 && screenPosition.x < Player.GetCamera.pixelWidth)
            if (screenPosition.y > 0 && screenPosition.y < Player.GetCamera.pixelHeight)
                return true;
        return false;
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
