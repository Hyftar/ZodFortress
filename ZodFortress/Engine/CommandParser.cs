using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                                                            "leave",
                                                            "quit",
                                                            "exit"
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
                                                            "zod",
                                                            "mob"
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

        /// <summary>
        /// Used to parse the string commands into object commands.
        /// </summary>
        /// <param name="input">Input to parse</param>
        /// <returns>Sucess, command, order, object, location</returns>
        private Command Parse(string input)
        {
            var matches = wordSequence.Matches(input).OfType<Match>().ToArray();
            var commands = new List<string>();
            var orders = new List<string>();
            var objects = new List<string>();
            var locations = new List<string>();
            foreach (var match in matches)
            {
                commands = commandList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
                orders = orderList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
                objects = objectList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
                locations = locationList.Where(x => x == match.Groups[1].Value.ToLower()).ToList();
            }

            var output = new Command();

            if (commands.Count > 1 || orders.Count > 1 || locations.Count > 1 || objects.Count > 1)
                return output;

            else if (commands.Any())
                output.GameCommand = commands.First();

            else if (orders.Any() && locations.Any())
            {
                output.Order = orders.First();
                output.Object = objects.First();
                if (locations.Any())
                    output.Location = locations.First();
            }
            output.Success = true;
            return output;
        }
    }
}
