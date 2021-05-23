﻿using System.Collections.Generic;
using System.Drawing;
using GameModel.Model;
using GameModel.Model.Mobs;

namespace GameModel.Levels
{
    public static class ReleaseLevels
    {
        public static Level GetLevel1()
        {
            var naruto = new Hero(
                    "Naruto",
                    new Size(64, 64),
                    new Point(300, 200),
                    100,
                    50,
                    100,
                    6);
            var mobList1 = new List<Mob>
            {
                new Mob(
                    "Pear",
                    new Size(100, 100),
                    new Point(650, 0), 25, 0, 0, 0),
                new Mob(
                    "Creeper",
                    new Size(100, 100),
                    new Point(650, 0), 25, 2, 0, 0)
            };
            var map1 = new Map(
                new[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2}}, 
                mobList1);
            ////
            var mobList2 = new List<Mob>
            {
                new Mob(
                    "Creeper",
                    new Size(82, 82),
                    new Point(670, 50)),
                new Mob(
                    "Creeper",
                    new Size(82, 82),
                    new Point(670, 160)),
                new Mob(
                    "Creeper",
                    new Size(82, 82),
                    new Point(670, 280)),
                new Mob(
                    "Creeper",
                    new Size(82, 82),
                    new Point(50, 50)),
                new Mob(
                    "Creeper",
                    new Size(82, 82),
                    new Point(50, 160)),
                new Mob(
                    "Creeper",
                    new Size(82, 82),
                    new Point(50, 280))
            };
            var map2 = new Map(new [,] {
                    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {2, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 2, 2},
                    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 1, 2, 2}},
                mobList2);
            ////
            var mobList3 = new List<Mob>
            {
                new Mob(
                    "Sasuke",
                    new Size(64, 64),
                    new Point(160, 440), 50),
                new Mob(
                    "Sasuke",
                    new Size(64, 64),
                    new Point(680, 440), 50)
            };
            var map3 = new Map(
                new[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 3, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 3, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 3, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                    {0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 2, 0, 0, 2},
                    {0, 0, 0, 1, 2, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2},
                    {0, 0, 1, 2, 2, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2},
                    {0, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2},
                    {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2},
                    {0, 1, 3, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2},
                    {0, 1, 0, 0, 0, 0, 0, 1, 2, 2, 2, 0, 0, 0, 2},
                    {0, 1, 2, 2, 0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 2},
                    {0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 2},
                    {0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 2},
                    {0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 2, 2},
                    {0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 1, 2}}, 
                mobList3);
            ////
            var mobList4 = new List<Mob>
            {
                new Mob(
                    "Pear",
                    new Size(100, 100),
                    new Point(680, 50), 25, 0, 0, 0)
            };
            var map4 = new Map(
                new[,]
                {
                    {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {3, 0, 0, 2, 2, 2, 0, 0, 1, 0, 0, 0, 1, 2, 2},
                    {3, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {3, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {3, 2, 2, 2, 2, 2, 0, 0, 0, 1, 0, 0, 1, 2, 2}}, 
                mobList4);
            ////
            var bossList = new List<Mob>
            {
                new Mob(
                    "Pudge",
                    new Size(150, 200),
                    new Point(560, 280),
                    150,
                    33,
                    cooldown: 20),
            };
            var finalBoss = new Map(
                new[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 1, 2, 2, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 2, 2}}, 
                bossList);
            ////
            var finalMap = new Map(
                new[,]
                {
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 0, 0, 0},
                    {0, 3, 0, 0, 0, 0, 0, 3, 0, 3, 0, 3, 0, 0, 0},
                    {0, 3, 3, 3, 3, 3, 0, 3, 0, 3, 0, 3, 0, 0, 0},
                    {0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 0, 0, 0},
                    {0, 3, 3, 3, 3, 3, 0, 0, 3, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0},
                    {0, 3, 3, 3, 3, 3, 0, 0, 0, 0, 3, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 0, 0, 0},
                    {0, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 3, 0, 3, 0, 3, 0, 3, 3, 3, 3, 3, 0, 0, 0},
                    {0, 3, 0, 3, 0, 3, 0, 3, 0, 0, 0, 3, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}, 
                new List<Mob>());
            return new Level(naruto, new List<Map> {map1, map3, map2, map4, finalBoss, finalMap}, 5);
        }
    }
}