using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LaserTest
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
    public IEnumerator ShrapnelDestoryAsteroid()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        ShrapnelSpawner shrapnel = game.GetShrapnelSpawner();
        shrapnel.SpawnShrapnel(Vector3.zero);
        yield return new WaitForSeconds(0.2f);
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator SpawnWithRandomDirections()
    {
        ShrapnelSpawner spawner = game.GetShrapnelSpawner();
        GameObject s1 = spawner.SpawnShrapnel(Vector3.zero);
        GameObject s2 = spawner.SpawnShrapnel(Vector3.zero);

        yield return new WaitForSeconds(0f);

        Assert.AreNotEqual(s1.GetComponent<Shrapnel>().getHeading(), s2.GetComponent<Shrapnel>().getHeading());
    }

    [UnityTest]
    public IEnumerator TestSpawnOnDestroy()
    {
        ShrapnelSpawner spawner = game.GetShrapnelSpawner();
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject Laser= game.GetShip().SpawnLaser();
        Laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.2f);

        Assert.Greater(spawner.gameObject.transform.childCount, 0);
    }
}
