using System.Collections;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _target;

    [SerializeField] float _bulletSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Vous pouvez changer cette condition en fonction de votre logique
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        StartCoroutine(MoveBullet(bullet));
    }

    IEnumerator MoveBullet(GameObject bullet)
    {
        while (bullet != null && _target != null)
        {
            Vector3 direction = (_target.transform.position - bullet.transform.position).normalized;
            bullet.transform.Translate(direction * _bulletSpeed * Time.deltaTime);

            yield return null;
        }

        // Détruire la bullet lorsque la cible est atteinte ou lorsque la bullet n'est plus valide
        Destroy(bullet);
    }
}
