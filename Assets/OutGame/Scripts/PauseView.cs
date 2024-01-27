using DG.Tweening;
using UnityEngine;

public class PauseView : MonoBehaviour
{
    [SerializeField] private GameObject pauseUIPrefab;
    [SerializeField] private Transform canvasTransform;
    [SerializeField] public GameObject pauseUIInstance;

    void Awake()
    {
        DOTween.Init();
    }

    public void makePauseUI()
    {
        pauseUIInstance = GameObject.Instantiate(pauseUIPrefab, canvasTransform) as GameObject;
        RectTransform PauseRect = pauseUIInstance.GetComponent<RectTransform>();
        PauseRect.DOScale(new Vector3(2, 2, 2), 3f);
    }

    public void destroyPauseUI()
    {
        Destroy(pauseUIInstance);
    }
}
