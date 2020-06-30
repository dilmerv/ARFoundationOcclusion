using DilmerGames.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI objectCountText;

    [SerializeField]
    private TextMeshProUGUI fpsText;

    [SerializeField]
    private Button qualityButton;

    private float deltaTime;

    private TextMeshProUGUI qualityButtonText;

    private void Awake()
    {
        qualityButtonText = qualityButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateQualityText();
    }

    public void UpdateObjectCountText(string newInfo)
    {
        objectCountText.text = newInfo;
    }

    public void ToggleQuality()
    {
        EnvironmentDepthMode depthMode = AROcclusionQualityController.Instance.GetCurrentDepthMode();

        switch (depthMode)
        {
            case EnvironmentDepthMode.Disabled:
                AROcclusionQualityController.Instance.ChangeQualityTo(EnvironmentDepthMode.Fastest);
                break;
            case EnvironmentDepthMode.Fastest:
                AROcclusionQualityController.Instance.ChangeQualityTo(EnvironmentDepthMode.Medium);
                break;
            case EnvironmentDepthMode.Medium:
                AROcclusionQualityController.Instance.ChangeQualityTo(EnvironmentDepthMode.Best);
                break;
            case EnvironmentDepthMode.Best:
                AROcclusionQualityController.Instance.ChangeQualityTo(EnvironmentDepthMode.Disabled);
                break;
        }

        UpdateQualityText();
    }

    private void UpdateQualityText()
    {
        EnvironmentDepthMode newDepthMode = AROcclusionQualityController.Instance.GetCurrentDepthMode();
        qualityButtonText.text = $"Quality {newDepthMode}";
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
    }
}
