//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/RhythmInput.inputactions
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

public partial class @RhythmInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @RhythmInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RhythmInput"",
    ""maps"": [
        {
            ""name"": ""SongInput"",
            ""id"": ""60c2f2db-bb96-4c94-88fc-b609c3eb4114"",
            ""actions"": [
                {
                    ""name"": ""Lane1Input"",
                    ""type"": ""Button"",
                    ""id"": ""b511c71e-526e-402e-9537-c0ed8a852b1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Lane2Input"",
                    ""type"": ""Button"",
                    ""id"": ""d690a378-ba45-479d-9894-c6cba70b675e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Lane3Input"",
                    ""type"": ""Button"",
                    ""id"": ""2cea142e-8498-4a0f-80e5-dd7870e1de0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Lane4Input"",
                    ""type"": ""Button"",
                    ""id"": ""c2907f3c-155a-41e1-81fe-85b2df103577"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9083b00f-cef2-4980-bce1-7eaaba32766a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane1Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f03e1c3f-26d5-4e7b-9e77-d998565ecd6f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Lane1Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b390cfe-7a88-4741-96c0-6d46e263ee8f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane1Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34355f3d-8725-4280-a2cd-998835463756"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane3Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""190083fc-664d-428e-a383-b948026e24ec"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Lane3Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9b60d33-c81b-4075-b738-cd054fa47e97"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane3Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b79510d-2609-495a-bffd-2b01101931f3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane2Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""253f647e-a888-45ec-8d60-4adbbbf0a68e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Lane2Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""110d54bc-dcca-4c25-851f-3ea2a93e234b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane2Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4853676-c3fd-4ed3-ae02-933a8f500a49"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane4Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d2a52ec-521c-4842-983b-4a0ca9549d15"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Lane4Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31d57f52-e4ed-472c-8b80-931dd285273f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lane4Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // SongInput
        m_SongInput = asset.FindActionMap("SongInput", throwIfNotFound: true);
        m_SongInput_Lane1Input = m_SongInput.FindAction("Lane1Input", throwIfNotFound: true);
        m_SongInput_Lane2Input = m_SongInput.FindAction("Lane2Input", throwIfNotFound: true);
        m_SongInput_Lane3Input = m_SongInput.FindAction("Lane3Input", throwIfNotFound: true);
        m_SongInput_Lane4Input = m_SongInput.FindAction("Lane4Input", throwIfNotFound: true);
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

    // SongInput
    private readonly InputActionMap m_SongInput;
    private ISongInputActions m_SongInputActionsCallbackInterface;
    private readonly InputAction m_SongInput_Lane1Input;
    private readonly InputAction m_SongInput_Lane2Input;
    private readonly InputAction m_SongInput_Lane3Input;
    private readonly InputAction m_SongInput_Lane4Input;
    public struct SongInputActions
    {
        private @RhythmInput m_Wrapper;
        public SongInputActions(@RhythmInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Lane1Input => m_Wrapper.m_SongInput_Lane1Input;
        public InputAction @Lane2Input => m_Wrapper.m_SongInput_Lane2Input;
        public InputAction @Lane3Input => m_Wrapper.m_SongInput_Lane3Input;
        public InputAction @Lane4Input => m_Wrapper.m_SongInput_Lane4Input;
        public InputActionMap Get() { return m_Wrapper.m_SongInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SongInputActions set) { return set.Get(); }
        public void SetCallbacks(ISongInputActions instance)
        {
            if (m_Wrapper.m_SongInputActionsCallbackInterface != null)
            {
                @Lane1Input.started -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane1Input;
                @Lane1Input.performed -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane1Input;
                @Lane1Input.canceled -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane1Input;
                @Lane2Input.started -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane2Input;
                @Lane2Input.performed -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane2Input;
                @Lane2Input.canceled -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane2Input;
                @Lane3Input.started -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane3Input;
                @Lane3Input.performed -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane3Input;
                @Lane3Input.canceled -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane3Input;
                @Lane4Input.started -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane4Input;
                @Lane4Input.performed -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane4Input;
                @Lane4Input.canceled -= m_Wrapper.m_SongInputActionsCallbackInterface.OnLane4Input;
            }
            m_Wrapper.m_SongInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Lane1Input.started += instance.OnLane1Input;
                @Lane1Input.performed += instance.OnLane1Input;
                @Lane1Input.canceled += instance.OnLane1Input;
                @Lane2Input.started += instance.OnLane2Input;
                @Lane2Input.performed += instance.OnLane2Input;
                @Lane2Input.canceled += instance.OnLane2Input;
                @Lane3Input.started += instance.OnLane3Input;
                @Lane3Input.performed += instance.OnLane3Input;
                @Lane3Input.canceled += instance.OnLane3Input;
                @Lane4Input.started += instance.OnLane4Input;
                @Lane4Input.performed += instance.OnLane4Input;
                @Lane4Input.canceled += instance.OnLane4Input;
            }
        }
    }
    public SongInputActions @SongInput => new SongInputActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ISongInputActions
    {
        void OnLane1Input(InputAction.CallbackContext context);
        void OnLane2Input(InputAction.CallbackContext context);
        void OnLane3Input(InputAction.CallbackContext context);
        void OnLane4Input(InputAction.CallbackContext context);
    }
}
