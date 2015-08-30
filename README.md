# ZodFortress
## Introduction
Zod Fortress is a Dwarf Fortress clone made over the weekends. The game runs fully in the console with a command line interface (CLI).
The goal is to level up your hero and find equipment to kill Zod. The map is randomly generated for each game, although, there is only one 
Zod to kill on each map. 

## How to play

The commands are keyword based, which means you only have to type the keywords of the action you want to do.
You need 2 keywords for movement actions, and 3 keywords for other actions. The parser supports some variations such as `destroy`
intead of `attack` or `run` instead of `walk`.

### Commands
Things the program can do for you.
- `Help` Shows help dialog
- `quit` Leaves the game

### Actions
Things you can do.
- `attack` Attacks things directly next to you
- `talk` Talks to NPC directly next to you
- `equip` Equips item to offensive slot or defensive slot

### Objects
Things you can target actions at.
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
- `right

