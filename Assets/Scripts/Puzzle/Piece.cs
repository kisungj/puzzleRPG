﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum PieceType
{
    Blue = 0,
    Green = 1,
    Purple = 2,
    Red = 3,
    Yellow = 4,
    Null = 5
}

/**********************************************************************************
 * 실제 화면에 보이는 퍼즐 조각
 **********************************************************************************/

public class Piece : MonoBehaviour ,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]PieceType mPieceType;
    Image mImage;
    RectTransform mTransform;
    Index mIndex;

    public RectTransform rectTransform { get { return mTransform; } }
    public PieceType pieceType { get { return mPieceType; } set { mPieceType = value; } }
    public Index index { get { return mIndex; } set { mIndex = value; } }
    public Image pieceImg { get { return mImage; } set { mImage = value; } }

    //--------------------------------------------------------------------------------
    public void Init(Index index ,PieceType pieceType, Sprite sprite)
    {
        mImage = GetComponent<Image>();
        mTransform = GetComponent<RectTransform>();

        mPieceType = pieceType;
        mImage.sprite = sprite;
        mIndex = index;
    }

    //--------------------------------------------------------------------------------
    public void OnPointerDown(PointerEventData eventData)
    {
       PanelBoard.Instance.OnPointerDown(eventData, this);
    }

    //--------------------------------------------------------------------------------
    public void OnDrag(PointerEventData eventData)
    {
        PanelBoard.Instance.OnDrag(eventData, this);
    }

    //--------------------------------------------------------------------------------
    public void OnPointerUp(PointerEventData eventData)
    {
        PanelBoard.Instance.OnPointerUp(eventData, this);
    }

    //--------------------------------------------------------------------------------
    public void DestroyPiece()
    {
        //Destroy(gameObject);
        StartCoroutine(DesolvePiece());
    }

    //--------------------------------------------------------------------------------
    IEnumerator DesolvePiece()
    {
        while (mTransform.localScale.x > 0.2f)
        {
            float value = 2f * Time.deltaTime;
            mTransform.localScale = mTransform.localScale - new Vector3(value, value, value);
        }
        yield return null;


        Destroy(gameObject);
    }
}
