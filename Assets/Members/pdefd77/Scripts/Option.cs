using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    private Canvas optionCanvas;
    private GameObject curtain;

    private Button[] buttons;

    private void Awake()
    {
        optionCanvas = GetComponent<Canvas>();
        curtain = GetComponentInChildren<Curtain>().gameObject;
        buttons = GetComponentsInChildren<Button>();
    }

    private void Start()
    {
        SetButtons();
        LoadBinding();

        curtain.SetActive(false);
        optionCanvas.enabled = Managers.InputManager.IsOption;
    }

    private void Update()
    {
        ToggleOption();
    }

    private void SetButtons()
    {
        foreach (Button button in buttons)
        {
            switch (button.name)
            {
                case "Left":
                    button.onClick.AddListener(() => ChangeKey(button, ChangeLeft));
                    break;
                case "Right":
                    button.onClick.AddListener(() => ChangeKey(button, ChangeRight));
                    break;
                case "Jump":
                    button.onClick.AddListener(() => ChangeKey(button, ChangeJump));
                    break;
                case "Parry":
                    button.onClick.AddListener(() => ChangeKey(button, ChangeParry));
                    break;
                case "Special":
                    button.onClick.AddListener(() => ChangeKey(button, ChangeSpecial));
                    break;
                case "Reset":
                    button.onClick.AddListener(() => ResetBindings());
                    break;
                case "Quit":
                    button.onClick.AddListener(() => QuitGame());
                    break;
                default:
                    break;
            }
        }

        buttons = buttons.Take(5).ToArray(); // 리셋버튼, 종료버튼은 제외 (바인딩 버튼만 남기기)
    }

    private void LoadBinding()
    {
        if (PlayerPrefs.HasKey("bindings"))
        {
            Managers.InputManager.MyPlayerInputSystem.LoadBindingOverridesFromJson(PlayerPrefs.GetString("bindings"));
        }

        RenewButtons(buttons);
    }

    private void ToggleOption()
    {
        if (curtain.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionCanvas.enabled = Managers.InputManager.IsOption = !Managers.InputManager.IsOption;

            if (Managers.InputManager.IsOption)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    private void ChangeKey(Button button, Action<Button> action)
    {
        if (curtain.activeSelf) return;

        curtain.SetActive(true);
        button.transform.GetComponent<Image>().color = new(0.7f, 1f, 0.7f);

        action(button);
    }

    private void ChangeLeft(Button button)
    {
        Managers.InputManager.MoveAction.Disable();

        Managers.InputManager.MoveAction.PerformInteractiveRebinding(1).WithCancelingThrough("/Keyboard/Escape").WithControlsExcluding("Mouse").OnComplete(operation =>
        {
            Managers.InputManager.MoveAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .OnCancel(operation =>
        {
            Managers.InputManager.MoveAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .Start();
    }

    private void ChangeRight(Button button)
    {
        Managers.InputManager.MoveAction.Disable();

        Managers.InputManager.MoveAction.PerformInteractiveRebinding(2).WithCancelingThrough("/Keyboard/Escape").WithControlsExcluding("Mouse").OnComplete(operation => {
            Managers.InputManager.MoveAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .OnCancel(operation =>
        {
            Managers.InputManager.MoveAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .Start();
    }

    private void ChangeJump(Button button)
    {
        Managers.InputManager.JumpAction.Disable();

        Managers.InputManager.JumpAction.PerformInteractiveRebinding(0).WithCancelingThrough("/Keyboard/Escape").WithControlsExcluding("Mouse").OnComplete(operation => {
            Managers.InputManager.JumpAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .OnCancel(operation =>
        {
            Managers.InputManager.JumpAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .Start();
    }

    private void ChangeParry(Button button)
    {
        Managers.InputManager.ParryAction.Disable();

        Managers.InputManager.ParryAction.PerformInteractiveRebinding(0).WithCancelingThrough("/Keyboard/Escape").WithControlsExcluding("Mouse").OnComplete(operation => {
            Managers.InputManager.ParryAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .OnCancel(operation =>
        {
            Managers.InputManager.ParryAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .Start();
    }

    private void ChangeSpecial(Button button)
    {
        Managers.InputManager.SpecialAction.Disable();

        Managers.InputManager.SpecialAction.PerformInteractiveRebinding(0).WithCancelingThrough("/Keyboard/Escape").WithControlsExcluding("Mouse").OnComplete(operation => {
            Managers.InputManager.SpecialAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .OnCancel(operation =>
        {
            Managers.InputManager.SpecialAction.Enable();
            operation.Dispose();
            RenewButtons(button);
        })
        .Start();
    }

    private void ResetBindings()
    {
        if (curtain.activeSelf) return;

        Managers.InputManager.MyPlayerInputSystem.RemoveAllBindingOverrides();
        PlayerPrefs.DeleteKey("bindings");

        RenewButtons(buttons);
    }

    private void RenewButtons(params Button[] renewButtons)
    {
        foreach (Button button in renewButtons)
        {
            button.transform.GetComponent<Image>().color = new(1f, 1f, 1f);

            switch (button.name)
            {
                case "Left":
                    button.GetComponentInChildren<TextMeshProUGUI>().text = Managers.InputManager.MoveAction.GetBindingDisplayString(1);
                    break;
                case "Right":
                    button.GetComponentInChildren<TextMeshProUGUI>().text = Managers.InputManager.MoveAction.GetBindingDisplayString(2);
                    break;
                case "Jump":
                    button.GetComponentInChildren<TextMeshProUGUI>().text = Managers.InputManager.JumpAction.GetBindingDisplayString(0);
                    break;
                case "Parry":
                    button.GetComponentInChildren<TextMeshProUGUI>().text = Managers.InputManager.ParryAction.GetBindingDisplayString(0);
                    break;
                case "Special":
                    button.GetComponentInChildren<TextMeshProUGUI>().text = Managers.InputManager.SpecialAction.GetBindingDisplayString(0);
                    break;
                default:
                    break;
            }
        }

        StartCoroutine(OffCurtain());

        PlayerPrefs.SetString("bindings", Managers.InputManager.MyPlayerInputSystem.SaveBindingOverridesAsJson());
        PlayerPrefs.Save();
    }

    private IEnumerator OffCurtain() // 키바인딩 중에 Esc를 눌렀을 때 취소됨과 동시에 설정창이 꺼지지 않도록
    {
        yield return new WaitForEndOfFrame();

        curtain.SetActive(false);

        yield break;
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
