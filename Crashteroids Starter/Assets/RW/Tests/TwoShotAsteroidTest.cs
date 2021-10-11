using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TwoShotAsteroidTest
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
    public IEnumerator TwoShotAsteroidSpawns()
    {
        GameObject asteroid = game.GetSpawner().SpawnMaxAsteroid();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(2, asteroid.GetComponent<Asteroid>().GetHealth());
    }

    [UnityTest]
    public IEnumerator TwoShotAsteroidDestroyed()
    {
        GameObject asteroid = game.GetSpawner().SpawnMaxAsteroid();
        asteroid.transform.position = Vector3.zero;

        GameObject laser1 = game.GetShip().SpawnLaser();
        laser1.transform.position = Vector3.zero;

        GameObject laser2 = game.GetShip().SpawnLaser();
        laser2.transform.position = Vector3.zero;

        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }



}