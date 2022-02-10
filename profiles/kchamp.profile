﻿<?xml version="1.0" encoding="utf-8"?>
<profile:profile name="Karate Champ/Karate Do (Arcade)"
    xsi:schemaLocation="http://romhackers.net/porno-graphic/profile profile.xsd"
    xmlns:profile="http://romhackers.net/porno-graphic/profile"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
>
  <layouts>
    <layout name="Karate Champ Tile Layout">
      <plane multiplier="131072">
        <offset bits="1" />
        <offset bits="0" />
      </plane>
      <x multiplier="1">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
      </x>
      <y multiplier="8">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
      </y>
      <stride>64</stride>
    </layout>
	
    <layout name="Karate Champ Sprite Layout">
      <plane multiplier="393216">
        <offset bits="1" />
        <offset bits="0" />
      </plane>
      <x multiplier="1">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
        <offset bits="65536" />
        <offset bits="65537" />
        <offset bits="65538" />
        <offset bits="65539" />
        <offset bits="65540" />
        <offset bits="65541" />
        <offset bits="65542" />
        <offset bits="65543" />
      </x>
      <y multiplier="8">
        <offset bits="0" />
        <offset bits="1" />
        <offset bits="2" />
        <offset bits="3" />
        <offset bits="4" />
        <offset bits="5" />
        <offset bits="6" />
        <offset bits="7" />
        <offset bits="8" />
        <offset bits="9" />
        <offset bits="10" />
        <offset bits="11" />
        <offset bits="12" />
        <offset bits="13" />
        <offset bits="14" />
        <offset bits="15" />
      </y>
      <stride>128</stride>
    </layout>
  </layouts>

  <regions>
    <region name="kchamp Tiles" length="08000">
      <file name="b000">
        <load offset="00000" size="2000" />
      </file>
      <file name="b001">
        <load offset="04000" size="2000" />
      </file>
    </region>

    <region name="kchamp Sprites" length="18000">
      <file name="b013">
        <load offset="00000" size="2000" />
      </file>
      <file name="b004">
        <load offset="02000" size="2000" />
      </file>
      <file name="b012">
        <load offset="04000" size="2000" />
      </file>
      <file name="b003">
        <load offset="06000" size="2000" />
      </file>
      <file name="b011">
        <load offset="08000" size="2000" />
      </file>
      <file name="b002">
        <load offset="0a000" size="2000" />
      </file>
      <file name="b007">
        <load offset="0c000" size="2000" />
      </file>
      <file name="b010">
        <load offset="0e000" size="2000" />
      </file>
      <file name="b006">
        <load offset="10000" size="2000" />
      </file>
      <file name="b009">
        <load offset="12000" size="2000" />
      </file>
      <file name="b005">
        <load offset="14000" size="2000" />
      </file>
      <file name="b008">
        <load offset="16000" size="2000" />
      </file>
    </region>
	
	<region name="karatedo Tiles" length="08000">
      <file name="be00">
        <load offset="00000" size="2000" />
      </file>
      <file name="be01">
        <load offset="04000" size="2000" />
      </file>
    </region>

    <region name="karatedo Sprites" length="18000">
      <file name="be13">
        <load offset="00000" size="2000" />
      </file>
      <file name="be04">
        <load offset="02000" size="2000" />
      </file>
      <file name="b012">
        <load offset="04000" size="2000" />
      </file>
      <file name="b003">
        <load offset="06000" size="2000" />
      </file>
      <file name="b011">
        <load offset="08000" size="2000" />
      </file>
      <file name="b002">
        <load offset="0a000" size="2000" />
      </file>
      <file name="be07">
        <load offset="0c000" size="2000" />
      </file>
      <file name="be10">
        <load offset="0e000" size="2000" />
      </file>
      <file name="b006">
        <load offset="10000" size="2000" />
      </file>
      <file name="b009">
        <load offset="12000" size="2000" />
      </file>
      <file name="b005">
        <load offset="14000" size="2000" />
      </file>
      <file name="b008">
        <load offset="16000" size="2000" />
      </file>
    </region>
	
	<region name="karateda Tiles" length="08000">
      <file name="h3">
        <load offset="00000" size="2000" />
      </file>
      <file name="h6">
        <load offset="04000" size="2000" />
      </file>
    </region>

    <region name="karateda Sprites" length="18000">
      <file name="k15">
        <load offset="00000" size="2000" />
      </file>
      <file name="j15">
        <load offset="02000" size="2000" />
      </file>
      <file name="k13">
        <load offset="04000" size="2000" />
      </file>
      <file name="j13">
        <load offset="06000" size="2000" />
      </file>
      <file name="k12">
        <load offset="08000" size="2000" />
      </file>
      <file name="j12">
        <load offset="0a000" size="2000" />
      </file>
      <file name="k4">
        <load offset="0c000" size="2000" />
      </file>
      <file name="k9">
        <load offset="0e000" size="2000" />
      </file>
      <file name="k2">
        <load offset="10000" size="2000" />
      </file>
      <file name="k8">
        <load offset="12000" size="2000" />
      </file>
      <file name="k1">
        <load offset="14000" size="2000" />
      </file>
      <file name="k7">
        <load offset="16000" size="2000" />
      </file>
    </region>
	
	<region name="kchampvs Tiles" length="08000">
      <file name="k1">
        <load offset="00000" size="2000" />
      </file>
      <file name="k3">
        <load offset="02000" size="2000" />
      </file>
	  <file name="k5">
        <load offset="04000" size="2000" />
      </file>
      <file name="k6">
        <load offset="06000" size="2000" />
      </file>
    </region>

    <region name="kchampvs Sprites" length="18000">
      <file name="a1">
        <load offset="00000" size="2000" />
      </file>
      <file name="c1">
        <load offset="02000" size="2000" />
      </file>
      <file name="a3">
        <load offset="04000" size="2000" />
      </file>
      <file name="c3">
        <load offset="06000" size="2000" />
      </file>
      <file name="a5">
        <load offset="08000" size="2000" />
      </file>
      <file name="c5">
        <load offset="0a000" size="2000" />
      </file>
      <file name="a6">
        <load offset="0c000" size="2000" />
      </file>
      <file name="c6">
        <load offset="0e000" size="2000" />
      </file>
      <file name="a8">
        <load offset="10000" size="2000" />
      </file>
      <file name="c8">
        <load offset="12000" size="2000" />
      </file>
      <file name="a10">
        <load offset="14000" size="2000" />
      </file>
      <file name="c10">
        <load offset="16000" size="2000" />
      </file>
    </region>
  </regions>
</profile:profile>
