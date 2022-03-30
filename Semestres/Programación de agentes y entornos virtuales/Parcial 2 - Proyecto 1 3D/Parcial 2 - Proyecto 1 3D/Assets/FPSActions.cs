//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/FPSActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @FPSActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @FPSActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FPSActions"",
    ""maps"": [
        {
            ""name"": ""FPSMap"",
            ""id"": ""a13bb5c2-9c85-45fc-968e-c46bfc46f90d"",
            ""actions"": [
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8794d636-65e8-414f-8ea8-b48dddadc8c5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveHorizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""07be655f-222c-4c31-bf31-82ff66ba8803"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2ffa193b-8e41-4e53-90a1-f38a40854847"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b259daca-48e4-4b4a-955d-7264f9b23ff0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d5a1a405-c86f-4d5b-93bb-75e0f0e7ee93"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e07bfec8-e767-41fd-be31-6dbe87761f19"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""39c3e5fe-74ed-47bb-a5c9-22b4e699ef54"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc04f438-97ae-4e9f-ade0-b27615c6541f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""adee15a3-8bd8-4d80-822d-23b5b8d4710b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""61ee8176-5960-4a46-ab83-f4c4a0c8cd12"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FPSMap
        m_FPSMap = asset.FindActionMap("FPSMap", throwIfNotFound: true);
        m_FPSMap_MoveCamera = m_FPSMap.FindAction("MoveCamera", throwIfNotFound: true);
        m_FPSMap_MoveHorizontal = m_FPSMap.FindAction("MoveHorizontal", throwIfNotFound: true);
        m_FPSMap_Jump = m_FPSMap.FindAction("Jump", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // FPSMap
    private readonly InputActionMap m_FPSMap;
    private IFPSMapActions m_FPSMapActionsCallbackInterface;
    private readonly InputAction m_FPSMap_MoveCamera;
    private readonly InputAction m_FPSMap_MoveHorizontal;
    private readonly InputAction m_FPSMap_Jump;
    public struct FPSMapActions
    {
        private @FPSActions m_Wrapper;
        public FPSMapActions(@FPSActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCamera => m_Wrapper.m_FPSMap_MoveCamera;
        public InputAction @MoveHorizontal => m_Wrapper.m_FPSMap_MoveHorizontal;
        public InputAction @Jump => m_Wrapper.m_FPSMap_Jump;
        public InputActionMap Get() { return m_Wrapper.m_FPSMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSMapActions set) { return set.Get(); }
        public void SetCallbacks(IFPSMapActions instance)
        {
            if (m_Wrapper.m_FPSMapActionsCallbackInterface != null)
            {
                @MoveCamera.started -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnMoveCamera;
                @MoveHorizontal.started -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.performed -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnMoveHorizontal;
                @MoveHorizontal.canceled -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnMoveHorizontal;
                @Jump.started -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FPSMapActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_FPSMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @MoveHorizontal.started += instance.OnMoveHorizontal;
                @MoveHorizontal.performed += instance.OnMoveHorizontal;
                @MoveHorizontal.canceled += instance.OnMoveHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public FPSMapActions @FPSMap => new FPSMapActions(this);
    public interface IFPSMapActions
    {
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnMoveHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
