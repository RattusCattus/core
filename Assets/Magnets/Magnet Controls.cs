//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Magnets/Magnet Controls.inputactions
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

public partial class @MagnetControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MagnetControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Magnet Controls"",
    ""maps"": [
        {
            ""name"": ""Magnet"",
            ""id"": ""fc203ec1-ca7e-4814-976f-42ccddabf27f"",
            ""actions"": [
                {
                    ""name"": ""StartMagnet"",
                    ""type"": ""Value"",
                    ""id"": ""cf2044be-58da-4107-803a-44fb7e8a6382"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CancelMagnet"",
                    ""type"": ""Button"",
                    ""id"": ""d5b3e477-7811-416d-8867-90b1a352fa48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4f5902fd-8264-45de-b9ce-f76b065e1388"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartMagnet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ec4be92-1d0e-4013-8c81-b3ce300af40c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelMagnet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Magnet
        m_Magnet = asset.FindActionMap("Magnet", throwIfNotFound: true);
        m_Magnet_StartMagnet = m_Magnet.FindAction("StartMagnet", throwIfNotFound: true);
        m_Magnet_CancelMagnet = m_Magnet.FindAction("CancelMagnet", throwIfNotFound: true);
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

    // Magnet
    private readonly InputActionMap m_Magnet;
    private List<IMagnetActions> m_MagnetActionsCallbackInterfaces = new List<IMagnetActions>();
    private readonly InputAction m_Magnet_StartMagnet;
    private readonly InputAction m_Magnet_CancelMagnet;
    public struct MagnetActions
    {
        private @MagnetControls m_Wrapper;
        public MagnetActions(@MagnetControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartMagnet => m_Wrapper.m_Magnet_StartMagnet;
        public InputAction @CancelMagnet => m_Wrapper.m_Magnet_CancelMagnet;
        public InputActionMap Get() { return m_Wrapper.m_Magnet; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MagnetActions set) { return set.Get(); }
        public void AddCallbacks(IMagnetActions instance)
        {
            if (instance == null || m_Wrapper.m_MagnetActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MagnetActionsCallbackInterfaces.Add(instance);
            @StartMagnet.started += instance.OnStartMagnet;
            @StartMagnet.performed += instance.OnStartMagnet;
            @StartMagnet.canceled += instance.OnStartMagnet;
            @CancelMagnet.started += instance.OnCancelMagnet;
            @CancelMagnet.performed += instance.OnCancelMagnet;
            @CancelMagnet.canceled += instance.OnCancelMagnet;
        }

        private void UnregisterCallbacks(IMagnetActions instance)
        {
            @StartMagnet.started -= instance.OnStartMagnet;
            @StartMagnet.performed -= instance.OnStartMagnet;
            @StartMagnet.canceled -= instance.OnStartMagnet;
            @CancelMagnet.started -= instance.OnCancelMagnet;
            @CancelMagnet.performed -= instance.OnCancelMagnet;
            @CancelMagnet.canceled -= instance.OnCancelMagnet;
        }

        public void RemoveCallbacks(IMagnetActions instance)
        {
            if (m_Wrapper.m_MagnetActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMagnetActions instance)
        {
            foreach (var item in m_Wrapper.m_MagnetActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MagnetActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MagnetActions @Magnet => new MagnetActions(this);
    public interface IMagnetActions
    {
        void OnStartMagnet(InputAction.CallbackContext context);
        void OnCancelMagnet(InputAction.CallbackContext context);
    }
}
