using DG.Tweening;
using UnityEngine;

public class PauseView : MonoBehaviour
{
    [SerializeField] private GameObject pauseUIPrefab;
    [SerializeField] private Transform canvasTransform;

    public GameObject pauseUIInstance;

    void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        DOTween.Init(); 
    }

    public void makePauseUI()
    {
        pauseUIInstance = GameObject.Instantiate(pauseUIPrefab, canvasTransform) as GameObject;

        if(hasPauseUIInstance)
        {
            RectTransform PauseRect = pauseUIInstance.GetComponent<RectTransform>();
            PauseRect.DOScale(new Vector3(2, 2, 2), 3f);
        }
    }

    public void DestroyPauseUI()
    {
        Destroy(pauseUIInstance);
    }

    public bool hasPauseUIInstance
    {
        get { return pauseUIInstance != null; }
    }
}
