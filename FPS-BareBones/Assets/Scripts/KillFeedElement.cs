using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KillFeedElement : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject icon;
    public TMP_Text Text { get => text; set => text = value; }
    public GameObject Icon { get => icon; set => icon = value; }
}
