// GENERATED AUTOMATICALLY FROM 'Assets/Input Action/InputAsset.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAsset"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9748f3d1-f602-4912-bf09-996d1622cc33"",
            ""actions"": [
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9d7aed95-d51e-4cfe-a21d-87758518d857"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""88379a88-b0ae-43b4-bde6-383ef836ab9a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""ce1e166b-4089-42f9-9e69-81be6cd5ffc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""44ca752f-2f2a-4eb2-bc8e-470cd63abee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack2"",
                    ""type"": ""Button"",
                    ""id"": ""785f4db4-28e6-4630-839b-98a42742b9bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""74ffaf08-b141-46b7-94db-6956797dbfba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""950ddfcb-fd8e-4915-97dd-d84b7cb50fe9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""d8b90553-91b5-439d-9ac4-3c6b5cacff3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QuickAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f4ea957e-3087-4d13-8b0e-98a952d439ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementAbility"",
                    ""type"": ""Button"",
                    ""id"": ""f06166e6-2675-48e4-a968-61a83f451d14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OffenceAbility"",
                    ""type"": ""Button"",
                    ""id"": ""9b96689a-cf07-4463-99d5-2e3fe24a7c4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DefenceAbility"",
                    ""type"": ""Button"",
                    ""id"": ""783369c9-b8a6-4d1d-8680-60d45877e4d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HealingAbility"",
                    ""type"": ""Button"",
                    ""id"": ""43e18883-27d7-4174-b55c-b96e10b7398e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UltimateAbility"",
                    ""type"": ""Button"",
                    ""id"": ""d4da9d37-71e2-4760-93bf-a3c048eafd74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5111ef1-1bf3-4aaf-ba2b-83f0e0f653c1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8806ecca-31b7-468d-81ba-cd9ba92c78f7"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d59aa4d-3711-49ca-8869-ceb2da362aaa"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21901364-c60f-44fd-abd7-6211c4625fb2"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""QuickAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c660fe58-d614-4b0d-bc39-d3167e35a644"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9873fbf-94f9-46db-a6f6-7c3765f85ede"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""064af605-a6f2-4cc7-9ca6-6ac691e925cb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a2e25081-7ab4-4da0-a2a2-2dc30ff8dfa4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eb35a665-c0c7-4a1e-b8b1-0bf606bcb012"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""454fb817-a6fb-43f8-a3ff-719b9f0408b7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""77e4e218-e657-475e-b735-ceb6f12e9e37"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7c1891bf-8f0c-42fa-9ee7-95188f9ed7a6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8d51b03-9123-4991-b707-155d7c05de64"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Attack2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""998297a0-7913-47ed-8f61-6d409ee3ad5a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""OffenceAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""405e32ed-464f-4f0b-b82e-823bace2cfa6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""DefenceAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e229687-9fb4-481b-80d0-236f0183986f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""HealingAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ec49e08-0da8-44bd-b2c6-c99915e91999"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""UltimateAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2232c56-5332-4145-be44-1ff7b078e07f"",
                    ""path"": ""<Keyboard>/capsLock"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""MovementAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus"",
            ""id"": ""6033176d-1759-4652-a212-3e04c8de2008"",
            ""actions"": [
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""77b913d1-0177-4ef8-8a69-e7748cc46d2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8fbaec6-10d5-4c1c-b142-40e244f63eb5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
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
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MouseX = m_Player.FindAction("MouseX", throwIfNotFound: true);
        m_Player_MouseY = m_Player.FindAction("MouseY", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Attack1 = m_Player.FindAction("Attack1", throwIfNotFound: true);
        m_Player_Attack2 = m_Player.FindAction("Attack2", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_QuickAttack = m_Player.FindAction("QuickAttack", throwIfNotFound: true);
        m_Player_MovementAbility = m_Player.FindAction("MovementAbility", throwIfNotFound: true);
        m_Player_OffenceAbility = m_Player.FindAction("OffenceAbility", throwIfNotFound: true);
        m_Player_DefenceAbility = m_Player.FindAction("DefenceAbility", throwIfNotFound: true);
        m_Player_HealingAbility = m_Player.FindAction("HealingAbility", throwIfNotFound: true);
        m_Player_UltimateAbility = m_Player.FindAction("UltimateAbility", throwIfNotFound: true);
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_PauseMenu = m_Menus.FindAction("PauseMenu", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MouseX;
    private readonly InputAction m_Player_MouseY;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Attack1;
    private readonly InputAction m_Player_Attack2;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_QuickAttack;
    private readonly InputAction m_Player_MovementAbility;
    private readonly InputAction m_Player_OffenceAbility;
    private readonly InputAction m_Player_DefenceAbility;
    private readonly InputAction m_Player_HealingAbility;
    private readonly InputAction m_Player_UltimateAbility;
    public struct PlayerActions
    {
        private @InputAsset m_Wrapper;
        public PlayerActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseX => m_Wrapper.m_Player_MouseX;
        public InputAction @MouseY => m_Wrapper.m_Player_MouseY;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Attack1 => m_Wrapper.m_Player_Attack1;
        public InputAction @Attack2 => m_Wrapper.m_Player_Attack2;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @QuickAttack => m_Wrapper.m_Player_QuickAttack;
        public InputAction @MovementAbility => m_Wrapper.m_Player_MovementAbility;
        public InputAction @OffenceAbility => m_Wrapper.m_Player_OffenceAbility;
        public InputAction @DefenceAbility => m_Wrapper.m_Player_DefenceAbility;
        public InputAction @HealingAbility => m_Wrapper.m_Player_HealingAbility;
        public InputAction @UltimateAbility => m_Wrapper.m_Player_UltimateAbility;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MouseX.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseY;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Attack1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack1;
                @Attack2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack2;
                @Attack2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack2;
                @Attack2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack2;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @QuickAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuickAttack;
                @QuickAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuickAttack;
                @QuickAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuickAttack;
                @MovementAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementAbility;
                @MovementAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementAbility;
                @MovementAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementAbility;
                @OffenceAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOffenceAbility;
                @OffenceAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOffenceAbility;
                @OffenceAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOffenceAbility;
                @DefenceAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefenceAbility;
                @DefenceAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefenceAbility;
                @DefenceAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDefenceAbility;
                @HealingAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHealingAbility;
                @HealingAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHealingAbility;
                @HealingAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHealingAbility;
                @UltimateAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUltimateAbility;
                @UltimateAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUltimateAbility;
                @UltimateAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUltimateAbility;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Attack2.started += instance.OnAttack2;
                @Attack2.performed += instance.OnAttack2;
                @Attack2.canceled += instance.OnAttack2;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @QuickAttack.started += instance.OnQuickAttack;
                @QuickAttack.performed += instance.OnQuickAttack;
                @QuickAttack.canceled += instance.OnQuickAttack;
                @MovementAbility.started += instance.OnMovementAbility;
                @MovementAbility.performed += instance.OnMovementAbility;
                @MovementAbility.canceled += instance.OnMovementAbility;
                @OffenceAbility.started += instance.OnOffenceAbility;
                @OffenceAbility.performed += instance.OnOffenceAbility;
                @OffenceAbility.canceled += instance.OnOffenceAbility;
                @DefenceAbility.started += instance.OnDefenceAbility;
                @DefenceAbility.performed += instance.OnDefenceAbility;
                @DefenceAbility.canceled += instance.OnDefenceAbility;
                @HealingAbility.started += instance.OnHealingAbility;
                @HealingAbility.performed += instance.OnHealingAbility;
                @HealingAbility.canceled += instance.OnHealingAbility;
                @UltimateAbility.started += instance.OnUltimateAbility;
                @UltimateAbility.performed += instance.OnUltimateAbility;
                @UltimateAbility.canceled += instance.OnUltimateAbility;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menus
    private readonly InputActionMap m_Menus;
    private IMenusActions m_MenusActionsCallbackInterface;
    private readonly InputAction m_Menus_PauseMenu;
    public struct MenusActions
    {
        private @InputAsset m_Wrapper;
        public MenusActions(@InputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseMenu => m_Wrapper.m_Menus_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void SetCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterface != null)
            {
                @PauseMenu.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_MenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
            }
        }
    }
    public MenusActions @Menus => new MenusActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack1(InputAction.CallbackContext context);
        void OnAttack2(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnQuickAttack(InputAction.CallbackContext context);
        void OnMovementAbility(InputAction.CallbackContext context);
        void OnOffenceAbility(InputAction.CallbackContext context);
        void OnDefenceAbility(InputAction.CallbackContext context);
        void OnHealingAbility(InputAction.CallbackContext context);
        void OnUltimateAbility(InputAction.CallbackContext context);
    }
    public interface IMenusActions
    {
        void OnPauseMenu(InputAction.CallbackContext context);
    }
}
