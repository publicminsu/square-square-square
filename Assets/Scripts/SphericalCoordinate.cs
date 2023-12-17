using UnityEngine;

public class SphericalCoordinate
{
    private const float minElevationRad = Mathf.Deg2Rad * 0.01f;
    private const float maxElevationRad = Mathf.Deg2Rad * 179.99f;
    private const float rotationSpeed = Mathf.Deg2Rad * 60;

    public float Radius { get; set; }//����
    public float AzimuthRad { get; set; }//������
    public float ElevationRad { get; set; }//�Ӱ�

    public SphericalCoordinate(float radius, float azimuthDeg, float elevationDeg)
    {
        Radius = radius;
        AzimuthRad = Mathf.Deg2Rad * azimuthDeg;
        ElevationRad = Mathf.Deg2Rad * elevationDeg;
    }

    public Vector3 ToCartesianCoordinate()
    {
        //������, �簢, ����(������ǥ��)�� ���� 3���� ��ī��Ʈ ��ǥ�� ��ȯ
        return new(
            Radius * Mathf.Sin(ElevationRad) * Mathf.Cos(AzimuthRad),
            Radius * Mathf.Cos(ElevationRad),
            Radius * Mathf.Sin(ElevationRad) * Mathf.Sin(AzimuthRad));
    }

    public void AddDirectionDeg(Vector2 directionDeg)
    {
        directionDeg *= rotationSpeed;
        AzimuthRad += directionDeg.x;
        ElevationRad += directionDeg.y;

        //���� �� �� �Ǵ� �� �Ʒ��� �Ѿ�� �� ����
        ElevationRad = Mathf.Clamp(ElevationRad, minElevationRad, maxElevationRad);
    }
}
