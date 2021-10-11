using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScriptReload
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

    // Reload after 10 bullets
    // Key is ignored
    // cannot fire 3 bullets if 8 or more shots fired
    // bullets reset on gameover

    [UnityTest]
    public IEnumerator resetShotsFiredAfterTen()
    {
        game.GetShip().ShootLaser();
        game.GetShip().ReloadLaser();
        yield return new WaitForSeconds(0.2f);
        Assert.AreEqual(game.GetShip().shotsFired, 0);
    }


    [UnityTest]
    public IEnumerator resetShotsFiredOnGameOver()
    {
        game.GetShip().ShootLaser();

        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = game.GetShip().transform.position;
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(game.GetShip().shotsFired, 0);
    }

    //[UnityTest]
    //public IEnumerator reloadtimeTakesTwoSeconds()
    //{
    //    game.GetShip().ReloadLaser();
    //    yield return new WaitForSeconds(1.9f);
    //    Assert.AreEqual(game.GetShip().reloading, false);
    //    game.GetShip().ReloadLaser();
    //    yield return new WaitForSeconds(2.0f);
    //    Assert.AreEqual(game.GetShip().reloading, false);
    //}

}
