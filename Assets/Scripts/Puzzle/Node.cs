using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********************************************************************************
 * 보이지는 않지만 실제 Piece 뒤에 깔려 있는 타일같은 존재
 * 노드는 움직이지 않고 제자리에 항상 존재
 **********************************************************************************/

public class Node
{
    public Index Index;
    public Vector2 position;
    public Piece piece;

    //--------------------------------------------------------------------------------
    public Node(int indexX, int indexY, Vector2 position, Piece piece = null)
    {
        this.Index = new Index(indexX,indexY);
        this.position = position;
        this.piece = piece;
    }

    //새로운 피스 생성
    public void setPieceType(PieceType type)
    {
        piece.pieceType = type;
    }
}
