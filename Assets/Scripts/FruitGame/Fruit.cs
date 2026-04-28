using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int fruitType;                  //과일 (0 : 사과, 1 : 블루 레비, 2 : 코코벗) int로 index 설정
    public bool hasMerged = false;         //과일이 합쳐졌는지 확인하는 플래그

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged)
            return;
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (otherFruit != null && !otherFruit.hasMerged && otherFruit.fruitType == fruitType)
        {
            hasMerged = true;
            otherFruit.hasMerged = true;

            Vector3 mergePosition = (transform.position + otherFruit.transform.position) / 2f;

            //게임 매니저에서 Merge 구현된 것을 호출
            FruitGame gameManager = FindAnyObjectByType<FruitGame>();
            if (gameManager != null)
            {
                gameManager.MergeFruits(fruitType, mergePosition);
            }

            //과일들 제거
            Destroy(otherFruit.gameObject);
            Destroy(gameObject);
        }
    }

}
