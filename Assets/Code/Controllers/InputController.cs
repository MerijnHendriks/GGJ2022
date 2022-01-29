using System;
using System.Collections.Generic;
using UnityEngine;

public static class InputController
{
    private static Dictionary<string, KeyCode[]> keymap;

    static InputController()
    {
        keymap = new Dictionary<string, KeyCode[]>()
        {
            // bind name             list of keys 
            { "JUMP",  new KeyCode[] { KeyCode.W, KeyCode.UpArrow,   KeyCode.Space } },
            { "LEFT",  new KeyCode[] { KeyCode.A, KeyCode.LeftArrow                } },
            { "RIGHT", new KeyCode[] { KeyCode.D, KeyCode.RightArrow               } },
            // for Testing
            { "TEST", new KeyCode[] { KeyCode.R } }
        };
    }

    public static bool IsAnyPressed()
    {
        return Input.anyKey;
    }

    public static bool IsPressed(string name)
    {
        if (!keymap.ContainsKey(name))
        {
            throw new Exception($"Keymap {name} does not exist");
        }

        if (keymap[name].Length == 0)
        {
            throw new Exception($"No keys are mapped to keymap {name}");
        }

        foreach (KeyCode key in keymap[name])
        {
            if (Input.GetKey(key))
            {
                return true;
            }
        }

        return false;
    }
}