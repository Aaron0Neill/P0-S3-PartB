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
}
