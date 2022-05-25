﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level;

    public void Display(KeyValuePair<SkillType, SkillData> skill)
    {
        level.text = skill.Value.level.ToString();
    }
}