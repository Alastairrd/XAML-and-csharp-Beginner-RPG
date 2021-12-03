using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Engine.Factories;
using Engine.Models;
using Engine.Actions;

namespace TestEngine.Actions
{
    [TestClass]
    public class TestAttackWithWeapon
    {
        [TestMethod]
        public void Test_Contructor_GoodParameters()
        {
            GameItem pointyStick = ItemFactory.CreateGameItem(1001);

            AttackWithWeapon attackWithWeapon = new AttackWithWeapon(pointyStick, 1, 5);

            Assert.IsNotNull(attackWithWeapon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Constructor_ItemIsNotWeapon()
        {
            GameItem granolaBar = ItemFactory.CreateGameItem(2001);

            //granola bar is not a weapon
            //constructor should throw an exception

            AttackWithWeapon attackWithWeapon = new AttackWithWeapon(granolaBar, 1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Constructor_MinimumDamageLessThanZero()
        {
            GameItem pointyStick = ItemFactory.CreateGameItem(1001);

            //constructor should throw an exception as minimum damage cannot be less than 0

            AttackWithWeapon attackWithWeapon = new AttackWithWeapon(pointyStick, -1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Constructor_MaximumDamageLessThanMinimum()
        {
            GameItem pointyStick = ItemFactory.CreateGameItem(1001);

            //constructor should throw an exception as maximum damage cannot be less than minimum

            AttackWithWeapon attackWithWeapon = new AttackWithWeapon(pointyStick, 2, 1);
        }
    }
}
