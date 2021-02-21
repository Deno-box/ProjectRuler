using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private PlayerStatusData statusData = null;
    public PlayerStatusData StatusData { get { return statusData; } }
    [SerializeField]
    private Animator animator = null;
    public Animator PlayerAnimator { get { return animator; } }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
