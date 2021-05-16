﻿using System;
using System.Collections.Generic;
using System.Drawing;
using GameModel.Model;
using GameModel.Model.Mobs;

namespace GameModel.Levels
{
    public static class TestLevel
    {
        public static Level GetTestLevel0()
        {
            var naruto =
                new Hero(
                    "Naruto",
                    new Size(64, 64),
                    new Point(0, 100),
                    1000,
                    1000,
                    1000);
            var mobTest1List = new List<Mob>
            {
                new Mob(
                    "Creeper",
                    new Size(128, 128),
                    new Point(100, 100),
                    cooldown: 100,
                    attack: 250),
                new Mob(
                    "Creeper",
                    new Size(64, 64),
                    new Point(400, 150),
                    cooldown: 100,
                    attack: 250),
                new Mob(
                    "Creeper",
                    new Size(64, 64),
                    new Point(50, 0)),
                new Mob(
                    "Creeper",
                    new Size(64, 64),
                    new Point(150, 150))
            };
            var testMap1 = new Map(
                new[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 2, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}}, 
                mobTest1List);
            /////////////////////////////////////////////////////////
            var mobTest2List = new List<Mob>
            {
                new Mob(
                    "Sasuke",
                    new Size(64, 64),
                    new Point(460, 200))
            };
            var testMap2 = new Map(new [,] {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                {0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}},
                mobTest2List);
            /////////////////////////////////////////////////
            var testMap3 = TestMap3();
            return new Level(naruto, new List<Map> {testMap1, testMap2, testMap3}, 5);
        }

        private static Map TestMap3()
        {
            var mobTest3List = new List<Mob>
            {
                new Mob(
                    "Pudge",
                    new Size(256, 256),
                    new Point(460, 0)),
            };
            var testMap3 = new Map(
                new[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}}, 
                mobTest3List);
            return testMap3;
        }
    }
}