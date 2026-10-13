using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("追従対象")]
    [SerializeField] private Transform player;

    [Header("カメラ設定")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 12f, -8f);
    [SerializeField] private float followSpeed = 5f;

    private void LateUpdate()
    {
        if (player == null) return;

        // プレイヤーから一定距離離れた位置
        Vector3 targetPosition = player.position + offset;

        // 滑らかに追従
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // プレイヤーの方向を見る
        transform.LookAt(player.position);
    }
}
