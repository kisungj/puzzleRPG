﻿using UnityEngine;


/**********************************************************************************
 * Piece들을 2차 배열로 관리 하므로 Index 처리를 편하게 하기 위한 유틸
 **********************************************************************************/

public struct Index
{
    public int x;
    public int y;

    //--------------------------------------------------------------------------------
    public Index(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    //--------------------------------------------------------------------------------
    public Index(Vector2 vector2)
    {
        this.x = (int)vector2.x;
        this.y = (int)vector2.y;
    }

    //--------------------------------------------------------------------------------
    public static Index Add(Index a, Index b)
    {
        return new Index(a.x + b.x, a.y + b.y);
    }

    //--------------------------------------------------------------------------------
    public static Index Mul(Index a, int scalar)
    {
        return new Index(a.x * scalar, a.y * scalar);
    }

    //--------------------------------------------------------------------------------
    public static Index right { get { return new Index(1, 0); } }
    public static Index left { get { return new Index(-1, 0); } }
    public static Index top { get { return new Index(0, -1); } }
    public static Index bottom { get { return new Index(0, 1); } }
}