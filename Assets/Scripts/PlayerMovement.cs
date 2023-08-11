using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 clickPosition;
    [SerializeField] private float speed;
    private Coroutine moveCoroutine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                gameObject.GetComponent<Animator>().SetBool("IsWalk", false);
            }
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapPoint(clickPosition) && !GetComponent<Collider2D>().OverlapPoint(clickPosition))
            {
                clickPosition.y = transform.position.y;
                moveCoroutine = StartCoroutine(MoveCoroutine(clickPosition));
            }
        }
    }

    private IEnumerator MoveCoroutine(Vector2 pointMove)
    {
        if (transform.position.x < pointMove.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        Collider2D clickedCollider = Physics2D.OverlapPoint(pointMove);

        gameObject.GetComponent<Animator>().SetBool("IsWalk", true);
        while (Vector2.Distance(transform.position, pointMove) >0)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointMove, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = pointMove;
        gameObject.GetComponent<Animator>().SetBool("IsWalk", false);
        moveCoroutine = null;

    }
}
