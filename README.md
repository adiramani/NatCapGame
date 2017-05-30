# Northland: Arctic Choices
Digital board game

Compatibility: Unity 5.5.2f1

Devices tested on:
- Google Nexus 7 (Android 6.0)
- Apple iPad 4 Retina display (iOS 10.2.1)

## About

This game is based upon **[Arctic Choices](http://wwf.panda.org/what_we_do/where_we_work/arctic/what_we_do/arctic_choices.cfm)**, a board game created by the [Natural Capital project](http://www.naturalcapitalproject.org) to help teams of participants (business leaders, government officials, etc.) to understand the benefits and consequences of business development in highly climate-sensitive environments like the Arctic Circle.

### How to play

The game is designed to be played collaboratively on a tablet. There should be a moderator present to explain the premise, controls, and help reach conclusions.

In Round 1, only positive score factors are considered: value gained from port expansion and mine placement.

In Round 2, the negative score factors (value lost from harming food security and tourism potential) are subtracted from the sum of positive score factors.

### Controls - mouse

- Mouse wheel: zoom
- Left click: place and drag game pieces
- Right click: move camera

### Controls - touchscreen

- Pinch: zoom
- Tap: place game pieces
- Tap and drag: move game pieces
- Drag: move camera

---

# Files

### Environment Scripts:

- **CameraController.cs:** manages zooming camera. Sets maximum and minimum zoom, as well as zoom sensitivity.
- **KeyCanvas.cs:** updates colors in key sidebar
- **LevelManager.cs:** establishes level details including gridResolution (30), maxTileScore (50), and opacity of tiles. References TileScript.
- **MapController.cs:** scales the map sprite to the appropriate size and aspect ratio (1:1 for a 30x30 grid) for the game environment. Also in charge of "moving" the camera - when dragging, the map is moved.
- **MapLoader.cs:** contains a string with 3600 values for point values associated with tiles on different maps. Four values exist for each tile and are seperated by commas (ports, minerals, food, and tourism in order). Each line is a new row, and each tile within a row is seperated with a semicolon. String is parsed to populate map values in LevelManager.cs. Also references MapModeCanvas (where structure of string is enumerated).
- **MapModeBtn.cs:** appearance (normal/highlight/pressed colors) and function of the four map mode buttons. References MapModeCanvas.cs.
- **MapModeCanvas.cs:** enumerates the order of map mode values in the MapLoader string. Defines color scheme and opacity for each of the map modes. Referenced by MapModeBtn.cs and LevelManager.cs.
- **TileScript.cs:** determines and records colors and score values for individual tiles. Also records/listens to click input to determine where to place pieces on the game maps. Referenced in most other scripts.

### Editing Scripts:

- **LevelEditor.cs:** manages results of ValueBtn.cs script (below). Also toggles point value buttons on or off (see Editor Canvas in Unity environment).
- **ValueBtn.cs:** establishes buttons for point values from 0-50, listens to clicks and also determines appearance (color) of buttons.

### Gameplay Scripts:

- **Calculator.cs:** references PiecePlace.cs, gets score values for each piece placed and outputs them to display.
- **GamePieceScript.cs:** helps determine the score with getScore, locates tiles underneath game pieces. References MapModeCanvas.cs and LevelManager.cs. Also enables pieces to relocate based on hold and drag.
- **PieceButton.cs:** establishes appearance (color, sprites referenced), and listens to clicks to determine which piece (mine or port) is being placed.
- **PiecePlace.cs:** enumerates game piece types, establishes limits on numbers of pieces that can be placed (4 mines, 4 ports), allows pieces to be deleted by double-tapping, calculators scores based on type of game piece and MapLoader values.
- **RoundController.cs:** manages the "next round" and "end game" buttons; keeps track of current round and notifies relevant classes when this changed.
- **EndScreen.cs:** gets final score to display on game end screen, and provides "play again" button

### Sprites

- **mine.png:** 4x4 tile game piece for mines
- **newarcticmap.png:** latest version of map background for "Arctic"
- **port.png:** 4x4 tile game piece for ports
- **tileborder 2.png:** sprite for a single tile border (repeated for 30x30 grid)

---

## Misc info

### How do I create new map data?

Enable the "editing" checkmark in the EditorCanvas gameobject, under Level Editor script. Run the game, then use the new buttons to paint on the grid! Press space bar to output the new data to the console, and paste the information into `MapLoader.cs`.

**Note:** make sure you format the text correctly! Each line must end with a `\n`. See the existing data for an example!

### TODO / What still needs to get done?

- Add railroads and shipping lines. There needs to be some way to edit them in editing mode, the gamepiece for restricting shipping needs to be added, and the calculator should take these pieces into account.
- Limit placing ports to certain regions, just like in the physical board game.
- Main menu where users can switch between play and editing modes, as well as save and load different maps.
- Detail: Add little animal sprites.
