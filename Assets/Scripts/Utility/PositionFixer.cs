using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PositionFixer : MonoBehaviour {
    int totalIndex = 1;

    void Start ()
    {
        FindAndCorrectFloorPositions(MasterPositionFixer.ObjectType.Floor);
        FindAndCorrectFloorPositions(MasterPositionFixer.ObjectType.Wall);
    }

    public void FindAndCorrectFloorPositions(MasterPositionFixer.ObjectType objectsToFind)
    {
        string keyWord = "null";

        if (objectsToFind == MasterPositionFixer.ObjectType.Floor)
            keyWord = "Floor";
        else if (objectsToFind == MasterPositionFixer.ObjectType.Wall)
            keyWord = "Wall";

        if (keyWord == "null")
        {
            Debug.Log("keyWord is NULL");
            return;
        }

        Transform findChildsFrom = transform;
        foreach (Transform child in findChildsFrom)
        {
            if (child.gameObject.name.Contains(keyWord))
            {
                CorrectObjectsPosition(child);
            }
            else if (child.gameObject.name.Contains("Room"))
            {
                foreach (Transform roomChild in child)
                {
                    if (roomChild.gameObject.name.Contains(keyWord))
                    {
                        CorrectObjectsPosition(roomChild);
                    }
                }
            }
        }
    }

    void CorrectObjectsPosition(Transform parent)
    {

        Queue<Transform> objectsToCheck = new Queue<Transform>();
        int count = parent.childCount;
        bool done = false;

        int emergencyExit = 0;

        while (!done)
        {
            foreach (Transform child in parent)
            {
                if (child.childCount != 0)
                {
                    for (int i = 0; i < child.childCount; i++)
                    {
                        if (child.GetChild(i).childCount != 0)
                        {
                            objectsToCheck.Enqueue(child.GetChild(i));
                        }
                        else
                        {
                            UpdatePos(child.GetChild(i));
                        }
                    }
                }
                else
                {
                    UpdatePos(child);
                }

                if (child == parent.GetChild(count - 1))
                {
                    if (objectsToCheck.Count == 0)
                    {
                        done = true;
                        break;
                    }
                    else
                    {
                        parent = objectsToCheck.Dequeue();
                        count = parent.childCount;
                        break;
                    }
                }
            }

            emergencyExit++;
            if (emergencyExit >= 1000)
            {
                Debug.Log("EMERGENCY EXIT");
                done = true;
            }
        }

    }

    void UpdatePos(Transform target)
    {
        target.position += new Vector3(0, 0, 0.0001f * totalIndex);
        totalIndex++;
    }

    void OldChecker(Transform parent)
    {
        Transform targetTransform;
        Queue<GameObject> objectsToCheck = new Queue<GameObject>();
        int count = parent.childCount;
        bool done = false;

        while (!done)
        {
            foreach (Transform t in parent)
            {
                targetTransform = t;

                while (true)
                {
                    if (targetTransform.childCount != 0)
                    {
                        targetTransform = targetTransform.GetChild(0);
                        //objectsToCheck.Enqueue(targetTransform.gameObject);
                    }
                    else
                    {
                        targetTransform = targetTransform.parent;
                        break;
                    }
                }

                foreach (Transform child in targetTransform)
                {
                    if (child.childCount == 0)
                    {
                        child.transform.position += new Vector3(0, 0, 0.0001f * totalIndex);
                        totalIndex++;
                    }
                    else
                    {
                        objectsToCheck.Enqueue(child.gameObject);
                    }
                }
                if (t == parent.GetChild(count - 1) && objectsToCheck.Count == 0)
                {
                    done = true;
                }
                else if (t == parent.GetChild(count - 1) && objectsToCheck.Count != 0)
                {
                    parent = objectsToCheck.Dequeue().transform;
                }
            }
        }
    }
}
