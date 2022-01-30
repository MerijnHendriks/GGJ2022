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

    private Portal nextPortal;
    private Portal leftPortal;
    [SerializeField]
    private BoxCollider boxCollider;

    private Timer timer = new Timer();
    [SerializeField]
    private GameObject nian;
    private static Portal[] currentFloor = new Portal[2];

    private void Update()
    {
        //Debug.Log(timer.Done() + " " + meshRenderer.isVisible);
        if (!PortalIsInView())
            return;
        if (timer.Done() && !PlayerIsTooClose() && PortalIsOnCurrentFloor())
        {
            timer.Set(3);
            GameObject instance = Instantiate(nian, transform.position + transform.right + transform.up, Quaternion.identity, transform);
            if (transform.position.x > 0)
                instance.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Debug.Log(currentFloor[0] + " : " + currentFloor[1]);
    }

    private bool PortalIsOnCurrentFloor()
    {
        for (int i = 0; i < currentFloor.Length; i++)
            if (currentFloor[i] == this)
                return true;
        return false;
    }

    private bool PortalIsInView()
    {
        Vector2 screenPosition = Player.GetCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x > 0 && screenPosition.x < Player.GetCamera.pixelWidth)
            if (screenPosition.y > 0 && screenPosition.y < Player.GetCamera.pixelHeight)
                return true;
        return false;
    }

    private bool PlayerIsTooClose()
    {
        return Vector3.Distance(ActorManager.GetPlayer.transform.position, transform.position) < 5;
    }

    public void Disable()
    {
        boxCollider.enabled = false;
    }

    public void SetNextPortal(Portal portal)
    {
        nextPortal = portal;
    }

    public void SetLeftPortal(Portal portal)
    {
        leftPortal = portal;
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

        currentFloor[0] = nextPortal;
        currentFloor[1] = nextPortal.leftPortal;
        ActorManager.GetPlayer.Teleport(nextPortal.transform.position + Vector3.up + Vector3.right);
    }
}
