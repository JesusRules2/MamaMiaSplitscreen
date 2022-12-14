//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Pikachu"",
            ""id"": ""1b50c00d-6094-422c-a1b0-a27f6d169594"",
            ""actions"": [
                {
                    ""name"": ""Jump2"",
                    ""type"": ""Button"",
                    ""id"": ""8ee215e0-2a69-4b2f-a841-0ac48994bda7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""39c1c323-c578-4c77-96cf-37199f0c9d7a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""View"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1ad5ba2b-e518-459f-8cc9-9b05361bb73e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""93f4144c-0d0c-4b1b-a79b-52fa90673c01"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""862b4500-f4e1-4a4f-8cf4-48d2d53ea64a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""deb0aeda-ef92-472d-8858-47ed516af12b"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""03153029-5c22-48a0-b36f-3729d8fbb5b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d27abdc8-4a54-4ed4-9ac1-02e035a9551a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""87547219-cfcc-44ab-be4d-9b26ee57178c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23289d71-30e9-4d5d-ab98-4cb7e514692e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1651a0d9-c1bb-4bac-bed6-1b2e12ac4a60"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""79a2b541-1a3b-4d8e-ad84-9c9d7ed0b21a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01c14bf8-f57c-49a4-9cc7-9b90a4481a93"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.6,y=0.6)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af730193-88b6-4d15-bbd8-9646eb625382"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mario"",
            ""id"": ""5b98a9e1-8363-4333-aec7-48bde7ea6b6e"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cc6ca5c6-dd78-4e61-b7ca-1fa98443795c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""40bd0dfe-d896-4b41-bb0f-4c1254bd4725"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""View"",
                    ""type"": ""PassThrough"",
                    ""id"": ""74114640-5289-45c4-8253-34df46691e56"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Value"",
                    ""id"": ""3441008a-9659-4547-8719-f9f5817009e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""7cb5fdcb-ee10-4b4b-bb9b-ce3671813ac0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""be48f79f-f9bb-4d48-8513-bf3faa597cfd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""661ac518-f2cc-4ef8-a2b3-8ed1f1077c12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""3cd715a2-468a-4086-b3a7-09948a7f48bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""B-Button"",
                    ""type"": ""Button"",
                    ""id"": ""a628d2b7-a032-421c-9987-68ab59abf543"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5212eac8-d0f2-4294-aaf3-56c18f04a6ce"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4faa9de-7b1a-43bb-9249-549edabe9b47"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""fcf8d2a1-bba0-44ab-8299-260f90c2f3af"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""15329f64-2573-4cd3-ab74-f0cb468b76fc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""13a062fc-3727-4fd3-926f-916426f1fa95"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""221509f5-6605-4500-b784-0397717dd712"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c4eaa7e3-28b1-4f20-9e62-a630f6b31526"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4a7e5268-b0d6-4981-9de2-6d129af0c136"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd0a9303-b902-40fb-b010-5d17b9a572d7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.4,y=0.4)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e19ae778-776f-4105-a708-2722d014e775"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.012,y=0.012)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48f0c356-5814-4ea0-9789-ec2769254ea8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ebda5ff-2a9f-419d-a969-eaaa91a3d512"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d04e512f-d5f3-4b57-b329-9a32264bd8c4"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b8f4095-01cd-43c7-b56e-2f3a7e1c261e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b543cb2d-f53a-4328-91bd-bfdeae67101c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb594bc0-dd5b-4aaf-b2d5-9d87bb95eea7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67486864-86b7-4553-8851-7c3f51818e83"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3064cba7-4b5d-4143-905d-7fdb8094e271"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e22f1b23-475d-4fbe-a978-d683cd49511c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0d9beaa-474c-4080-97c2-6f6a90ce06a1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""B-Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""28928637-7cc1-401e-9135-450b353e4851"",
            ""actions"": [
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""9efb7013-acc2-4bc4-9c59-8cac219d2c4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""790dac63-fb41-4054-ad99-06a2210af504"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
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
                },
                {
                    ""devicePath"": ""<Mouse>"",
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
        // Pikachu
        m_Pikachu = asset.FindActionMap("Pikachu", throwIfNotFound: true);
        m_Pikachu_Jump2 = m_Pikachu.FindAction("Jump2", throwIfNotFound: true);
        m_Pikachu_Movement = m_Pikachu.FindAction("Movement", throwIfNotFound: true);
        m_Pikachu_View = m_Pikachu.FindAction("View", throwIfNotFound: true);
        // Mario
        m_Mario = asset.FindActionMap("Mario", throwIfNotFound: true);
        m_Mario_Jump = m_Mario.FindAction("Jump", throwIfNotFound: true);
        m_Mario_Movement = m_Mario.FindAction("Movement", throwIfNotFound: true);
        m_Mario_View = m_Mario.FindAction("View", throwIfNotFound: true);
        m_Mario_Fire = m_Mario.FindAction("Fire", throwIfNotFound: true);
        m_Mario_Aim = m_Mario.FindAction("Aim", throwIfNotFound: true);
        m_Mario_Reload = m_Mario.FindAction("Reload", throwIfNotFound: true);
        m_Mario_PauseMenu = m_Mario.FindAction("PauseMenu", throwIfNotFound: true);
        m_Mario_Submit = m_Mario.FindAction("Submit", throwIfNotFound: true);
        m_Mario_BButton = m_Mario.FindAction("B-Button", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
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

    // Pikachu
    private readonly InputActionMap m_Pikachu;
    private IPikachuActions m_PikachuActionsCallbackInterface;
    private readonly InputAction m_Pikachu_Jump2;
    private readonly InputAction m_Pikachu_Movement;
    private readonly InputAction m_Pikachu_View;
    public struct PikachuActions
    {
        private @PlayerInputActions m_Wrapper;
        public PikachuActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump2 => m_Wrapper.m_Pikachu_Jump2;
        public InputAction @Movement => m_Wrapper.m_Pikachu_Movement;
        public InputAction @View => m_Wrapper.m_Pikachu_View;
        public InputActionMap Get() { return m_Wrapper.m_Pikachu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PikachuActions set) { return set.Get(); }
        public void SetCallbacks(IPikachuActions instance)
        {
            if (m_Wrapper.m_PikachuActionsCallbackInterface != null)
            {
                @Jump2.started -= m_Wrapper.m_PikachuActionsCallbackInterface.OnJump2;
                @Jump2.performed -= m_Wrapper.m_PikachuActionsCallbackInterface.OnJump2;
                @Jump2.canceled -= m_Wrapper.m_PikachuActionsCallbackInterface.OnJump2;
                @Movement.started -= m_Wrapper.m_PikachuActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PikachuActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PikachuActionsCallbackInterface.OnMovement;
                @View.started -= m_Wrapper.m_PikachuActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_PikachuActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_PikachuActionsCallbackInterface.OnView;
            }
            m_Wrapper.m_PikachuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump2.started += instance.OnJump2;
                @Jump2.performed += instance.OnJump2;
                @Jump2.canceled += instance.OnJump2;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
            }
        }
    }
    public PikachuActions @Pikachu => new PikachuActions(this);

    // Mario
    private readonly InputActionMap m_Mario;
    private IMarioActions m_MarioActionsCallbackInterface;
    private readonly InputAction m_Mario_Jump;
    private readonly InputAction m_Mario_Movement;
    private readonly InputAction m_Mario_View;
    private readonly InputAction m_Mario_Fire;
    private readonly InputAction m_Mario_Aim;
    private readonly InputAction m_Mario_Reload;
    private readonly InputAction m_Mario_PauseMenu;
    private readonly InputAction m_Mario_Submit;
    private readonly InputAction m_Mario_BButton;
    public struct MarioActions
    {
        private @PlayerInputActions m_Wrapper;
        public MarioActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Mario_Jump;
        public InputAction @Movement => m_Wrapper.m_Mario_Movement;
        public InputAction @View => m_Wrapper.m_Mario_View;
        public InputAction @Fire => m_Wrapper.m_Mario_Fire;
        public InputAction @Aim => m_Wrapper.m_Mario_Aim;
        public InputAction @Reload => m_Wrapper.m_Mario_Reload;
        public InputAction @PauseMenu => m_Wrapper.m_Mario_PauseMenu;
        public InputAction @Submit => m_Wrapper.m_Mario_Submit;
        public InputAction @BButton => m_Wrapper.m_Mario_BButton;
        public InputActionMap Get() { return m_Wrapper.m_Mario; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MarioActions set) { return set.Get(); }
        public void SetCallbacks(IMarioActions instance)
        {
            if (m_Wrapper.m_MarioActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnMovement;
                @View.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnView;
                @Fire.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnFire;
                @Aim.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnAim;
                @Reload.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnReload;
                @PauseMenu.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnPauseMenu;
                @Submit.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnSubmit;
                @BButton.started -= m_Wrapper.m_MarioActionsCallbackInterface.OnBButton;
                @BButton.performed -= m_Wrapper.m_MarioActionsCallbackInterface.OnBButton;
                @BButton.canceled -= m_Wrapper.m_MarioActionsCallbackInterface.OnBButton;
            }
            m_Wrapper.m_MarioActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @BButton.started += instance.OnBButton;
                @BButton.performed += instance.OnBButton;
                @BButton.canceled += instance.OnBButton;
            }
        }
    }
    public MarioActions @Mario => new MarioActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Submit;
    public struct UIActions
    {
        private @PlayerInputActions m_Wrapper;
        public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
    public interface IPikachuActions
    {
        void OnJump2(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
    }
    public interface IMarioActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnBButton(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnSubmit(InputAction.CallbackContext context);
    }
}
