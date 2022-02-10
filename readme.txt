==========================================
 A Barebones Guide to Using Porno-Graphic
==========================================

This is an open source project. Please visit our Github page:
https://github.com/BHDN-Rotwang/porno-graphic

Porno-Graphic is a utility that aids in editing indexed color graphics for old video game systems. What sets Porno-Graphic apart from other tile editors is the sheer number of graphics formats supported. Users can define their own graphics profiles, allowing support for just about any tile size or bitplane format you can dream of. As well, instead of trying to reinvent the wheel by including drawing tools, all the editing is done through a actual graphics editing program (we recommend Gimp, although Photoshop can also work). 

Please note that this is an early experimental version that does not have some planned features. It most likely contains bugs. Use at your own risk. I take no responsibility for anything this program might do.

Here's a quick rundown of how to use it.

1 - Start a new project. If the system you want to edit graphics for is not supported, you'll have to make a new profile for it (see the "profiles" folder) by adapting the gfx_layout from the system's driver in MAME's source code. See: https://github.com/mamedev/mame/blob/master/src/mame/drivers/

If the system is supported, you'll have to tell it where to find the ROMs. This can either be a flat binary file, or the individual ROMs. WARNING: At this moment, Porno-Graphic can only export to a flat binary file, so if you want to split your flat binary back to its original ROMs you'll have to use another tool like ROM Mangler. See: https://github.com/originalgrego/RomMangler

You'll have to define the starting address of where to begin reading gfx elements (default is 0).

You'll also have to specify how many gfx elements you want to load. You can express this as either a literal value (prefix with 0x to use a hexadecimal value) or as a fraction.

2 - Click on File -> Export to Tiled map and tileset. This will generate a Tiled map file and a PNG of all the gfx elements from your project. Sorry but at this time palette editing is not supported. It will be the next added feature.

3 - Open your Tiled map in Tiled and start arranging your tiles. DO NOT include more than 1 instance of the same tile. When you're done that, save the map file.

4 - Back in Porno-Graphic, click on File -> Convert TMX to Indexed GIF. Select your Tiled map with your arranged tiles. It will then use your Tiled map to generate an indexed color GIF using the gfx elements from your project. Note that although it is a 256 color GIF, only the first 16 colors are displayed. Anywhere on the image that doesn't have a tile is transparent.

5 - Open your indexed GIF in a graphics program. I strongly recommend Gimp for this. Not only is it free and open source, but it does a pretty damn good job of allowing for the editing of indexed color images, and also includes some quality of life features like allowing you to rearrange the colors in your palette without affecting how your image looks. Photoshop can be used for editing indexed color GIFs, but it's expensive and a bit clunky for this purpose. Paint.net cannot be used for this at all, as it can only edit true color images. 

You can change the palette to make editing easier. Please note that Porno-Graphic does not convert palette data back to your ROM. Due to the myriad ways in which palette data can be loaded in all the systems Porno-Graphic can support, a feature like this is currently out of this project's scope.

Make your changes to the graphics and save.

6 - Back in Porno-Graphic, select File -> Import changes from GIF. Select your edited GIF, as well as the Tiled map you used to generate the GIF. Porno-Graphic will then reference your Tiled map to convert the changes in your GIF back into gfx elements in your project file.

7 - Select File -> Save graphics data to -> Flat file. This will load your original ROMs from the paths you defined when you created the project, and then convert all your gfx elements in your project back to their original format and apply them to your exported data. If you need to split the flat binary further, you have to use another program like ROM Mangler (go to step 1 for a link to ROM Mangler)