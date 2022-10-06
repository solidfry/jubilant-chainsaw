using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using DG.Tweening;
using ScriptableObjects;

public class CustomerHandler : MonoBehaviour
{
    [SerializeField] private SpriteList spriteList;
    [Header("Animation Settings")]
    [SerializeField] private float animationTime = 0.5f;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        GameEvents.OnCelebrationEvent += GetNewCustomer;
    }


    private void OnDisable()
    {
        GameEvents.OnCelebrationEvent -= GetNewCustomer;
    }

    private void GetNewCustomer() => StartCoroutine(HandleNewCustomer());


    IEnumerator HandleNewCustomer()
    {
        yield return new WaitForSeconds(.5f);
        AnimateOut();
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = spriteList.GetRandomSprite();
        yield return new WaitForSeconds(1);
        AnimateIn();
    }

    void AnimateIn()
    {
        transform.DOLocalMoveY(3.5f, animationTime);
        transform.DOScale(1, animationTime);
        spriteRenderer.DOFade(1, animationTime);
    }

    void AnimateOut()
    {
        transform.DOLocalMoveY(-5, animationTime);
        transform.DOScale(.25f, animationTime);
        spriteRenderer.DOFade(0, animationTime);
    }


}

