using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ShipTest
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
    public IEnumerator CooldownTest()
    {
        Ship ship = game.GetShip().GetComponent<Ship>();
        ship.TripleShootLaser();
        yield return new WaitForSeconds(1.0f);
        Assert.False(ship.canShoot);
    }

    [UnityTest]
    public IEnumerator TimerResetTest()
    {
        Ship ship = game.GetShip().GetComponent<Ship>();
        ship.TripleShootLaser();
        yield return new WaitForSeconds(4.0f);
        Assert.True(ship.canShoot);
    }
}
