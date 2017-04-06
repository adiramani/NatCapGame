##ARCTIC CHOICES README##

**Prepared by:** Andrey Butenko, Edward Yang.

Compatibility: Unity 5.5.2f1
Game filename: test.unity
Last stable version: ArcticChoicesv4, 06 April 2017
Platforms/devices tested on:

- Google Nexus 7 (Android 6.0)
- Apple iPad 4 Retina display (iOS 10.2.1)

###About###

This game is based upon **[Arctic Choices](http://wwf.panda.org/what_we_do/where_we_work/arctic/what_we_do/arctic_choices.cfm)**, a board game created by the [Natural Capital project](http://www.naturalcapitalproject.org) to help teams of participants (business leaders, government officials, etc.) to understand the benefits and consequences of business development in highly climate-sensitive environments like the Arctic Circle.

The game is designed to be played collaboratively on a tablet.

----
##SCRIPTS##

###Environment Scripts:###

- **CameraController.cs:** establishes sensitivity values for pinch and finger move (tablet) or mouseZoom and mouseMove (scrolling and moving mouse). Defines maximum and minimum zoom in Unity environment. Defines maximum movement limit (prevents "jumping" issues).
- **LevelManager.cs:** establishes level details including gridResolution (30), maxTileScore (50), and opacity of tiles. References TileScript.
- **MapController.cs:** scales the map sprite to the appropriate size and aspect ratio (1:1 for a 30x30 grid) for the game environment.
- **MapLoader.cs:** contains a string with 3600 values for point values associated with tiles on different maps. Four values exist for each tile )ports, minerals, food, and tourism in order) rows correspond to map rows, columns change every four values. String is passed into LevelManager.cs. Also references MapModeCanvas (where structure of string is enumerated).
- **MapModeBtn.cs:** appearance (normal/highlight/pressed colors) and function of the four map mode buttons. References MapModeCanvas.cs.
- **MapModeCanvas.cs:** enumerates the order of map mode values in the MapLoader string. Defines color scheme and opacity for each of the map modes. Referenced by MapModeBtn.cs and LevelManager.cs.
- **TileScript.cs:** determines and records colors and score values for individual tiles. Also records/listens to click input to determine where to place pieces on the game maps. Referenced in most other scripts.

###Editing Scripts:###

- **LevelEditor.cs:** manages results of ValueBtn.cs script (below). Also toggles point value buttons on or off (see Editor Canvas in Unity environment).
- **ValueBtn.cs:** establishes buttons for point values from 0-50, listens to clicks and also determines appearance (color) of buttons.

###Gameplay Scripts###

- **Calculator.cs:** references PiecePlace.cs, gets score values for each piece placed and outputs them to display.
- **GamePieceScript.cs:** helps determine the score with getScore, locates tiles underneath game pieces. References MapModeCanvas.cs and LevelManager.cs. Also enables pieces to relocate based on hold and drag.
- **PieceButton.cs:** establishes appearance (color, sprites referenced), and listens to clicks to determine which piece (mine or port) is being placed.
- **PiecePlace.cs:** enumerates game piece types, establishes limits on numbers of pieces that can be placed (4 mines, 4 ports), allows pieces to be deleted by double-tapping, calculators scores based on type of game piece and MapLoader values.

----
##SPRITES##

- **mine.png:** 4x4 tile game piece for mines
- **newarcticmap.png:** latest version of map background for "Arctic"
- **port.png:** 4x4 tile game piece for ports
- **tileborder 2.png:** sprite for a single tile border (repeated for 30x30 grid)
