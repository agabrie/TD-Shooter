using System;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes{
    Basic, /* can move in all 8 directions*/
    Vert, /* only moves up and down */
    Hori, /* only moves horizontally */
    Cardinal, /* can move in all 4 cardinal directions */
    CrossCutter, /* can move diagonally */
    Seeker /* follows player */
}
