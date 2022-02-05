// GENERATED AUTOMATICALLY FROM 'Assets/MonsterControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MonsterControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MonsterControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MonsterControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""ec1781bf-8fdf-45ed-9619-f70eaf934152"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""701330bb-afa5-49a2-b45c-8c3cc94dbe05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f3f9fa77-220a-4b76-b606-2e45e45cef6f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""742174db-3997-479a-ad2b-847190dc40ae"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""c16af815-a848-497f-beb6-ee7bb0664046"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""cd4a24b6-3302-4328-b751-ef363b83f009"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""131c0f65-cb8e-4264-b7a1-6010dc15e925"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90f0d6a7-8fe7-41ce-883b-c9d76c74544d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fd4a183-5106-4894-bbef-b723139df45f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa2da730-8d74-4842-b1e9-672f7bf0f181"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f6842c8-f8b0-4fe4-86aa-790081136a11"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Rotate = m_GamePlay.FindAction("Rotate", throwIfNotFound: true);
        m_GamePlay_Run = m_GamePlay.FindAction("Run", throwIfNotFound: true);
        m_GamePlay_Attack = m_GamePlay.FindAction("Attack", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Rotate;
    private readonly InputAction m_GamePlay_Run;
    private readonly InputAction m_GamePlay_Attack;
    public struct GamePlayActions
    {
        private @MonsterControls m_Wrapper;
        public GamePlayActions(@MonsterControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Rotate => m_Wrapper.m_GamePlay_Rotate;
        public InputAction @Run => m_Wrapper.m_GamePlay_Run;
        public InputAction @Attack => m_Wrapper.m_GamePlay_Attack;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRotate;
                @Run.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRun;
                @Attack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
