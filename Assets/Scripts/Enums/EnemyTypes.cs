using System;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes{
    Hori, /* only moves horizontally */
    Vert, /* only moves up and down */
    Cardinal, /* can move in all 4 cardinal directions */
    CrossCutter, /* can move diagonally */
    Basic, /* can move in all 8 directions*/
    Seeker /* follows player */
}
