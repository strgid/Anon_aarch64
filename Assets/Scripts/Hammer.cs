using UnityEngine;

public class Hammer : MonoBehaviour
{
    // 用于UI元素的 RectTransform
    private RectTransform rectTransform;
    private Animator animator;
    public GameObject bonk;

    // 初始化时获取 RectTransform 组件
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Cursor.visible = false;
        animator = GetComponent<Animator>();
    }

    // 每帧更新 UI 元素的位置，使其跟随鼠标
    private void Update()
    {
        FollowCursor();
        if (Input.GetMouseButtonDown(0))
        {
           
            animator.Play("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Mole m = hit.collider.GetComponent<Mole>();
                if ( m!= null)
                {
                   
                    SoundManager.Instance.PlaySound("Sounds/bonk");
                    Bonk();
                    m.Click();
                }
            }
        }
    }
    public void Bonk()
    {
        GameObject b = Instantiate(bonk);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        b.transform.position = worldPos;
        TimeDelay.Instance.Delay(0.3f,()=>Destroy(b));
    }
    private void FollowCursor()
    {
        
        rectTransform.position = Input.mousePosition;
    }
}
