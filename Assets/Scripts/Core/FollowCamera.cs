﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwordShield.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}

