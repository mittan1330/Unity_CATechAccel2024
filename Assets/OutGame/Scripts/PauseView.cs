using DG.Tweening;
using UnityEngine;

public class PauseView : MonoBehaviour
{
    [SerializeField] private GameObject pauseUIPrefab;
    [SerializeField] private Transform canvasTransform;

    public GameObject pauseUIInstance;
    public RectTransform PauseRect;

    void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        DOTween.Init(); 
    }

    public void MakePauseUI()
    {
        if (GameManager.isTimeStop != false) return;

        pauseUIInstance = GameObject.Instantiate(pauseUIPrefab, canvasTransform) as GameObject;

        if(hasPauseUIInstance)
        {
            PauseRect = pauseUIInstance.GetComponent<RectTransform>();
            PauseRect.localScale = Vector3.one * 0.2f;
            PauseRect.DOScale(1.5f, 3f).SetEase(Ease.OutBack, 5f);
        }
    }

    public void DestroyPauseUI()
    {
        PauseRect.DOKill();
        Destroy(pauseUIInstance);
    }

    public bool hasPauseUIInstance
    {
        get { return pauseUIInstance != null; }
    }
}
