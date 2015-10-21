﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using CustomCalculationServiceConnectionLib;
using Data;
using DatabaseEntities.Entities;
using DataRepo;
using DataRepositories.Repositories;
using DataServices;
using Dota2WebAPI.Commands;
using Newtonsoft.Json;
using QuandlCS.Connection;
using QuandlCS.Interfaces;
using QuandlCS.Requests;
using QuandlCS.Types;
using RestSharp;

namespace Dota2WebAPI.Controllers
{
    public class DotaController : ApiController
    {
        //Steam api key: 893F592E19918CA8A9CB5A847C94E2ED
        // GET api/dota

        /*
          var data =
                "[\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_antimage\",\n\t\t\t\t\"id\": 1,\n\t\t\t\t\"localized_name\": \"Anti-Mage\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_axe\",\n\t\t\t\t\"id\": 2,\n\t\t\t\t\"localized_name\": \"Axe\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_bane\",\n\t\t\t\t\"id\": 3,\n\t\t\t\t\"localized_name\": \"Bane\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_bloodseeker\",\n\t\t\t\t\"id\": 4,\n\t\t\t\t\"localized_name\": \"Bloodseeker\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_crystal_maiden\",\n\t\t\t\t\"id\": 5,\n\t\t\t\t\"localized_name\": \"Crystal Maiden\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_drow_ranger\",\n\t\t\t\t\"id\": 6,\n\t\t\t\t\"localized_name\": \"Drow Ranger\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_earthshaker\",\n\t\t\t\t\"id\": 7,\n\t\t\t\t\"localized_name\": \"Earthshaker\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_juggernaut\",\n\t\t\t\t\"id\": 8,\n\t\t\t\t\"localized_name\": \"Juggernaut\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_mirana\",\n\t\t\t\t\"id\": 9,\n\t\t\t\t\"localized_name\": \"Mirana\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_nevermore\",\n\t\t\t\t\"id\": 11,\n\t\t\t\t\"localized_name\": \"Shadow Fiend\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_morphling\",\n\t\t\t\t\"id\": 10,\n\t\t\t\t\"localized_name\": \"Morphling\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_phantom_lancer\",\n\t\t\t\t\"id\": 12,\n\t\t\t\t\"localized_name\": \"Phantom Lancer\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_puck\",\n\t\t\t\t\"id\": 13,\n\t\t\t\t\"localized_name\": \"Puck\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_pudge\",\n\t\t\t\t\"id\": 14,\n\t\t\t\t\"localized_name\": \"Pudge\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_razor\",\n\t\t\t\t\"id\": 15,\n\t\t\t\t\"localized_name\": \"Razor\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_sand_king\",\n\t\t\t\t\"id\": 16,\n\t\t\t\t\"localized_name\": \"Sand King\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_storm_spirit\",\n\t\t\t\t\"id\": 17,\n\t\t\t\t\"localized_name\": \"Storm Spirit\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_sven\",\n\t\t\t\t\"id\": 18,\n\t\t\t\t\"localized_name\": \"Sven\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_tiny\",\n\t\t\t\t\"id\": 19,\n\t\t\t\t\"localized_name\": \"Tiny\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_vengefulspirit\",\n\t\t\t\t\"id\": 20,\n\t\t\t\t\"localized_name\": \"Vengeful Spirit\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_windrunner\",\n\t\t\t\t\"id\": 21,\n\t\t\t\t\"localized_name\": \"Windranger\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_zuus\",\n\t\t\t\t\"id\": 22,\n\t\t\t\t\"localized_name\": \"Zeus\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_kunkka\",\n\t\t\t\t\"id\": 23,\n\t\t\t\t\"localized_name\": \"Kunkka\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_lina\",\n\t\t\t\t\"id\": 25,\n\t\t\t\t\"localized_name\": \"Lina\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_lich\",\n\t\t\t\t\"id\": 31,\n\t\t\t\t\"localized_name\": \"Lich\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_lion\",\n\t\t\t\t\"id\": 26,\n\t\t\t\t\"localized_name\": \"Lion\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_shadow_shaman\",\n\t\t\t\t\"id\": 27,\n\t\t\t\t\"localized_name\": \"Shadow Shaman\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_slardar\",\n\t\t\t\t\"id\": 28,\n\t\t\t\t\"localized_name\": \"Slardar\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_tidehunter\",\n\t\t\t\t\"id\": 29,\n\t\t\t\t\"localized_name\": \"Tidehunter\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_witch_doctor\",\n\t\t\t\t\"id\": 30,\n\t\t\t\t\"localized_name\": \"Witch Doctor\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_riki\",\n\t\t\t\t\"id\": 32,\n\t\t\t\t\"localized_name\": \"Riki\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_enigma\",\n\t\t\t\t\"id\": 33,\n\t\t\t\t\"localized_name\": \"Enigma\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_tinker\",\n\t\t\t\t\"id\": 34,\n\t\t\t\t\"localized_name\": \"Tinker\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_sniper\",\n\t\t\t\t\"id\": 35,\n\t\t\t\t\"localized_name\": \"Sniper\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_necrolyte\",\n\t\t\t\t\"id\": 36,\n\t\t\t\t\"localized_name\": \"Necrophos\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_warlock\",\n\t\t\t\t\"id\": 37,\n\t\t\t\t\"localized_name\": \"Warlock\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_beastmaster\",\n\t\t\t\t\"id\": 38,\n\t\t\t\t\"localized_name\": \"Beastmaster\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_queenofpain\",\n\t\t\t\t\"id\": 39,\n\t\t\t\t\"localized_name\": \"Queen of Pain\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_venomancer\",\n\t\t\t\t\"id\": 40,\n\t\t\t\t\"localized_name\": \"Venomancer\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_faceless_void\",\n\t\t\t\t\"id\": 41,\n\t\t\t\t\"localized_name\": \"Faceless Void\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_skeleton_king\",\n\t\t\t\t\"id\": 42,\n\t\t\t\t\"localized_name\": \"Wraith King\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_death_prophet\",\n\t\t\t\t\"id\": 43,\n\t\t\t\t\"localized_name\": \"Death Prophet\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_phantom_assassin\",\n\t\t\t\t\"id\": 44,\n\t\t\t\t\"localized_name\": \"Phantom Assassin\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_pugna\",\n\t\t\t\t\"id\": 45,\n\t\t\t\t\"localized_name\": \"Pugna\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_templar_assassin\",\n\t\t\t\t\"id\": 46,\n\t\t\t\t\"localized_name\": \"Templar Assassin\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_viper\",\n\t\t\t\t\"id\": 47,\n\t\t\t\t\"localized_name\": \"Viper\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_luna\",\n\t\t\t\t\"id\": 48,\n\t\t\t\t\"localized_name\": \"Luna\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_dragon_knight\",\n\t\t\t\t\"id\": 49,\n\t\t\t\t\"localized_name\": \"Dragon Knight\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_dazzle\",\n\t\t\t\t\"id\": 50,\n\t\t\t\t\"localized_name\": \"Dazzle\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_rattletrap\",\n\t\t\t\t\"id\": 51,\n\t\t\t\t\"localized_name\": \"Clockwerk\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_leshrac\",\n\t\t\t\t\"id\": 52,\n\t\t\t\t\"localized_name\": \"Leshrac\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_furion\",\n\t\t\t\t\"id\": 53,\n\t\t\t\t\"localized_name\": \"Nature's Prophet\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_life_stealer\",\n\t\t\t\t\"id\": 54,\n\t\t\t\t\"localized_name\": \"Lifestealer\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_dark_seer\",\n\t\t\t\t\"id\": 55,\n\t\t\t\t\"localized_name\": \"Dark Seer\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_clinkz\",\n\t\t\t\t\"id\": 56,\n\t\t\t\t\"localized_name\": \"Clinkz\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_omniknight\",\n\t\t\t\t\"id\": 57,\n\t\t\t\t\"localized_name\": \"Omniknight\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_enchantress\",\n\t\t\t\t\"id\": 58,\n\t\t\t\t\"localized_name\": \"Enchantress\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_huskar\",\n\t\t\t\t\"id\": 59,\n\t\t\t\t\"localized_name\": \"Huskar\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_night_stalker\",\n\t\t\t\t\"id\": 60,\n\t\t\t\t\"localized_name\": \"Night Stalker\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_broodmother\",\n\t\t\t\t\"id\": 61,\n\t\t\t\t\"localized_name\": \"Broodmother\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_bounty_hunter\",\n\t\t\t\t\"id\": 62,\n\t\t\t\t\"localized_name\": \"Bounty Hunter\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_weaver\",\n\t\t\t\t\"id\": 63,\n\t\t\t\t\"localized_name\": \"Weaver\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_jakiro\",\n\t\t\t\t\"id\": 64,\n\t\t\t\t\"localized_name\": \"Jakiro\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_batrider\",\n\t\t\t\t\"id\": 65,\n\t\t\t\t\"localized_name\": \"Batrider\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_chen\",\n\t\t\t\t\"id\": 66,\n\t\t\t\t\"localized_name\": \"Chen\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_spectre\",\n\t\t\t\t\"id\": 67,\n\t\t\t\t\"localized_name\": \"Spectre\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_doom_bringer\",\n\t\t\t\t\"id\": 69,\n\t\t\t\t\"localized_name\": \"Doom\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_ancient_apparition\",\n\t\t\t\t\"id\": 68,\n\t\t\t\t\"localized_name\": \"Ancient Apparition\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_ursa\",\n\t\t\t\t\"id\": 70,\n\t\t\t\t\"localized_name\": \"Ursa\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_spirit_breaker\",\n\t\t\t\t\"id\": 71,\n\t\t\t\t\"localized_name\": \"Spirit Breaker\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_gyrocopter\",\n\t\t\t\t\"id\": 72,\n\t\t\t\t\"localized_name\": \"Gyrocopter\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_alchemist\",\n\t\t\t\t\"id\": 73,\n\t\t\t\t\"localized_name\": \"Alchemist\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_invoker\",\n\t\t\t\t\"id\": 74,\n\t\t\t\t\"localized_name\": \"Invoker\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_silencer\",\n\t\t\t\t\"id\": 75,\n\t\t\t\t\"localized_name\": \"Silencer\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_obsidian_destroyer\",\n\t\t\t\t\"id\": 76,\n\t\t\t\t\"localized_name\": \"Outworld Devourer\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_lycan\",\n\t\t\t\t\"id\": 77,\n\t\t\t\t\"localized_name\": \"Lycan\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_brewmaster\",\n\t\t\t\t\"id\": 78,\n\t\t\t\t\"localized_name\": \"Brewmaster\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_shadow_demon\",\n\t\t\t\t\"id\": 79,\n\t\t\t\t\"localized_name\": \"Shadow Demon\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_lone_druid\",\n\t\t\t\t\"id\": 80,\n\t\t\t\t\"localized_name\": \"Lone Druid\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_chaos_knight\",\n\t\t\t\t\"id\": 81,\n\t\t\t\t\"localized_name\": \"Chaos Knight\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_meepo\",\n\t\t\t\t\"id\": 82,\n\t\t\t\t\"localized_name\": \"Meepo\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_treant\",\n\t\t\t\t\"id\": 83,\n\t\t\t\t\"localized_name\": \"Treant Protector\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_ogre_magi\",\n\t\t\t\t\"id\": 84,\n\t\t\t\t\"localized_name\": \"Ogre Magi\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_undying\",\n\t\t\t\t\"id\": 85,\n\t\t\t\t\"localized_name\": \"Undying\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_rubick\",\n\t\t\t\t\"id\": 86,\n\t\t\t\t\"localized_name\": \"Rubick\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_disruptor\",\n\t\t\t\t\"id\": 87,\n\t\t\t\t\"localized_name\": \"Disruptor\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_nyx_assassin\",\n\t\t\t\t\"id\": 88,\n\t\t\t\t\"localized_name\": \"Nyx Assassin\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_naga_siren\",\n\t\t\t\t\"id\": 89,\n\t\t\t\t\"localized_name\": \"Naga Siren\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_keeper_of_the_light\",\n\t\t\t\t\"id\": 90,\n\t\t\t\t\"localized_name\": \"Keeper of the Light\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_wisp\",\n\t\t\t\t\"id\": 91,\n\t\t\t\t\"localized_name\": \"Io\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_visage\",\n\t\t\t\t\"id\": 92,\n\t\t\t\t\"localized_name\": \"Visage\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_slark\",\n\t\t\t\t\"id\": 93,\n\t\t\t\t\"localized_name\": \"Slark\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_medusa\",\n\t\t\t\t\"id\": 94,\n\t\t\t\t\"localized_name\": \"Medusa\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_troll_warlord\",\n\t\t\t\t\"id\": 95,\n\t\t\t\t\"localized_name\": \"Troll Warlord\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_centaur\",\n\t\t\t\t\"id\": 96,\n\t\t\t\t\"localized_name\": \"Centaur Warrunner\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_magnataur\",\n\t\t\t\t\"id\": 97,\n\t\t\t\t\"localized_name\": \"Magnus\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_shredder\",\n\t\t\t\t\"id\": 98,\n\t\t\t\t\"localized_name\": \"Timbersaw\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_bristleback\",\n\t\t\t\t\"id\": 99,\n\t\t\t\t\"localized_name\": \"Bristleback\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_tusk\",\n\t\t\t\t\"id\": 100,\n\t\t\t\t\"localized_name\": \"Tusk\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_skywrath_mage\",\n\t\t\t\t\"id\": 101,\n\t\t\t\t\"localized_name\": \"Skywrath Mage\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_abaddon\",\n\t\t\t\t\"id\": 102,\n\t\t\t\t\"localized_name\": \"Abaddon\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_elder_titan\",\n\t\t\t\t\"id\": 103,\n\t\t\t\t\"localized_name\": \"Elder Titan\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_legion_commander\",\n\t\t\t\t\"id\": 104,\n\t\t\t\t\"localized_name\": \"Legion Commander\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_ember_spirit\",\n\t\t\t\t\"id\": 106,\n\t\t\t\t\"localized_name\": \"Ember Spirit\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_earth_spirit\",\n\t\t\t\t\"id\": 107,\n\t\t\t\t\"localized_name\": \"Earth Spirit\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_terrorblade\",\n\t\t\t\t\"id\": 109,\n\t\t\t\t\"localized_name\": \"Terrorblade\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_phoenix\",\n\t\t\t\t\"id\": 110,\n\t\t\t\t\"localized_name\": \"Phoenix\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_oracle\",\n\t\t\t\t\"id\": 111,\n\t\t\t\t\"localized_name\": \"Oracle\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_techies\",\n\t\t\t\t\"id\": 105,\n\t\t\t\t\"localized_name\": \"Techies\"\n\t\t\t},\n\t\t\t{\n\t\t\t\t\"name\": \"npc_dota_hero_winter_wyvern\",\n\t\t\t\t\"id\": 112,\n\t\t\t\t\"localized_name\": \"Winter Wyvern\"\n\t\t\t}\n\t\t]";
            var dbData = JsonConvert.DeserializeObject<Hero[]>(data);
            context.Heroes.AddOrUpdate(dbData);
         */

        //Klausimai:
        //Kad atnaujintų panaikintus laukus duombazėj
        //Kodėl dabar reikia force, seniau nereikėjo duombazėj
        //Kas i6kvie2ia mano serviso IDispose metodą?
        //Aprašyti routai neveikia su GET
        //Suvaldyti exception
        //Kuo skiriasi namespace viduje ir išorėje parašytas using
        //Validacija kiek geresnė nei if
        //Kokia nauda man iš tų trijų layer?

        private readonly IHeroesService _heroService;
        //public DotaController(IHeroRepository repo)
        //{
        //    this._heroRepo = repo;
        //}
        public DotaController(IHeroesService  heroService)
        {
            _heroService = heroService;
        }
        public IList<Hero> GetAllHeroes()
        {
           // var command = (TestCommand)DependencyResolver.Current.GetService(typeof(ICommand));
           // command.Execute();
            return _heroService.GetAll();
        }

        public Hero GetHero(int id)
        {
            return null;
        }

        public IEnumerable<string> Get()
        {
            return new [] { "value1", "value2" };
        }

        // GET api/dota/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/dota
        public object Post([FromBody]string value)
        {
            return new {value};
        }

        // PUT api/dota/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/dota/5
        public void Delete(int id)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> PlayerID</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Match GetPlayerEfficiencyInMatch(int id, [FromBody] WinrateAgaintOtherHeroDto data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            data.IsValidThrowable();
            var client = new RestClient(Globals.DotaSteamAPI);
            var request = new RestRequest(Globals.DotaSteamAPIDotaInterfarce + "GetMatchDetails/" + Globals.DotaSteamAPIWeb1 + "?key={raktas}&match_id={mm}", Method.GET);
            request.AddUrlSegment("raktas", Globals.DotaAPIKey); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("mm", id.ToString());
            var response = client.Execute(request);
            //Neveikia šitas
            //IRestResponse<Match> response2 = client.Execute<Match>(request);
            var info = JsonConvert.DeserializeObject<SteamResponseMatche>(response.Content);
            return info.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Match ID</param>
        /// <returns></returns>
        public decimal WinrateAgaintOtherHero(int id)
        {
            //1868919644
            return 5.1m + id;
        }
        public object MyPost(int id, [FromBody] object value)
        {
            var request = new QuandlDownloadRequest
            {
                
                APIKey = Globals.APIKey,
                Datacode = new Datacode("PRAGUESE", "PX"),
                Format = FileFormats.JSON,
                Frequency = Frequencies.Monthly,
                Truncation = 150,
                Sort = SortOrders.Ascending,
                Transformation = Transformations.Difference
            };
            IQuandlConnection connection = new QuandlConnection();
            var data = connection.Request(request);
            // PRAGUESE is the source, PX is the datacode

            //Console.WriteLine("The request string is : {0}", request.ToRequestString());
            return new { function = "MyPost(int id, [FromBody] string value)", val = value, data = JsonConvert.DeserializeObject(data) };
        }

        public object Testas(int id, [FromBody] object value)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodName = "MyMethod",
                MethodController = "Calculation",
                Body = value,
                URLParameters = new[] {"2"},
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.POST
            };
            CustomCalculationServiceConnection a = new CustomCalculationServiceConnection();
            object response = a.Request(request);
            return new { value, response};
        }
        public object Testas2(int id, [FromBody] object value)
        {
            var request = new CustomCalculationServiceRequest
            {
                MethodName = "",
                MethodController = "Calculation",
                Body = value,
                URLParameters = new[] { "2" },
                MethodType = CustomCalculationServiceRequest.RequestTypeEnum.GET
            };
            CustomCalculationServiceConnection a = new CustomCalculationServiceConnection();
            object response = a.Request(request);
            return new { value, response };
        }
        public object MyPost2(int id, [FromBody] string value)
        {
            QuandlSearchRequest request = new QuandlSearchRequest();
            request.APIKey = "1234-FAKE-KEY-4321";
            request.Format = FileFormats.JSON;
            request.SearchQuery = value;
            IQuandlConnection connection = new QuandlConnection();
            var data = connection.Request(request);
            return new { function = "MyPost2(int id, [FromBody] string value)", val = JsonConvert.DeserializeObject(data) };
        }
        [System.Web.Http.Route("api/{controller}/MyPostas")]
        public object MyPosta([FromBody] object value)
        {
            return new { function = "MyPosta([FromBody] string value)", value };
        }
    }
}
