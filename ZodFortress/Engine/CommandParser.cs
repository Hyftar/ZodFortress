﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZodFortress.Engine
{
    public class CommandParser
    {
        private static readonly Regex wordSequence = new Regex(@"\s*([A-Za-z]+)\s*");
        private static readonly string[] commandList = new string[]
                                                        {
                                                            // TODO: Add commands to list.
                                                            "help",
                                                            "?",
                                                            "halp",
                                                            "fuck",
                                                            "wtf",
                                                            "end",
                                                        };

        private static readonly string[] orderList = new string[]
                                                        {
                                                            // TODO: Add orders to list.
                                                            "exit",
                                                            "leave",
                                                            "kill",
                                                            "attack",
                                                            "destroy",
                                                            "talk",
                                                            "speak",
                                                            "shout",
                                                            "whisper",
                                                            "equip",
                                                            "unequip",
                                                            "wear",
                                                            "wield",
                                                            "move",
                                                            "advance",
                                                            "step",
                                                            "maneuver",
                                                            "shift",
                                                            "travel"
                                                        };

        private static readonly string[] objectList = new string[]
                                                        {
                                                            // TODO: Add objects to list.
                                                            "man",
                                                            "orc",
                                                            "zod"
                                                        };

        private static readonly string[] locationList = new string[]
                                                        {
                                                            // TODO: Add more locations.
                                                           "north",
                                                           "south",
                                                           "east",
                                                           "west",
                                                           "forward",
                                                           "up",
                                                           "down",
                                                           "left",
                                                           "right",
                                                           "n",
                                                           "e",
                                                           "w",
                                                           "s"
                                                        };

        public CommandParser(string input)
        {
            Parse(input);

        }

        private void Parse(string input)
        {
            var matches = wordSequence.Matches(input).OfType<Match>().ToArray();
            List<string> commands = new List<string>();
            List<string> orders = new List<string>();
            List<string> locations = new List<string>();
            List<string> objects = new List<string>();
            foreach (var match in matches)
            {
                commands = commandList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
                orders = orderList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
                locations = locationList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
                objects = objectList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
            }
        }
    }
}
