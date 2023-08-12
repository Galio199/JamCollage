using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private Vector2 clickPosition;
    [SerializeField] private float speed;
    private Coroutine moveCoroutine;
    private bool isAction = false;
    private void Start()
    {
        GameObject.FindGameObjectWithTag("boton").GetComponent<Button>().switchEnabled();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAction)
        {
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                gameObject.GetComponent<Animator>().SetBool("IsWalk", false);
            }
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapPoint(clickPosition) && !GetComponent<Collider2D>().OverlapPoint(clickPosition))
            {
                moveCoroutine = StartCoroutine(MoveCoroutine(clickPosition));
            }
        }
    }

    private IEnumerator MoveCoroutine(Vector2 pointMove)
    {
        GameObject gameObjectClicked = Physics2D.OverlapPoint(pointMove).gameObject;

        if (transform.position.x < pointMove.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            pointMove = gameObjectClicked.transform.position + new Vector3(-1f, 0f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
             pointMove = gameObjectClicked.transform.position + new Vector3(1f, 0f);
        }
        pointMove.y = transform.position.y;

        gameObject.GetComponent<Animator>().SetBool("IsWalk", true);
        while (Vector2.Distance(transform.position, pointMove) >0)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointMove, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = pointMove;
        gameObject.GetComponent<Animator>().SetBool("IsWalk", false);
        moveCoroutine = null;
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(ActionCoruoutine(gameObjectClicked));
    }

    private IEnumerator ActionCoruoutine(GameObject gameObjectCliked)
    {
        InteractionManager interactionManager = gameObjectCliked.GetComponent<InteractionManager>();

        switch (interactionManager.Type())
        {
            case TypeIteraction.ALIEN:

                isAction = true;

                InteractionAlien interactionAlien = (InteractionAlien)interactionManager;
                gameObject.GetComponent<Animator>().SetBool("IsAttack", true);

                yield return new WaitForSeconds(1.333f);

                interactionAlien.damage.SetActive(true);

                yield return new WaitForSeconds(0.666f);

                gameObject.GetComponent<Animator>().SetBool("IsAttack", false);
                interactionAlien.damage.SetActive(false);
                interactionManager.Interaction();

                isAction = false;

                break;

            case TypeIteraction.PORTAL:

                interactionManager.Interaction();
                break;


            case TypeIteraction.CRAFT:

                isAction = true;
                interactionManager.Interaction();
                break;
        }
        yield return null;
    }
}
