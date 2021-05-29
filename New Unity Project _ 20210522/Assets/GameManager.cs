using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UI���� ���̺귯��
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯�� 

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ��� �� Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText;//���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; //�ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    public GameObject level; //�ҷ� �� ���� ������ ����
    public GameObject bulletSpawnerPrefab;
    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;

    private float surviveTime; //�����ð�
    private bool isGmaeover; //���ӿ��� ����

        // Start is called before the first frame update
    void Start()
    {
        //���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0;
        isGmaeover = false;

        surviveTime = 0;
        isGmaeover = false;

        bulletSpawners[0].x = -8f;
        bulletSpawners[0].y = 1f;
        bulletSpawners[0].z = 8;

        bulletSpawners[1].x = 8f;
        bulletSpawners[1].y = 1f;
        bulletSpawners[1].z = 8;

        bulletSpawners[2].x = 8f;
        bulletSpawners[2].y = 1f;
        bulletSpawners[2].z = -8;

        bulletSpawners[3].x = -8f;
        bulletSpawners[3].y = 1f;
        bulletSpawners[3].z = -8;
    }

    // Update is called once per frame
    void Update()
    {
        //���ӿ����� �ƴ� ����
        if (!isGmaeover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time: " + (int)surviveTime;

            if (surviveTime < 5f && spawnCounter == 0)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 5f && surviveTime < 10f && spawnCounter == 1)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >=10f && surviveTime <15f && spawnCounter == 2)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnCounter++;
            }   
            else if (surviveTime>= 15f && surviveTime <20f && spawnCounter ==3)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnCounter];
                level.GetComponent<Rotator>().rotationSpeed += 15f; 
                spawnCounter++;
            }
                
        }

        else
        {
            //���ӿ��� ���¿��� RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    //���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        //���� ���¸� ���ӿ��� ���·� ��ȯ
        isGmaeover = true;
        //���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BesttimeŰ�� ����� ���������� �ְ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            //�ְ��� ���� ���� �����ð� ������ ����
            bestTime = surviveTime;
            //����� �ְ� ����� bestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //�ְ����� recordText �ؽ�Ʈ������Ʈ�� �̿��� ǥ��
        recordText.text = "BestTime" + (int)bestTime;
    }
}
