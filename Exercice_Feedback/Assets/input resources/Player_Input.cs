//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/input resources/Player_Input.inputactions
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

public partial class @Player_Input : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Input"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""bc0a856c-d2e8-4248-8f97-32c5cc7e7022"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""04b86347-f302-4d19-906f-fc0ddde06984"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot1"",
                    ""type"": ""Value"",
                    ""id"": ""6a3a3b5d-2b64-42a4-b09b-849c0d20a4a7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot2"",
                    ""type"": ""Button"",
                    ""id"": ""25b09515-6b4b-40c7-a770-22b9df1f46fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""4055f7ef-6f79-47b5-817f-43fac07fdb6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""d26496dc-9a33-4774-b7cd-257f624ef26b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Decelerate"",
                    ""type"": ""Button"",
                    ""id"": ""383b2d1c-bd18-424b-accb-f55444f5f835"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Death"",
                    ""type"": ""Button"",
                    ""id"": ""ea6df9a8-f80d-45d3-bb05-3cf321e13be4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""2ff43687-bff5-4d7c-a18d-19e27d66865f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Change Map"",
                    ""type"": ""Button"",
                    ""id"": ""d2b5796c-f6c7-46be-b874-4486a1fa6bf8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0274cfc4-bcc4-4495-b1e7-006f4b9d2423"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""be7061e6-4ec1-40c2-af1c-e00c09dfc9b0"",
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
                    ""id"": ""d6d93e07-c214-4ac6-a388-70568989cd2b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""866f1da8-518c-49ca-9e61-857685cc9f38"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38b3286b-bc96-4dbc-b801-0c79cdc0e00e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""14b46264-80e4-4d87-858c-fb615080146f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c44d3d6e-97ed-4ff6-aa95-c46624f07907"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89776e70-5318-4a94-82ba-c30f04b28fe5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2f7f46b-623a-4b55-8a05-a391311d9cdb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""clockwise Rotation"",
                    ""id"": ""b9b3a4e4-7ac6-4acb-a6ac-6956bb20622c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""54c60733-aa6c-45f6-9ec5-2ad92d031b70"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""06e06084-f49d-4843-bdee-4d87aa8ed5fe"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""clockwise Rotation"",
                    ""id"": ""0d49dab8-1922-4177-9fee-eb84c918b88c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""41e34ce0-912b-4a64-8247-d3bebb886b01"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a6af2054-a1a1-432f-a125-3651266f5b6f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""509b88e8-2e24-43c7-b986-dd746203d7bf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebff298d-34fb-4f43-8d99-7ed4393d1603"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37a0fbc6-963c-4c22-8bfc-666ec3fcb5c1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be0767bc-75e2-4979-9db0-dba18303e375"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44a56245-a26b-41e0-99b1-071c67ed9da3"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Death"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8006ffa9-05df-4445-9cd9-deca60a8b108"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Death"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""bf2e125c-066a-4f20-be04-42ca9335c3b2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5ae7ab3c-cb01-45d2-badf-872ee9f321ff"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3b3c65de-d2a7-4669-8ba3-c0c6447c2f9e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""427eeada-34e5-4a83-b245-2f3fa37bfdd9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""aa6c1a5c-5258-4920-ad9a-c4be08f88729"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b1774707-ac2f-4888-a8b5-99d380d039a6"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4f61ce5f-15ec-49a2-97f5-c4d9a2e0c0d8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f681182e-b8d5-4b21-8583-6ab0681976e7"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Change Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_Movement = m_Ship.FindAction("Movement", throwIfNotFound: true);
        m_Ship_Shoot1 = m_Ship.FindAction("Shoot1", throwIfNotFound: true);
        m_Ship_Shoot2 = m_Ship.FindAction("Shoot2", throwIfNotFound: true);
        m_Ship_Rotate = m_Ship.FindAction("Rotate", throwIfNotFound: true);
        m_Ship_Accelerate = m_Ship.FindAction("Accelerate", throwIfNotFound: true);
        m_Ship_Decelerate = m_Ship.FindAction("Decelerate", throwIfNotFound: true);
        m_Ship_Death = m_Ship.FindAction("Death", throwIfNotFound: true);
        m_Ship_ChangeWeapon = m_Ship.FindAction("ChangeWeapon", throwIfNotFound: true);
        m_Ship_ChangeMap = m_Ship.FindAction("Change Map", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_Movement;
    private readonly InputAction m_Ship_Shoot1;
    private readonly InputAction m_Ship_Shoot2;
    private readonly InputAction m_Ship_Rotate;
    private readonly InputAction m_Ship_Accelerate;
    private readonly InputAction m_Ship_Decelerate;
    private readonly InputAction m_Ship_Death;
    private readonly InputAction m_Ship_ChangeWeapon;
    private readonly InputAction m_Ship_ChangeMap;
    public struct ShipActions
    {
        private @Player_Input m_Wrapper;
        public ShipActions(@Player_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Ship_Movement;
        public InputAction @Shoot1 => m_Wrapper.m_Ship_Shoot1;
        public InputAction @Shoot2 => m_Wrapper.m_Ship_Shoot2;
        public InputAction @Rotate => m_Wrapper.m_Ship_Rotate;
        public InputAction @Accelerate => m_Wrapper.m_Ship_Accelerate;
        public InputAction @Decelerate => m_Wrapper.m_Ship_Decelerate;
        public InputAction @Death => m_Wrapper.m_Ship_Death;
        public InputAction @ChangeWeapon => m_Wrapper.m_Ship_ChangeWeapon;
        public InputAction @ChangeMap => m_Wrapper.m_Ship_ChangeMap;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnMovement;
                @Shoot1.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnShoot1;
                @Shoot1.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnShoot1;
                @Shoot1.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnShoot1;
                @Shoot2.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnShoot2;
                @Shoot2.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnShoot2;
                @Shoot2.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnShoot2;
                @Rotate.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                @Accelerate.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnAccelerate;
                @Decelerate.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnDecelerate;
                @Decelerate.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnDecelerate;
                @Decelerate.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnDecelerate;
                @Death.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnDeath;
                @Death.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnDeath;
                @Death.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnDeath;
                @ChangeWeapon.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnChangeWeapon;
                @ChangeMap.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnChangeMap;
                @ChangeMap.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnChangeMap;
                @ChangeMap.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnChangeMap;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot1.started += instance.OnShoot1;
                @Shoot1.performed += instance.OnShoot1;
                @Shoot1.canceled += instance.OnShoot1;
                @Shoot2.started += instance.OnShoot2;
                @Shoot2.performed += instance.OnShoot2;
                @Shoot2.canceled += instance.OnShoot2;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Decelerate.started += instance.OnDecelerate;
                @Decelerate.performed += instance.OnDecelerate;
                @Decelerate.canceled += instance.OnDecelerate;
                @Death.started += instance.OnDeath;
                @Death.performed += instance.OnDeath;
                @Death.canceled += instance.OnDeath;
                @ChangeWeapon.started += instance.OnChangeWeapon;
                @ChangeWeapon.performed += instance.OnChangeWeapon;
                @ChangeWeapon.canceled += instance.OnChangeWeapon;
                @ChangeMap.started += instance.OnChangeMap;
                @ChangeMap.performed += instance.OnChangeMap;
                @ChangeMap.canceled += instance.OnChangeMap;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IShipActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot1(InputAction.CallbackContext context);
        void OnShoot2(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnDecelerate(InputAction.CallbackContext context);
        void OnDeath(InputAction.CallbackContext context);
        void OnChangeWeapon(InputAction.CallbackContext context);
        void OnChangeMap(InputAction.CallbackContext context);
    }
}