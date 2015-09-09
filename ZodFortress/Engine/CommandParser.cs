using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZodFortress.Engine
{
    public class CommandParser
    {
        public Command LastCommand { get; private set; }
        public CommandParser() { }
        public CommandParser(string input) : this()
        {
            Parse(input);
        }

        private static readonly Regex wordSequence = new Regex(@"\s*([A-Za-z]+)\s*");
        private static readonly string[] commandList = new string[]
                                                        {
                                                            // TODO: Add commands to list.
                                                            "help",
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
                                                            "run",
                                                            "step",
                                                            "maneuver",
                                                            "shift",
                                                            "sprint",
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
                                                           "backward",
                                                           "up",
                                                           "down",
                                                           "left",
                                                           "right",
                                                           "n",
                                                           "e",
                                                           "w",
                                                           "s"
                                                        };
        
        /// <summary>
        /// Used to parse the string commands into object commands.
        /// </summary>
        /// <param name="input">Input to parse</param>
        /// <returns>Sucess, command, order, object, location</returns>
        public Command Parse(string input)
        {
            var matches = wordSequence.Matches(input).OfType<Match>().ToArray();
            var commands = new List<string>();
            var orders = new List<string>();
            var objects = new List<string>();
            var locations = new List<string>();
            foreach (var match in matches)
            {
                commands.AddRange(commandList.Where(x => x == match.Groups[1].Value.ToLower()));
                orders.AddRange(orderList.Where(x => x == match.Groups[1].Value.ToLower()));
                objects.AddRange(objectList.Where(x => x == match.Groups[1].Value.ToLower()));
                locations.AddRange(locationList.Where(x => x == match.Groups[1].Value.ToLower()));
            }

            var output = new Command();

            if (commands.Any())
            {
                output.GameCommand = commands.First();
                output.Success = true;
            }

            else if (orders.Any() && locations.Any())
            {
                output.Order = orders.First();
                output.Location = locations.First();
                output.Success = true;
            }

            this.LastCommand = output;
            return output;
        }
    }
}
