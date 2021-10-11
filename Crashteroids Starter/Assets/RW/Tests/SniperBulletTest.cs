using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SniperBulletTest
{

    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
          MonoBehaviour.Instantiate(
            Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator OneShotMaxAsteroid()
    {
        GameObject asteroid = game.GetSpawner().SpawnMaxAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject sniperBullet = game.GetShip().SpawnLaser();
        sniperBullet.GetComponent<Laser>().ForceSniper();
        sniperBullet.transform.position = Vector3.zero;

        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator OneShotAsteroid()
    {
        GameObject asteroid = game.GetSpawner().SpawnMaxAsteroid();
        asteroid.transform.position = Vector3.zero;
        asteroid.GetComponent<Asteroid>().Damage();
        GameObject sniperBullet = game.GetShip().SpawnLaser();
        sniperBullet.GetComponent<Laser>().ForceSniper();
        sniperBullet.transform.position = Vector3.zero;

        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator SniperBulletSpawned()
    {
        GameObject sniperBullet = game.GetShip().SpawnLaser();

        sniperBullet.GetComponent<Laser>().ForceSniper();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(true, sniperBullet.GetComponent<Laser>().GetSniper());
    }



}