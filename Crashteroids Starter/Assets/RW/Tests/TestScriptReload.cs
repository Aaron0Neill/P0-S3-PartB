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

    [UnityTest]
    public IEnumerator reloadtimeTakesTwoSeconds()
    {
        game.GetShip().ReloadLaser();
        yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(game.GetShip().reloading, false);
    }

    // test can you fire triple shot at 8 bullets
    public IEnumerator needThreeBulletsFortripleShot()
    {
        game.GetShip().shotsFired = 7;
        // force triple shot here
        // Assert canShoot is false and triple shot does not fire
        //game.GetShip().ReloadLaser();
        yield return new WaitForSeconds(0.2f);
    }

}
