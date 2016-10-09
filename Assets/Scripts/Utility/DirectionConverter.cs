using UnityEngine;
using System.Collections;

public static class DirectionConverter
{
    public static Character.FacingDir DirectionPlayerToMouse(Vector3 masterPos, Vector3 mousePos)
    {

        Quaternion rotateDirectionObject;
        float rotationDirectionEuler;

        Vector3 position = Camera.main.WorldToScreenPoint(masterPos);
        Vector3 direction = mousePos - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotateDirectionObject = Quaternion.AngleAxis(angle, Vector3.forward);
        rotationDirectionEuler = rotateDirectionObject.eulerAngles.z;

        Character.FacingDir dir;

        if (rotationDirectionEuler <= 133 && rotationDirectionEuler >= 40)
            dir = Character.FacingDir.Up;
        else if (rotationDirectionEuler >= 310 || rotationDirectionEuler <= 40)
            dir = Character.FacingDir.Left;
        else if (rotationDirectionEuler <= 222 && rotationDirectionEuler >= 133)
            dir = Character.FacingDir.Right;
        else
            dir = Character.FacingDir.Down;

        return dir;
    }

    public static Character.FacingDir DirectionPlayerToPlayer(Vector3 masterPos, Vector3 targetPos)
    {

        Quaternion rotateDirectionObject;
        float rotationDirectionEuler;

        Vector3 position = masterPos;
        Vector3 direction = targetPos - position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotateDirectionObject = Quaternion.AngleAxis(angle, Vector3.forward);
        rotationDirectionEuler = rotateDirectionObject.eulerAngles.z;

        Character.FacingDir dir;

        if (rotationDirectionEuler <= 133 && rotationDirectionEuler >= 40)
            dir = Character.FacingDir.Up;
        else if (rotationDirectionEuler >= 310 || rotationDirectionEuler <= 40)
            dir = Character.FacingDir.Left;
        else if (rotationDirectionEuler <= 222 && rotationDirectionEuler >= 133)
            dir = Character.FacingDir.Right;
        else
            dir = Character.FacingDir.Down;

        return dir;
    }

}
