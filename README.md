# ZodFortress
## Introduction
Zod Fortress is a Dwarf Fortress inspired-game made over the weekends. The game runs fully in the console using a command line interface (CLI).
The goal is to level up your hero by killing mobs and find equipment to kill the final boss, Zod. The map is randomly generated for each game, and there is only one
Zod to kill on each map. Zod Fortress will be, for the longest time, in work in progress since this game is only a weekend project, it will progress really slowly, it also means
that the game will never be in a finished state as we strive to update, evolve and polish this project.

## How to play

The commands are keyword based, which means you only have to type the keywords of the action you want to do.
You need 2 keywords for movement actions, and 3 keywords for other actions. The parser supports some variations such as `destroy`
intead of `attack` or `run` instead of `walk`.

### Commands
Things the program can do for you.
- `help` Shows help dialog
- `quit` Leaves the game

### Actions
Things you can do.
- `attack` Attacks things directly next to you
- `talk` Talks to NPC directly next to you
- `equip` Equips item to offensive slot or defensive slot

### Objects
Things you can target actions at. (Objects might be removed from commands in the final version)
- `terrain` Terrain directly next to you
- `mob` Mob directly next to you

### Locations
Where the objects can be.
- `north`
- `south`
- `west`
- `east`
- `up`
- `down`
- `left`
- `right`
