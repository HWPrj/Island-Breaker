using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISwitcher
{
    public event UnityAction Activate;
    public event UnityAction Deactivate;
}
