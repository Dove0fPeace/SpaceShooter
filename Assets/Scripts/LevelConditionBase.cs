using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class LevelConditionBase : MonoBehaviour
{
    protected TextMeshProUGUI m_Goal;

    public virtual TextMeshProUGUI ConditionText()
    {
        return m_Goal;
    }

}
