using UnityEngine;

public class SideWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name == "BeachBall")
        {
             GameManager.Instance.AddScore(gameObject.name);
            hitInfo.gameObject.SendMessage("RestartBall");
        }
        
    }
}
